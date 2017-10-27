// using System;
using System.Collections.Generic;
using System.Threading;
// Queue. executes each units turn
class TurnQ {
    // cronometer
    Cronometer gameClock;
    // the actual queue
    List <Unit> queue;
    // turn length
    int turnDuration = 50;
    // add unit to queue
    public void add(Unit u) {
        queue.Add(u);
    }
    public void remove(Unit u) {
        queue.Remove(u);
    }
    public Cronometer getGameClock() {
        return gameClock;
    }
    // modulo 30. at TurnQ.run()
    int timeUnit;
    // check if AS and turn coincide
    public bool modCounter(int AS) {
        if(timeUnit % AS == 0) {
            return true;
        }
        return false;
    }
    public bool run() {
    // iterate through copy of queue
    // if unit still on original queue run turn on unit
    // unit might have died or something idk
        List <Unit> copyq = new List <Unit> (queue);
        // end game
        if(copyq.Count == 0) {
            return false;
        }
        // turn Length
        Thread.Sleep(turnDuration);
        for(int i = 0; i < copyq.Count; i++) {
            Unit u = copyq[i];
            if(queue.Contains(u)) {
                // check if atackspeed 
                if(modCounter(u.getAS())) {
                    u.turn();
                }
            }
        }
        // unidad de tiempo ++
        getGameClock().passTime();
        return true;
    }
    
    // constructor
    public TurnQ(int turnDurat) {
        queue = new List<Unit>();
        gameClock = new Cronometer();
        timeUnit = 0;
        turnDuration = turnDurat;
    }
}
// pass of time and relations between time units
class Cronometer {
    int timeUnit;
    // 30 timeUnits
    int second;
    // 4 seconds
    int minute;
    // 3 Minutes
    int hour;

    //get set
    public int getTime() {
        return timeUnit;
    }
    // time conversion
    // timeUnit++ reset at 30
    public void passTime() {
        timeUnit++;
        if(timeUnit == 30) {
            timeUnit = 0;
            passSecond();
            Printer.justPrint("segundo + 1");
        }
    }
    public int getSeconds() {
        return second;
    }
    public void passSecond() {
        second++;
        if(second == 4) {
            second = 0;
            passMinute();
        }
    }
    public int getMinute() {
        return minute;
    }
    // spawn minions here
    public void passMinute() {
        Skript.spawnMinions();
        minute++;
        if(minute == 3) {
            minute = 0;
            passHour();
        }
    }
    public int getHour() {
        return hour;
    }
    public void passHour() {
        
    }
    
    // constructor
    public Cronometer() {
        timeUnit = 0;
    }
}

