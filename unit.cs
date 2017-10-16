using System;
using System.Collections.Generic;

// Units
class Unit {
    // true for player1
    // define walking direction etc
    protected bool isPlayer; 
    // visual idle state
    protected string idleCode;
    // visual receive dmg state
    protected string hitCode;
    // attack damage
    protected int attackDamage;
    // attack Ranke. 1 for melee
    protected int attackRange;
    // attack speed. at value 1 deal damage each turn
    protected int atackSpeed;
    // 0 for single target
    protected int aoeRange;
    // move range
    protected int moveRange;
    // max hp
    protected int healthPoints;
    // blocked damage per attack received
    protected int blockDmg;
    // Unit class
    protected string tipo;
    // unique hash code
    protected int hash;
    // hash counter for constructor
    protected static int hashCounter = 0;
    // gold price to spawn
    int price;

    // reference to map and battle
    Map map;
    Battle bat;
    // position in map
    int position;
    

    // get set
    public string getIdleCode() {
        return this.idleCode;
    }
    public string getHitCode() {
        return this.hitCode;
    }
    public int getAS() {
        return atackSpeed;
    }
    public int getAD() {
        return attackDamage;
    }
    public bool getTeam() {
        return isPlayer;
    }
    public string getName() {
        return tipo + hash;
    }

    // methods
    // get direction for moving and attacking depending of team
    int getDirection() {
        int dir;
        if(isPlayer) {
            dir = 1;
        } else {
            dir = -1;
        }
        return dir;
    }
    // checks if an enemy is in attackRange
    // checkAttack comes before check move.
    // so it will return false if outOfBound
    public bool checkAtack() {
        int dir = getDirection();
        // check relative position. distance i, direction dir
        for(int i = 1; i <= attackRange; i++) {
            // nearby targets checked first
            int possiblePlace = i*dir + position;
            // security out of bound. kill unit
            if(possiblePlace >= map.getSize()||
            possiblePlace <= 0) 
            {
                // this.die();
                return false;
            }
            if(map.getMap(possiblePlace) != null) {
                Unit u = map.getMap(possiblePlace);
                if(this.isPlayer != u.isPlayer) {
                    //lock target on array then atack params array
                    Unit[] us = lockTarget(u);
                    this.attack(us);
                    return true;
                }
            }

        }

        return false;
    }
    // checks if empty space on moveRange
    //large steps priority
    public bool checkMove() {
        int dir = getDirection();
        for(int i = moveRange; i > 0; i--) {
            int possiblePlace = i*dir + position;
            if(possiblePlace >= map.getSize()||
            possiblePlace <= 0) 
            {
                this.die();
                return false;
            }
            // if no hay nada a distancia i en direccion dir desde la position de la unidad
            // espacios lejanos tienen prioridad
            // mover ahi
            if(map.getMap(possiblePlace) == null) {
                this.move(possiblePlace);
                return true;
            }
        }
        return false;
    }
    // move to newPosition in map. Then update position variable
    public virtual void move(int newPosition) {
        // set reference on map and then print on console
        map.setMap(this, newPosition);
        ConsoleColor fcolor = Printer.getColor(this.isPlayer);
        map.printTo(newPosition, idleCode, fcolor, map.getLaneColor());
        // remove reference from map and erase from console
        if(map.getMap(position) == this) {
            map.setMap(null, position);
            map.eraseFrom(position, map.getLaneColor());
        }
        // test
        // Printer.printMove(tipo + hash, position, newPosition);
        this.position = newPosition;
    }
    // locks targets behind initial target based on aoeRange
    Unit[] lockTarget(Unit u) {
        // Unit[] us = new Unit[aoeRange + 1];
        List<Unit> us = new List<Unit>();
        int dir = getDirection();
        us.Add(u);
        for(int i = 1; i <= aoeRange; i++) {
            // us[i] = map.getMap(u.position+i);
            Unit possibleUnit = map.getMap(u.position + dir*i);
            if(possibleUnit != null) {
                us.Add(map.getMap(u.position + dir*i));
            }
        }
        return us.ToArray();
    }
    // deal damage to all units given as parameters
    public virtual void attack(params Unit[] us) {
        foreach(Unit u in us) {
            // print attack
            Printer.printAttack(this, u);
            u.receiveDmg(attackDamage);
        }
    }
    // receive damage. Die if healthPoints below 0
    public void receiveDmg(int dmg) {
        if(healthPoints <= dmg) {
            this.die();
            return;
        } else {
            healthPoints = healthPoints + blockDmg - dmg;
        }
        
    }
    // Unit dies. Remove from map and turn queue
    public void die() {
        //print death
        Printer.printDeath(this);
        bat.getQueue().remove(this);
        if(map.getMap(position) == this) {
            map.setMap(null, position);
            map.eraseFrom(position, map.getLaneColor());
        }
    }
    
    // turn 
    public virtual void turn() {
        if(!checkAtack()) {
            checkMove();
        }
        extraTurn();
    }
    // override for non conventional units eg: healers
    public virtual void extraTurn() {

    }
    // constructor
    // called in battle.spawnUnit
    // isPl is used on class constructor
    public void constrUnit(Battle batt, int place) {
        // set map, battle and position. Add unit to queue
        this.bat = batt;
        position = place;
        map = batt.getMap();
        map.setMap(this, place);

        batt.getQueue().add(this);
    }
}