using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class SuperMario : IState
{
    private Mario mario;

    public SuperMario(Mario mario)
    {
        this.mario = mario;
    }

    public void GotFeather()
    {
        throw new NotImplementedException();
    }

    public void GotFireFlower()
    {
        throw new NotImplementedException();
    }

    public void GotMushroom()
    {
        throw new NotImplementedException();
    }

    public void MetMonster()
    {
        throw new NotImplementedException();
    }
}