using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        // tost();
        // battle constructor(int turnDuration)
        Battle battle = new Battle(50);
        // test(battle, 5, true);
        // test(battle, 5, false);
        // run(int armySizeForEachPlayer)
        battle.run(0);
    }

}

