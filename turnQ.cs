// using System;
using System.Collections.Generic;
// Queue 
class TurnQ
{
    // the actual queue
    List <Unit> queue;
    // add unit to queue
    public void add(Unit u) {
        queue.Add(u);
    }
    public void remove(Unit u) {
        queue.Remove(u);
    }
    // modulo 30. at TurnQ.run()
    int counter;
    // check if AS and turn coincide
    public bool modCounter(int AS) {
        if(counter % AS == 0) {
            return true;
        }
        return false;
    }
    public void run() {
    // iterate through copy o queue
    // if unit still on original queue run turn on unit
    // unit might have died or something idk
        List <Unit> copyq = new List <Unit> (queue);
        for(int i = 0; i < copyq.Count; i++) {
            Unit u = copyq[i];
            if(queue.Contains(u)) {
                // check if atackspeed 
                if(modCounter(u.getAS())) {
                    u.turn();
                }
            }
        }
        // reset at 30
        counter++;
        if(counter == 30) {
            counter = 0;
        }
    }
    
    // constructor
    public TurnQ() {
        queue = new List<Unit>();
        counter = 0;
    }
}