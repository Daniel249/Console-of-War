using System;

class Printer {
    // colors
    // player1
    static ConsoleColor playerColor = ConsoleColor.Blue;
    // pc
    static ConsoleColor pcColor = ConsoleColor.DarkGreen;
    // death / dmg dealt
    static ConsoleColor red = ConsoleColor.Red;

    public static void printReg() {
        
    }
    // asks input
    public static string askInput() {
        return null;
    }
    public static void printDeath(Unit u) {
        string msg = u.getClass() + u.getHash();
        ConsoleColor color;
        if(u.getTeam()){
            color = playerColor;
        } else {
            color = pcColor;
        }
        printColor(msg, color);
        printColor(" dies", red);
        Console.WriteLine();
    }
    public static void printAttack(Unit atter, Unit rever) {
        string attacker = atter.getClass() + atter.getHash();
        string receiver = rever.getClass() + rever.getHash();
        string dmg = atter.getAD().ToString();
        if(atter.getTeam()) {
             ally(attacker);
             Console.Write(" hits ");
             enemy(receiver);
        } else {
            enemy(attacker);
            Console.Write(" hits ");
            ally(receiver);
        }
        Console.Write(" for ");
        red(dmg);
        Console.WriteLine();
    }
    // these methods write a msg 
    public static void enemy(string msg) {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        // Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(msg);
        Console.ResetColor();
    }
    public static void ally(string msg) {
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.Write(msg);
        Console.ResetColor();
    }
    
    public static void printColor(string msg, ConsoleColor color) {
        Console.BackgroundColor = color;
        Console.Write(msg);
        Console.ResetColor();
    }
    public static void printMove(string who, int from, int to) {
        Console.WriteLine("{0} moves from {1} to {2}",
        who, from, to);
    }
}