# State Design Pattern by Mario Example

![State Design Pattern - Game Character States](assets/header.png)

In object oriented programming State Pattern is one of the way to implement *Finite State Machines*. This pattern falls under *Behavioral Design Patterns*.

When in our software, object can transit between multiple possible states, and changes it's behaviour according to state, Then this type of problems can be easily solved using *[Finite State Machines](https://en.wikipedia.org/wiki/Finite-state_machine)*, and this pattern helps us to achieve  this.

## Glance of Mario's State/Behaviours in Game

Here I'm taking example of **Super Mario** game, most of the people must be already aware of this nostalgic game. In this mario changes its states and behaviour based on events occurred, which you can see in below image which I got from [Mario Wiki](https://www.mariowiki.com/Super_Mario_World).

![Super Mario States](assets/mario-finite-state-machine.jpg)

Let's observe states/behaviour and events in above image.

#### States
1. Mario (We will refer as Small Mario here after)
2. Super Mario
3. Fire Mario
4. Cape Mario
5. Lost Life (Apart from image considering this state)

#### Events
1. Got Mushroom 🍄
2. Got Fire Flower 🔥
3. Got Feather 🍃
4. Met Monster 👹 (Not shown in image, but you know Mario game. right?😉)

#### State Transition on Event Occurrence & Earning Coins

Below table demonstrates how state changes on different events. Apart from state change, coins are also earned on occurrence of events.

Current State | Event Occurred | New State | Coins Earned
---|---|---
Small Mario | Got Mushroom 🍄 | Super Mario | 100
Small Mario | Got Fire Flower 🔥 | Fire Mario | 200
Small Mario | Got Feather 🍃 | Cape Mario | 300
Small Mario | Met Monster 👹 | Lost Life | 0
Super Mario | Got Mushroom 🍄 | Super Mario | 100
Super Mario | Got Fire Flower 🔥 | Fire Mario | 200
Super Mario | Got Feather 🍃 | Cape Mario | 300
Super Mario | Met Monster 👹 | Small Mario | 0
Fire Mario | Got Mushroom 🍄 | Fire Mario | 100
Fire Mario | Got Fire Flower 🔥 | Fire Mario | 200
Fire Mario | Got Feather 🍃 | Cape Mario | 300
Fire Mario | Met Monster 👹 | Small Mario | 0
Cape Mario | Got Mushroom 🍄 | Cape Mario | 100
Cape Mario | Got Fire Flower 🔥 | Fire Mario | 200
Cape Mario | Got Feather 🍃 | Cape Mario | 300
Cape Mario | Met Monster 👹 | Small Mario | 0

#### Earning Life

On each 5000 coins collected, one life will be awarded.


## Implementing in Code

Just to make it clear Nintendo haven't open sourced Super Mario source code yet 😜, I am just taking example to help you understand State Design Pattern, like other articles in series we will start code with some code, and will be refactoring it gradually.

