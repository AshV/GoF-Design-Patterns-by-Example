using static System.Console;

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