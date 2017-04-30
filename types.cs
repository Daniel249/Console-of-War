using System;

class Warrior : Unit {
    public Warrior(bool isPl) {
        isPlayer = isPl;
        idleCode = "L";
        hitCode = "l";
        attackDamage = 20;
        attackRange = 1;
        aoeRange = 0;
        atackSpeed = 1;
        moveRange = 1;
        healthPoints = 100;
        blockDmg = 5;
        tipo = "warrior";
        hash = hashCounter;
        hashCounter++;
        // test
        Console.WriteLine("warrior {0} has entered team {1}",
        hash, isPl);
    }
}
class Archer : Unit {
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
        tipo = "archer";
        hash = hashCounter;
        hashCounter++;
        // test
        Console.WriteLine("archer {0} has entered team {1}",
        hash, isPl);
    }
}