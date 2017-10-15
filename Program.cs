using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Terminal termin = new Terminal();
        Console.Clear();
        //termin.ResetBuffer(30, 60);

        // tost();
        // battle constructor(int turnDuration, int mapSize)
        Battle battle = new Battle(50, 100);
        // test(battle, 5, true);
        // test(battle, 5, false);
        // run(int armySizeForEachPlayer)
        battle.run();
    }

}

