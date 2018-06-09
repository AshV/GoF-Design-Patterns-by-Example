using static System.Console;

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