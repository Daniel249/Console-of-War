using System;
using System.Diagnostics;
using System.IO;
static class Terminal {
    // reference to log
    static Log logg = new Log();
    // Console size
    static int size_x;
    static int size_y;

    //get set
    public static Log GetLog() {
        return logg;
    }
    public static int getSize_x() {
        return size_x;
    }
    public static int getSize_y() {
        return size_y;
    }
    // set console size variables
    static void _setSize(int sizex, int sizey) {
        size_x = sizex;
        size_y = sizey;
    }
    // setSize and then apply to console
    public static void setSize(int sizey, int sizex) {
        _setSize(sizex, sizey);
        Console.CursorVisible = false;
        ResetBuffer(size_y, size_x);
    }
    static Process OutputConsole;
    public static void Clear() {
        Console.Clear();
    }
    // rescale whole console
    // buffer size must always be greater than window size
    // bug after escaping from game. making the console smaller and relaunching crashes it
    public static void ResetBuffer(int height, int width) {
        if(height >= Console.BufferHeight) {
            Console.BufferHeight = height;
            Console.WindowHeight = height;
        } else {
            Console.WindowHeight = height;
            Console.BufferHeight = height;
        }

        if(width >= Console.BufferWidth) {
            Console.BufferWidth = width;
            Console.WindowWidth = width;
        } else {
            Console.WindowWidth = width;
            Console.BufferWidth = width;
            
        }
    }
    static void compareBuffSize() {

    }
    public static void PrintSym(string symbol, int pos_x, int pos_y, ConsoleColor color) {
        Console.SetCursorPosition(pos_x,pos_y);
        Console.ForegroundColor = color;
        Console.Write(symbol);
    }
    public static void PrintText(string text, int pos_x, int pos_y, ConsoleColor color) {
        Console.SetCursorPosition(pos_x, pos_y);
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
    static int logWidth = 45;
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