using static System.Console;

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
        GotCoins(100);
    }

    public void GotFeather() {
        WriteLine("Got Feather!");
        State = internalState.CapeMario;
        GotCoins(100);
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