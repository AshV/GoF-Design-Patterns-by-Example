using static System.Console;

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