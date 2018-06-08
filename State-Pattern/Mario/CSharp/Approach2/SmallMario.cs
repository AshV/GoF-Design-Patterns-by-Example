public class SmallMario : IState
{
    private Mario mario;

    public SmallMario(Mario mario)
    {
        this.mario = mario;
    }

    public void GotMushroom()
    {
        mario.state = mario.GetState("superMario");

       mario.GotCoins(100);
    }

    public void GotFireFlower()
    {
        mario.state = mario.GetState("fireMario");
    }

    public void GotFeather()
    {
        mario.state = mario.GetState("capeMario");
    }

    public void MetMonster()
    {
        //  throw new NotImplementedException();
    }
}