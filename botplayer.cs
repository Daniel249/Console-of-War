using System;

class Botplayer : Entity {
    Unit nextUnit;
    public void receiveOrder(Unit u) {
        nextUnit = u;
    }
    public override void runTurn() {
        if(nextUnit != null) {
            spawnUnit(nextUnit);
        }
        nextUnit = null;
    }
}
