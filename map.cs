using System;
// map class
class Map {
    int size = 100;
    public int getSize() {
        return size;
    }
    int location_x;
    int location_y;
    ConsoleColor laneColor = ConsoleColor.Gray;
    public ConsoleColor getLaneColor() {
        return laneColor;
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
    // erase from last frame
    public void eraseFrom(int position, ConsoleColor bcolor) {
        Terminal.PrintText(" ", location_x + position, location_y, bcolor);
    }
    //print to next frame
    public void printTo(int position, string code, ConsoleColor fcolor, ConsoleColor bcolor) {
        Terminal.PrintText(code, location_x + position, location_y, fcolor);
    }
    // change curent frame to next frame
    public void updateFrame(int erase_pos, int print_pos, string code, 
    ConsoleColor erase_bcolor, ConsoleColor print_bcolor, ConsoleColor print_fcolor) 
    {
        eraseFrom(erase_pos, erase_bcolor);
        printTo(print_pos, code, print_fcolor, print_bcolor);
    }
    // constructor 
    public Map(int newSize, int pos_x, int pos_y) {
        size = newSize;
        line = new Unit[size];
        location_x = pos_x;
        location_y = pos_y;
    }
    public Map() {
        line = new Unit[size];
    }
    
}