using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Terminal.Clear();
        Terminal.ResetBuffer(60, 200);
        // tost();
        // battle constructor(int turnDuration, int mapSize)
        Battle battle = new Battle(50, 100);
        // console dimensions
        // test(battle, 5, true);
        // test(battle, 5, false);
        // run(int armySizeForEachPlayer)
        battle.run();
    }

}

