using System;
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
    // runs in Main until queue.run return false
    public bool run(int army) {
        int counter = 0;
        bool alternate = true;
         do {
            if(counter < army) {
                Program.test(this, alternate);
                //alternate = !alternate;
                counter++;
            } 
        } while(turn());

        return true;
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
            u = new Warrior(isPl);
            break;
            case "a":
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
    public Battle() {
        map = new Map();
        queue = new TurnQ();
    }
}