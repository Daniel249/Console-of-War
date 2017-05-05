// using System;
// map class
class Map {
    int size = 100;
    public int getSize() {
        return size;
    }
    // unit array size 200
    // either reference or null
    Unit[] line;
    
    // get unit in exact location of line
    public Unit getMap(int position) {
        if(position >= size||position <= 0) {
            return null;
        }
        Unit un = null;
        // assign to un if not null
        if(line[position] != null) {
            un = line[position];
        }
        return un;
    }
    // set unit u in in line[num]
    public void setMap(Unit u, int num) {
        if(num >= size||num <= 0) {
            return;
        }
        line[num] = u;
    }
    // constructor 
    public Map(int newSize) {
        size = newSize;
        line = new Unit[size];
    }
    public Map() {
        line = new Unit[size];
    }
    
}