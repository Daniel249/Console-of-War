using System;
// printAttack, printSpawn, printDeath use Terminal.GetLog().setCursor(); and .clearLog(2);
class Printer {
    // colors
    // player1
    static ConsoleColor playerColor = ConsoleColor.Cyan;
    // pc
    static ConsoleColor pcColor = ConsoleColor.Magenta;
    // death / dmg dealt
    static ConsoleColor red = ConsoleColor.Red;
    // get set
    public static ConsoleColor getPlayerColor() {
        return playerColor;
    }
    public static ConsoleColor getPcColor() {
        return pcColor;
    }
    public static ConsoleColor getColor(bool isPlayer) {
        if(isPlayer) {
            return playerColor;
        } else {
            return pcColor;
        }
    }

    public static void printReg() {
        
    }
    // asks input
    public static string askInput() {
        return null;
    }
    // prints Unit dies
    public static void printDeath(Unit u) {
        string msg = u.getName();
        ConsoleColor color = getColor(u.getTeam());
        Terminal.GetLog().setCursor();

        printColor(msg, color);
        printColor(" dies", red);

        Terminal.GetLog().clearLog(2);
    }
    // print attacker hits receiver for dmg
    public static void printAttack(Unit atter, Unit rever) {
        // set name and color for attacker and receiver
        string attacker = atter.getName();
        string receiver = rever.getName();
        ConsoleColor atterColor = getColor(atter.getTeam());
        ConsoleColor reverColor = getColor(rever.getTeam());
        string dmg = atter.getAD().ToString();
        // print message
        Terminal.GetLog().setCursor();

        printColor(attacker, atterColor);
        Console.Write(" hits ");
        printColor(receiver, reverColor);
        Console.Write(" for ");
        printColor(dmg, red);

        Terminal.GetLog().clearLog(2);
    }
    // print unit joined which team. on unit construcor
    public static void printSpawn(Unit u) {
        string msg = u.getName();
        bool isPl = u.getTeam();
        ConsoleColor color = getColor(isPl);;

        Terminal.GetLog().setCursor();

        printColor(msg, color);
        Console.Write(" has entered team {0}", isPl);
        // Console.Write(Console.CursorLeft.ToString());

        Terminal.GetLog().clearLog(2);
    }
    // write a msg from certain color 
    public static void printColor(string msg, ConsoleColor color) {
        Console.BackgroundColor = color;
        Console.Write(msg);
        Console.ResetColor();
    }
    public static void justPrint(string msg) {
        Terminal.GetLog().setCursor();
        Console.Write(msg);
        Terminal.GetLog().clearLog(2);
    }
    // track movement
    public static void printMove(string who, int from, int to) {
        Console.Write("{0} moves from {1} to {2}",
        who, from, to);
        Console.WriteLine();
    }
} 