> [Find Source Code in GitHub / State Patern / Mario](https://github.com/AshV/GoF-Design-Patterns-by-Example/tree/master/State-Pattern/Mario/)

### Approach 1: Creating Method for Every Events Occured

We created enum(internalState) with name of all the states, for each event we have methods, where after validating conditions we are setting **State** property value which is of **internalState** type and represents the current state of object/Mario. refer below code

> Source Code : [State Pattern / Mario / Approach1](https://github.com/AshV/GoF-Design-Patterns-by-Example/tree/master/State-Pattern/Mario/CSharp/Approach1)

```csharp
public class Mario {
    enum internalState {
        SmallMario,
        SuperMario,
        FireMario,
        CapeMario
    }

    public int LifeCount { get; private set; }
    public int CoinCount { get; private set; }
    private internalState State { get; set; }

    public Mario() {
        LifeCount = 1;
        CoinCount = 0;
        State = internalState.SmallMario;
    }

    public void GotMushroom() {
        WriteLine("Got Mushroom!");
        if (State == internalState.SmallMario)
            State = internalState.SuperMario;

        GotCoins(100);
    }

    public void GotFireFlower() {
        WriteLine("Got FireFlower!");
        State = internalState.FireMario;
        GotCoins(200);
    }

    public void GotFeather() {
        WriteLine("Got Feather!");
        State = internalState.CapeMario;
        GotCoins(300);
    }

    public void GotCoins(int numberOfCoins) {
        WriteLine($"Got {numberOfCoins} Coin(s)!");
        CoinCount += numberOfCoins;
        if (CoinCount >= 5000)
        {
            GotLife();
            CoinCount -= 5000;
        }
    }

    private void GotLife() {
        WriteLine("Got Life!");
        LifeCount += 1;
    }

    private void LostLife() {
        WriteLine("Lost Life!");
        LifeCount -= 1;
        if (LifeCount <= 0)
            GameOver();
    }

    public void MetMonster() {
        WriteLine("Met Monster!");
        if (State == internalState.SmallMario)
            LostLife();
        else
            State = internalState.SmallMario;
    }

    public void GameOver() {
        LifeCount = 0;
        CoinCount = 0;
        WriteLine("Game Over!");
    }

    public override string ToString() {
        return $"State: {State} | LifeCount: {LifeCount} | CoinsCount: {CoinCount} \n";
    }
}

class MainClass {
    static void Main(string[] args) {
        Mario mario = new Mario();
        WriteLine(mario);

        mario.GotMushroom();
        WriteLine(mario);

        mario.GotFireFlower();
        WriteLine(mario);

        mario.GotFeather();
        WriteLine(mario);

        mario.GotCoins(4800);
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);
    }
}
```

As you see in output it is changing state on occurrence of different events.

![Approach1_Output](assets/Approach1_Output.png) 

#### Reviewing Approach 1

On occurrence of each event, different operation can be executed based on current state of object. For example GotMushroom event, If it occurs for SmallMario it would be changed to SuperMario, but if same event occurs for SuperMario, it will remain the same. If may lead to confusion to write same conditions in each method.

### Approach 2: Moving All State Related Code To Respective Class

To address problem of approach 1, here I created separate class for each State, which all are inherited from **IState** interface. This interface contains respective methods for all our four events i.e GotMushroom(), GotFireFlower(), GotFeather() & MetMonster().
All State classes are inheriting this, Now before writing state specific code we don't need to check condition, because it's being written for specific states. All 4 state classes are mimicking our State transition table shown above. refer code.

```csharp
public interface IState {
    void GotMushroom();
    void GotFireFlower();
    void GotFeather();
    void MetMonster();
};

public class SmallMario : IState {
    private Mario mario;

    public SmallMario(Mario mario) {
        this.mario = mario;
    }

    public void GotMushroom() {
        WriteLine("Got Mushroom!");
        mario.state = mario.GetState("superMario");
        mario.GotCoins(100);
    }

    public void GotFireFlower() {
        WriteLine("Got FireFlower!");
        mario.state = mario.GetState("fireMario");
        mario.GotCoins(200);
    }

    public void GotFeather() {
        WriteLine("Got Feather!");
        mario.state = mario.GetState("capeMario");
        mario.GotCoins(300);
    }

    public void MetMonster() {
        WriteLine("Met Monster!");
        mario.state = mario.GetState("smallMario");
        mario.LostLife();
    }
}

public class SuperMario : IState {
    private Mario mario;

    public SuperMario(Mario mario) {
        this.mario = mario;
    }

    public void GotMushroom() {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower() {
        WriteLine("Got FireFlower!");
        mario.state = mario.GetState("fireMario");
        mario.GotCoins(200);
    }

    public void GotFeather() {
        WriteLine("Got Feather!");
        mario.state = mario.GetState("capeMario");
        mario.GotCoins(300);
    }

    public void MetMonster() {
        WriteLine("Met Monster!");
        mario.state = mario.GetState("smallMario");
    }
}

public class FireMario : IState {
    private Mario mario;

    public FireMario(Mario mario) {
        this.mario = mario;
    }

    public void GotMushroom() {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower() {
        WriteLine("Got FireFlower!");
        mario.GotCoins(200);
    }

    public void GotFeather() {
        WriteLine("Got Feather!");
        mario.state = mario.GetState("capeMario");
        mario.GotCoins(300);
    }

    public void MetMonster() {
        WriteLine("Met Monster!");
        mario.state = mario.GetState("smallMario");
    }
}

public class CapeMario : IState {
    private Mario mario;

    public CapeMario(Mario mario) {
        this.mario = mario;
    }

    public void GotMushroom() {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower() {
        WriteLine("Got FireFlower!");
        mario.state = mario.GetState("fireMario");
        mario.GotCoins(200);
    }

    public void GotFeather() {
        WriteLine("Got Feather!");
        mario.GotCoins(300);
    }

    public void MetMonster() {
        WriteLine("Met Monster!");
        mario.state = mario.GetState("smallMario");
    }
}

public class Mario {
    public int LifeCount { get; private set; }
    public int CoinCount { get; private set; }
    public IState state;

    private SmallMario smallMario;
    private SuperMario superMario;
    private FireMario fireMario;
    private CapeMario capeMario;

    public Mario() {
        LifeCount = 1;
        CoinCount = 0;

        smallMario = new SmallMario(this);
        superMario = new SuperMario(this);
        fireMario = new FireMario(this);
        capeMario = new CapeMario(this);

        state = smallMario;
    }

    public IState GetState(string stateId) {
        switch (stateId) {
            case "smallMario":
                return smallMario;
            case "superMario":
                return superMario;
            case "fireMario":
                return fireMario;
            case "capeMario":
                return capeMario;
            default:
                return null;
        }
    }
   
    public void GotMushroom() {
        state.GotMushroom();
    }

    public void GotFireFlower() {
        state.GotFireFlower();
    }

    public void GotFeather() {
        state.GotFeather();
    }

    public void MetMonster() {
        state.MetMonster();
    }
    
    public void GotCoins(int numberOfCoins) {
        WriteLine($"Got {numberOfCoins} Coin(s)!");
        CoinCount += numberOfCoins;
        if (CoinCount >= 5000) {
            GotLife();
            CoinCount -= 5000;
        }
    }

    public void GotLife() {
        WriteLine("Got Life!");
        LifeCount += 1;
    }

    public void LostLife() {
        WriteLine("Lost Life!");
        LifeCount -= 1;
        if (LifeCount <= 0)
            GameOver();
    }

    public void GameOver() {
        LifeCount = 0;
        CoinCount = 0;
        WriteLine("Game Over!");
    }

    public override string ToString() {
        return $"State: {state} | LifeCount: {LifeCount} | CoinsCount: {CoinCount} \n";
    }
}

class MainClass {
    static void Main(string[] args) {
        Mario mario = new Mario();
        WriteLine(mario);

        mario.GotMushroom();
        WriteLine(mario);

        mario.GotFireFlower();
        WriteLine(mario);

        mario.GotFeather();
        WriteLine(mario);

        mario.GotCoins(4800);
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);
    }
}
```

#### Reviewing Approach 2

Everything related to states is within state classes now, but responsibility to create it's object is still outside.

### Approach 3: Making State Classes Singleton

Since our state classes having no variable/properties, all those are maintained in Mario class, so we can make state classes singleton. In event methods of all singleton classes we will be passing current Mario object so states can be switched. Here IState interface is changed accordingly to pass Mario class object as parameter & Inside Mario class no need to initialize all the objects.

```csharp
public interface IState {
    void GotMushroom(Mario mario);
    void GotFireFlower(Mario mario);
    void GotFeather(Mario mario);
    void MetMonster(Mario mario);
};

public class SmallMario : IState {
    private static SmallMario instance = new SmallMario();

    private SmallMario() { }

    public static SmallMario GetInstance {
        get { return instance; }
    }

    public void GotMushroom(Mario mario) {
        WriteLine("Got Mushroom!");
        mario.State = SuperMario.GetInstance;
        mario.GotCoins(100);
    }

    public void GotFireFlower(Mario mario) {
        WriteLine("Got FireFlower!");
        mario.State = FireMario.GetInstance; 
        mario.GotCoins(200);
    }

    public void GotFeather(Mario mario) {
        WriteLine("Got Feather!");
        mario.State = CapeMario.GetInstance;
        mario.GotCoins(300);
    }

    public void MetMonster(Mario mario) {
        WriteLine("Met Monster!");
        mario.State = SmallMario.GetInstance;
        mario.LostLife();
    }
}

public class SuperMario : IState {
    private static SuperMario instance = new SuperMario();

    private SuperMario() { }

    public static SuperMario GetInstance {
        get { return instance; }
    }

    public void GotMushroom(Mario mario) {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower(Mario mario) {
        WriteLine("Got FireFlower!");
        mario.State = FireMario.GetInstance;
        mario.GotCoins(200);
    }

    public void GotFeather(Mario mario) {
        WriteLine("Got Feather!");
        mario.State = CapeMario.GetInstance;
        mario.GotCoins(300);
    }

    public void MetMonster(Mario mario) {
        WriteLine("Met Monster!");
        mario.State = SmallMario.GetInstance;
    }
}

public class FireMario : IState {
    private static FireMario instance = new FireMario();

    private FireMario() { }

    public static FireMario GetInstance {
        get { return instance; }
    }

    public void GotMushroom(Mario mario) {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower(Mario mario) {
        WriteLine("Got FireFlower!");
        mario.GotCoins(200);
    }

    public void GotFeather(Mario mario) {
        WriteLine("Got Feather!");
        mario.State = CapeMario.GetInstance;
        mario.GotCoins(300);
    }

    public void MetMonster(Mario mario) {
        WriteLine("Met Monster!");
        mario.State = SmallMario.GetInstance;
    }
}

public class CapeMario : IState {
    private static CapeMario instance = new CapeMario();

    private CapeMario() { }

    public static CapeMario GetInstance {
        get { return instance; }
    }

    public void GotMushroom(Mario mario) {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower(Mario mario) {
        WriteLine("Got FireFlower!");
        mario.State = FireMario.GetInstance;
        mario.GotCoins(200);
    }

    public void GotFeather(Mario mario) {
        WriteLine("Got Feather!");
        mario.GotCoins(300);
    }

    public void MetMonster(Mario mario) {
        WriteLine("Met Monster!");
        mario.State = SmallMario.GetInstance; 
    }
}

public class Mario
{
    public int LifeCount { get; private set; }
    public int CoinCount { get; private set; }
    private IState state;

    public IState State {
        set { state = value; }
    }

    public Mario() {
        LifeCount = 1;
        CoinCount = 0;

        state = SmallMario.GetInstance;
    }

    public void GotMushroom() {
        state.GotMushroom(this);
    }

    public void GotFireFlower() {
        state.GotFireFlower(this);
    }

    public void GotFeather() {
        state.GotFeather(this);
    }

    public void MetMonster() {
        state.MetMonster(this);
    }

    public void GotCoins(int numberOfCoins) {
        WriteLine($"Got {numberOfCoins} Coin(s)!");
        CoinCount += numberOfCoins;
        if (CoinCount >= 5000) {
            GotLife();
            CoinCount -= 5000;
        }
    }

    public void GotLife() {
        WriteLine("Got Life!");
        LifeCount += 1;
    }

    public void LostLife() {
        WriteLine("Lost Life!");
        LifeCount -= 1;
        if (LifeCount <= 0)
            GameOver();
    }

    public void GameOver() {
        LifeCount = 0;
        CoinCount = 0;
        WriteLine("Game Over!");
    }

    public override string ToString() {
        return $"State: {state} | LifeCount: {LifeCount} | CoinsCount: {CoinCount} \n";
    }
}

class MainClass {
    static void Main(string[] args) {
        Mario mario = new Mario();
        WriteLine(mario);

        mario.GotMushroom();
        WriteLine(mario);

        mario.GotFireFlower();
        WriteLine(mario);

        mario.GotFeather();
        WriteLine(mario);

        mario.GotCoins(4800);
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);
    }
}
```

### Conclusion 

All state related logic is maintained within state classes now, and in final approach singleton is used, which can be implemented in various better ways.
Here we have removed conditional duplicacy & new states can be easily added. Existing states logic can be easily extended without changing any other class. In game programming this pattern is frequently used.

Thanks for reading, let the suggestions/discussions/queries go in comments.