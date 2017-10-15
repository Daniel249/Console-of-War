using System;
using System.Diagnostics;
using System.IO;
public class Terminal {
    Process OutputConsole;
    // rescale whole console
    public void ResetBuffer(int height, int width) {
        Console.WindowHeight = height;
        Console.BufferHeight = height;
        Console.WindowWidth = width;
        Console.BufferWidth = width;
    }
    public void PrintSym(string symbol, int pos_x, int pos_y, ConsoleColor color) {
        Console.SetCursorPosition(pos_x,pos_y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }
    public void PrintText(string text, int pos_x, int pos_y, ConsoleColor color) {
        Console.SetCursorPosition(pos_x,pos_y);
        Console.ForegroundColor = color;
        Console.Write(text);
    }
    public void exitConsole() {
        //OutputConsole.
    }
    public void printConsole() {
        StreamWriter sw = OutputConsole.StandardInput;
        //OutputConsole
    }
    public Terminal() {
        
    }
}