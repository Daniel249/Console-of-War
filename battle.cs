using System;
using System.Threading;
// class battle
// controls map unit and queue
class Battle {
    Map map;
    TurnQ queue;
    // get set
    public TurnQ getQueue() {
        return queue;
    }
    public Map getMap() {
        return map;
    }
    // run battle
    // controls when to stop
    public bool turn() {
        return queue.run();
    }
    // runs in Main until KeyAvailable and ReadKey.Key == Escape
    public bool run(int army) {
        bool check = true;
        while(check) {
            // checks first if key available. if not continue loop
            if(Console.KeyAvailable) {
                ConsoleKey letter = Console.ReadKey(true).Key;
                if(letter == ConsoleKey.Escape) {
                    endGame();
                    break;
                } else {
                   proKey(letter);
                }
            }
            // execute turn each loop
            turn();
        }
        return true;
    }
    void proKey(ConsoleKey key) {
        spawnUnit(true, key.ToString());
    }
    void endGame() {

    }
    // spawn unit of type and team
    public bool spawnUnit(bool isPl, string type) {
        int newPosition = 0;
        if(!isPl) {
            newPosition = map.getSize() - 1;
        }
        Unit u = null;
        switch(type) {
            case "w":
            case "W":
            u = new Warrior(isPl);
            break;
            case "a":
            case "A":
            u = new Archer(isPl);
            break;
        }
        if(u != null) {
            u.constrUnit(this, newPosition);
            return true;
        } else {
            Console.WriteLine("Error: Unit = null, cant construct on battle.spawnUnit()");
            return false;
        }
    }
    // constructor
    public Battle(int turnLength) {
        map = new Map();
        queue = new TurnQ(turnLength);
    }
}