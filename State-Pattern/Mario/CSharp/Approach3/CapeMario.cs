using static System.Console;

public class CapeMario : IState {
    private static CapeMario instance = new CapeMario();

    private CapeMario() { }

    public static CapeMario GetInstance
    {
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