using System;

class Program {
    static void Main(string[] args) {
        Console.WriteLine("Hello World!");
        Battle battle = new Battle();
        // test(battle, 5, true);
        // test(battle, 5, false);
        battle.run(50);
    }
    public static void test(Battle bat, bool isPl) {
        bat.spawnUnit(isPl, "a");
        bat.spawnUnit(!isPl, "a");
    }

}

