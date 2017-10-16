using System;

public static class Skript {
    
    // clear console and print greetings
    public static void greet() {
        Terminal.Clear();
        Console.SetCursorPosition(20, 3);
        Printer.printfColor("Mid", ConsoleColor.Yellow);
        Console.SetCursorPosition(Terminal.getSize_x()/2, Terminal.getSize_y()/2);
        Printer.justPrint("(Press any letter to start)");
    }
}
