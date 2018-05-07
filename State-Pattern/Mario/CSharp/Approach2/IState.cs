public interface IState
{
    void GotMushroom();
    void GotFireFlower();
    void GotFeather();
    void GotCoins(int numberOfCoins);
    void GotLife();
    void LostLife();
    void MetMonster();
    void GameOver();
};