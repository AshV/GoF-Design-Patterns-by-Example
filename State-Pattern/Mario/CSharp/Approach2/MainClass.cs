using static System.Console;

class MainClass {
    static void Main(string[] args) {
        Mario mario = new Mario();
        WriteLine(mario);

        mario.GotMushroom();
        WriteLine(mario);

        mario.GotFireFlower();
        WriteLine(mario);

        mario.GotFeather();
        WriteLine(mario);

        mario.GotCoins(4800);
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);

        mario.MetMonster();
        WriteLine(mario);
    }
}