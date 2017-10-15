using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Terminal.Clear();
        // max height, width. (72,240)
        Terminal.ResetBuffer(40, 140);
        // tost();
        // battle constructor(int turnDuration, int mapSize)
        Battle battle = new Battle(100, 100);
        // console dimensions
        // test(battle, 5, true);
        // test(battle, 5, false);
        // run(int armySizeForEachPlayer)
        battle.run();
        Console.ReadKey();
    }

}

