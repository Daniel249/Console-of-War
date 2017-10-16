using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        // max height, width. (72,240)
        Terminal.setSize(40, 140); 
        Skript.greet();
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

