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
    // prints Unit dies
    public static void printDeath(Unit u) {
        string msg = u.getName();
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
    // print attacker hits receiver for dmg
    public static void printAttack(Unit atter, Unit rever) {
        // set name and color for attacker and receiver
        string attacker = atter.getName();
        string receiver = rever.getName();
        ConsoleColor atterColor;
        ConsoleColor reverColor;
        string dmg = atter.getAD().ToString();
        if(atter.getTeam()) {
            atterColor = playerColor;
            reverColor = pcColor;
        } else {
            atterColor = pcColor;
            reverColor = playerColor;
        }
        // print message
        printColor(attacker, atterColor);
        Console.Write(" hits ");
        printColor(receiver, reverColor);
        Console.Write(" for ");
        printColor(dmg, red);
        Console.WriteLine();
    }
    // print unit joined which team. on unit construcor
    public static void printSpawn(Unit u) {
        string msg = u.getName();
        ConsoleColor color;
        bool isPl = u.getTeam();
        if(isPl) {
            color = playerColor;
        } else {
            color = pcColor;
        }
        printColor(msg, color);
        Console.WriteLine(" has entered team {0}", isPl);
    }
    // write a msg from certain color 
    public static void printColor(string msg, ConsoleColor color) {
        Console.BackgroundColor = color;
        Console.Write(msg);
        Console.ResetColor();
    }
    // track movement
    public static void printMove(string who, int from, int to) {
        Console.WriteLine("{0} moves from {1} to {2}",
        who, from, to);
    }
}