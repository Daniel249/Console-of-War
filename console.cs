using System;
using System.Diagnostics;
using System.IO;
public static class Terminal {
    static Log logg = new Log();
    public static Log GetLog() {
        return logg;
    }
    static Process OutputConsole;
    public static void Clear() {
        Console.Clear();
    }
    // rescale whole console
    public static void ResetBuffer(int height, int width) {
        Console.WindowHeight = height;
        Console.BufferHeight = height;
        Console.WindowWidth = width;
        Console.BufferWidth = width;
    }
    public static void PrintSym(string symbol, int pos_x, int pos_y, ConsoleColor color) {
        Console.SetCursorPosition(pos_x,pos_y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }
    public static void PrintText(string text, int pos_x, int pos_y, ConsoleColor color) {
        Console.SetCursorPosition(pos_x,pos_y);
        Console.ForegroundColor = color;
        Console.Write(text);
    }
    public static void exitConsole() {
        //OutputConsole.
    }
    public static void printConsole() {
        StreamWriter sw = OutputConsole.StandardInput;
        //OutputConsole
    }
}
public class Log {
     // log size
    static int logWidth = 40;
    static int logHeight = 20;
    // log position
    static int position_x = 100;
    static int position_y = 5;

    static int currentPosition = 0;

    void increaseCurrentPos() {
        currentPosition++;
    }
    // set cursor on position
    public void setCursor() {
        setCursor(0);
    }
    public void setCursor(int offset) {
        Console.SetCursorPosition(position_x, getLine(offset));
    }
    // increase currentPosition by one and return absolute position
    public int getLine(int offset) {
        // currentPosition++;
        int verticalPosition = position_y + ((currentPosition + offset) % logHeight);
        return verticalPosition;
    }
    // clear log from old msg
    // borderSize ammount of lines will be predeleted
    // increase currentPosition by 1
    public void clearLog(int borderSize) {
        Console.ResetColor();
        for(int i = 1; i <= borderSize; i++) {
            setCursor(i);
            Console.Write(new string(' ', position_x + logWidth - Console.CursorLeft));
        }
        increaseCurrentPos();
    }   
}