// using System;
// clase del mapa
class Map {
    int size = 100;
    public int getSize() {
        return size;
    }
    // array de unidades de tamaño 200
    // cada espacio del array es null o una referancia a una unidad
    Unit[] line;
    
    // get unit in exact location of line
    public Unit getMap(int position) {
        if(position >= size||position <= 0) {
            return null;
        }
        Unit un = null;
        // si no es null en esa posicion, se le asigna a un
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
    public Map(int newSize) {
        size = newSize;
        line = new Unit[size];
    }
    public Map() {
        line = new Unit[size];
    }
    
}