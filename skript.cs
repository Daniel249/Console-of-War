using System;

static class Skript {

    static Battle mainBattle;
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
        Printer.justPrint("(Press any letter to start)");
        Printer.justPrint("allies: a archers, w warriors");
        Printer.justPrint("Enemies: i archers, u warriors");
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
