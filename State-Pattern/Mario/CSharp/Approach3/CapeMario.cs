using static System.Console;

public class CapeMario : IState {
    private Mario mario;

    public CapeMario(Mario mario) {
        this.mario = mario;
    }

    public void GotMushroom(Mario mario) {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower(Mario mario) {
        WriteLine("Got FireFlower!");
        mario.state = mario.GetState("fireMario");
        mario.GotCoins(200);
    }

    public void GotFeather(Mario mario) {
        WriteLine("Got Feather!");
        mario.GotCoins(300);
    }

    public void MetMonster(Mario mario) {
        WriteLine("Met Monster!");
        mario.state = mario.GetState("smallMario");
    }
}