using System;

class Warrior : Unit {
    new string tipo = "warrior";
    public Warrior(bool isPl) {
        isPlayer = isPl;
        idleCode = "L";
        hitCode = "l";
        attackDamage = 20;
        // melee 
        attackRange = 1;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 100;
        blockDmg = 5;
        
        hash = hashCounter;
        hashCounter++;
        
        Printer.printSpawn(this);
    }
}
class Archer : Unit {
    new string tipo = "archer";
    public Archer(bool isPl) {
        isPlayer = isPl;
        if(isPl) {
            idleCode = ")";
        } else {
            idleCode = "(";
        }
        hitCode = "l";
        attackDamage = 10;
        attackRange = 8;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 60;
        blockDmg = 0;

        hash = hashCounter;
        hashCounter++;
        
        Printer.printSpawn(this);
    }
}
class Lancer : Unit {
    new string tipo = "lancer";
    public Lancer(bool isPl) {
        isPlayer = isPl;
        idleCode = "+";
        hitCode = "+";
        attackDamage = 19;
        attackRange = 1;
        aoeRange = 1;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 90;
        blockDmg = 10;

        hash = hashCounter;
        hashCounter++;

        Printer.printSpawn(this);
    }
}
class casterMinion : Unit {
    new string tipo = "cminion";
    public casterMinion(bool isPl) {
        isPlayer = isPl;
        idleCode = "-";
        hitCode = "-";
        attackDamage = 5;
        attackRange = 3;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 80;
        blockDmg = 0;

        hash = hashCounter;
        hashCounter++;

        Printer.printSpawn(this);
    }
}
class meleeMinion : Unit {
    new string tipo = "mminion";
    public meleeMinion(bool isPl) {
        isPlayer = isPl;
        idleCode = "|";
        hitCode = "|";
        attackDamage = 4;
        attackRange = 1;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 100;
        blockDmg = 0;

        hash = hashCounter;
        hashCounter++;

        Printer.printSpawn(this);
    }
}
class siegeMinion : Unit {
    new string tipo = "sminion";
    public siegeMinion(bool isPl) {
        isPlayer = isPl;
        idleCode = "V";
        hitCode = "V";
        attackDamage = 10;
        attackRange = 2;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 100;
        blockDmg = 2;

        hash = hashCounter;
        hashCounter++;

        Printer.printSpawn(this);
    }
}
class superMinion : Unit {
    new string tipo = "superminion";
    public superMinion(bool isPl) {
        isPlayer = isPl;
        idleCode = "W";
        hitCode = "W";
        attackDamage = 10;
        attackRange = 2;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 100;
        blockDmg = 2;

        hash = hashCounter;
        hashCounter++;

        Printer.printSpawn(this);
    }
}