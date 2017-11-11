using System;
using System.Diagnostics;
using System.IO;
static class Terminal {
    // reference to logs
    static Log[] loggs = new Log[3];
    // Console size
    static int size_x;
    static int size_y;

    //get set
    public static Log GetLog(int num) {
        return loggs[num];
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
    //initialize logs
    public static void initLogs() {
        loggs[0] = new Log(20, 5);
        loggs[1] = new Log(70, 5);
        loggs[2] = new Log(120, 5);
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
// game log
class Log {
     // log size
    int logWidth = 40;
    int logHeight = 20;
    // log position
    int position_x = 100;
    int position_y = 5;

    int currentPosition = 0;

    void increaseCurrentPos() {
        currentPosition++;
    }
    // set cursor on position
    public void setCursor() {
        setCursor(0);
    }
    // set cursor relative to log position
    public void setCursor(int offset) {
        Console.SetCursorPosition(position_x, getLine(offset));
    }
    // get line_y offset-ammount of lines below current line
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
            Console.Write(new string(' ', logWidth));
        }
        increaseCurrentPos();
    }
    // constructors
    public Log(int pos_x, int pos_y) {
        position_x = pos_x;
        position_y = pos_y;
    }
    public Log(int width, int height, int pos_x, int pos_y) {
        logWidth = width;
        logHeight = height;
        position_x = pos_x;
        position_y = pos_y;
    }  
}