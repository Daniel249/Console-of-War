using System;

static class Skript {
    // reference to battle
    static Battle mainBattle;
    // bool continue game
    static bool continueGame = true;
    public static bool getContinueGame() {
        return continueGame;
    }
    public static Battle getBattle() {
        return mainBattle;
    }
    public static void setBattle(Battle bat) {
        mainBattle = bat;
    }

    // clear console and print greetings
    public static void greet() {
        Terminal.Clear();
        Console.SetCursorPosition(20, 3);
        Printer.printfColor("Mid", ConsoleColor.Yellow);
        // Console.SetCursorPosition(Terminal.getSize_x()/2, Terminal.getSize_y()/2);
        // Printer.justPrint("(Press any letter to start)");
        Printer.justPrint("allies: a archers, w warriors");
        Printer.justPrint("Enemies: i archers, u warriors");
        Printer.justPrint("1,2,3 to change lane");
    }
    // print bounds of map
    public static void printBounds(Map map) {
        ConsoleColor fcolor = Printer.getColor(true);
        int pos = 0;
        map.printTo(pos, "|", fcolor, ConsoleColor.Black);
        fcolor = Printer.getColor(false);
        pos = map.getSize();
        map.printTo(pos, "|", fcolor, ConsoleColor.Black);
    }
    public static void spawnMinions() {
        Printer.printLogfColor("Minion Spawn", ConsoleColor.Green);
        Cronometer clock = getBattle().getQueue().getGameClock();
        bool siege = (clock.getMinute() == 0);
        bool super = false;
        for (int i = 0; i < 3; i++) {
            spawnMinionsInLane(i, true, siege, super);
            spawnMinionsInLane(i, false, siege, super);
        }
        
    }
    // spawn minions in a lane for a player
    public static void spawnMinionsInLane(int laneNum, bool isPlayer, bool siege, bool super) {
        Battle battle = getBattle();
        for (int i = 0; i < 3; i++) {
            Unit u = new meleeMinion(isPlayer);
            u.constrUnit(battle, laneNum);
        }       
        if(super) {
            Unit u = new superMinion(isPlayer);
            u.constrUnit(battle, laneNum);
        }
        if(siege) {
            Unit u = new siegeMinion(isPlayer);
        }
        for (int i = 0; i < 3; i++) {
            Unit u = new casterMinion(isPlayer);
            u.constrUnit(battle, laneNum);
        }
    }
    // check for Esc key 
    public static bool processKey(ConsoleKey key) {
        if(key == ConsoleKey.Escape) {
            endGame();
        }
        return false;
    }
    static void endGame() {
        continueGame = false;
    }
}
