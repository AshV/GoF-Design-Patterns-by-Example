using static System.Console;

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