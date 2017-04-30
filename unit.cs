using System;
using System.Collections.Generic;

// clase de los Unidades
// cada uno de los mansitos
class Unit {
    // true for player1
    // define direccion en la que caminan
    protected bool isPlayer; 
    // visual de la unidad en idle
    protected string idleCode;
    // visual del unidad cuando recibe daño
    protected string hitCode;
    // daño que inflige por ataque
    protected int attackDamage;
    // 1 for melee
    protected int attackRange;
    // 1 for each turn
    protected int atackSpeed;
    // 0 for single target
    protected int aoeRange;
    // move range
    protected int moveRange;
    // vida maxima
    protected int healthPoints;
    // block
    protected int blockDmg;
    protected string tipo;
    protected int hash;
    protected static int hashCounter = 0;

    // mapa en el que esta. por si en el futuro agrego la posibilidad
    // de jugar en varios mapas a la vez
    Map map;
    Battle bat;
    // posicion en el mapa
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
    public int getHash() {
        return hash;
    }
    public string getClass() {
        return tipo;
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
    // checkea si hay un enemigo en rango de ataque
    // checkAttack comes before check move.
    // so it will return false if outOfBound
    public bool checkAtack() {
        int dir = getDirection();
        for(int i = 1; i <= attackRange; i++) {
            // if no hay nada a distancia i en direccion dir desde la position de la unidad
            // targets cercanos tienen prioridad
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
    // checkea si hay un espacio vacio en rango de movimiento
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
        map.setMap(this, newPosition);
        map.setMap(null, position);
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
            // test
            Printer.printAttack(this, u);
            u.receiveDmg(attackDamage);
            // register dmg received 
            // Console.WriteLine("{0} {1} received {2} dmg", u.getClass(), u.getHash(),attackDamage);
            // Console.WriteLine("\t \t \t {0} hits {1} for {2}",
            // this.tipo + hash, u.tipo + u.hash, attackDamage);
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
        Printer.printDeath(this);
        if(map.getMap(position) == this) {
            bat.getQueue().remove(this);
            map.setMap(null, position);
        }
        // test
        // Console.WriteLine("\t \t \t {0} dies", tipo + hash);
    }
    
    // turno de cada unidad
    public virtual void turn() {
        if(!checkAtack()) {
            checkMove();
        }
        extraTurn();
    }
    // se puede override para turnos de unidades no convencionales ej:healers
    public virtual void extraTurn() {

    }
    // constructor
    // called in battle.spawnUnit
    // isPl is used on class constructor
    public void constrUnit(Battle batt, int place) {
        // set map and position unit. Add unit to queue
        this.bat = batt;
        position = place;
        map = batt.getMap();
        map.setMap(this, place);
        batt.getQueue().add(this);
    }
}