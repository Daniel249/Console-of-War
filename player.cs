using System;
using System.Collections.Generic;
class Player : Entity{
    

    // get set
    
    public override void runTurn() {
        // checks first if key available. if not continue loop
        if(Console.KeyAvailable) {
            ConsoleKey letter = Console.ReadKey(true).Key;
            Skript.processKey(letter);
            proKey(letter);
        }
    }
    void proKey(ConsoleKey key) {       
        if(Skript.processKey(key)) {
            return;
        }
        // test
        // spawn enemy units
        Unit eUnit = null;
        if(key.ToString() == "U") {
            eUnit = new Warrior(false);
        }
        if(key.ToString() == "I") {
            eUnit = new Archer(false);
        }
        if(key.ToString() == "O") {
            eUnit = new Lancer(false);
        }
        // skip spawnUnit to avoid printing "Unit = null"
        // only if enemy got to spawn an Unit
        if (spawnEnemy(eUnit)) {
            return;
        }
        // player key
        // check for lane change
        switch(key.ToString()) {
            case "D1":
            changeCurrentLane(0);
            break;
            case "D2":
            changeCurrentLane(1);
            break;
            case "D3":
            changeCurrentLane(2);
            break;
        }
        Unit u = null;
        
        switch(key.ToString()) {
            case "w":
            case "W":
            u = new Warrior(true);
            break;
            case "a":
            case "A":
            u = new Archer(true);
            break;
            case "Z":
            u = new Lancer(true);
            break;
        }
        spawnUnit(u);
    }
    // public override void spawnUnit(Unit un) {
    //     if(un != null) {
    //         un.constrUnit(Skript.getBattle(), getCurrentLane());
    //     } else {
    //         Printer.justPrint("Error: Unit = null");
    //     }
    // }
    public bool spawnEnemy(Unit u) {
        ((Botplayer)Skript.getBattle().getPlayer(false)).receiveOrder(u);
        if (u != null) {
            return true;
        } else {
            return false;
        }
    }
    public Player() {
        isPlayer = true;
    }
    
    // List<string> 
}
abstract class Entity {
    // classes a player can spawn
    protected List<string> classes;
    // current Money
    protected int GoldAmmount;
    // rate earn gold
    protected int goldRate;
    // current  map (lane)
    protected int currentLane;
    // is this the human player
    protected bool isPlayer;
 
    // get set
    public int getCurrentLane() {
        return currentLane;
    }
    public void changeCurrentLane(int lane) {
        if (lane < 3 && lane >= 0) {
            currentLane = lane;

            string laneName = "";
            switch(lane) {
                case 0:
                laneName = "Top";
                break;
                case 1:
                laneName = "Mid";
                break;
                case 2:
                laneName = "Bot";
                break;
            }
            string msg = "Lane changed to " + laneName;
            Printer.justPrint(msg);
        } else {
            Printer.justPrint("not a valid Lane");
        }
    }
    // end game instructions
    protected void endGame() {

    }
    public virtual void spawnUnit(Unit u) {
        if(u != null) {
            u.constrUnit(Skript.getBattle(), getCurrentLane());
        } else {
            Printer.justPrint("Error: Unit = null");
        }

    }
    public virtual void runTurn() {

    }
}