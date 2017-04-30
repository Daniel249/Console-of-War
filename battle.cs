using System;

class Battle {
    Map map;
    TurnQ queue;

    public TurnQ getQueue() {
        return queue;
    }
    public Map getMap() {
        return map;
    }
    // run battle
    public bool turn() {
        queue.run();
        return true;
    }
    public bool run(int army) {
        int counter = 0;
        bool alternate = true;
        while(turn()) {
            if(counter < army) {
                Program.test(this, alternate);
                //alternate = !alternate;
                counter++;
            }
        }
        return true;
    }
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
            Console.WriteLine("Error: Unit = null, cant construct");
            return false;
        }
    }
    // constructor
    public Battle() {
        map = new Map();
        queue = new TurnQ();
    }
}