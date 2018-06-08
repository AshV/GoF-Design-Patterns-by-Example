using static System.Console;

public class FireMario : IState
{
    private Mario mario;

    public FireMario(Mario mario)
    {
        this.mario = mario;
    }

    public void GotMushroom()
    {
        WriteLine("Got Mushroom!");
        mario.GotCoins(100);
    }

    public void GotFireFlower()
    {
        WriteLine("Got FireFlower!");
        mario.GotCoins(200);
    }

    public void GotFeather()
    {
        WriteLine("Got Feather!");
        mario.state = mario.GetState("capeMario");
        mario.GotCoins(300);
    }

    public void MetMonster()
    {
        WriteLine("Met Monster!");
        mario.state = mario.GetState("smallMario");
    }
}
