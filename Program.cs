using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        // max height, width. (72,240)
        Terminal.setSize(40, 200); 
        Skript.greet();
        // tost();
        // battle constructor
        // (int turnDuration, int mapSize, nexus_pos_x, nexus_pos_y)
        Battle battle = new Battle(100, 120, 140, 10 , 30);
        Skript.printBounds(battle.getMap(0));
        Skript.printBounds(battle.getMap(1));
        Skript.printBounds(battle.getMap(2));
        // console dimensions
        // test(battle, 5, true);
        // test(battle, 5, false);
        // run(int armySizeForEachPlayer)
        battle.run();
        Console.CursorVisible = true;
        Console.ReadKey();
    }

}

