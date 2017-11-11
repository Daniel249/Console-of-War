using System;
using System.Threading;
// class battle
// controls map unit and queue
class Battle {
    // references
    Map[] maps;
    TurnQ queue;
    Entity player_1;
    Entity player_2;
    // get set
    public TurnQ getQueue() {
        return queue;
    }
    public Map getMap(int num) {
        return maps[num];
    }
    public Entity getPlayer(bool isPlayer) {
        if(isPlayer) {
            return player_1;
        } else {
            return player_2;
        }
    }
    // run battle
    // controls when to stop
    public bool turn() {
        return queue.run();
    }
    // runs in Main until KeyAvailable and ReadKey.Key == Escape
    public void run() {
        bool check = true;
        while(check) {
            // stop battle
            if(!Skript.getContinueGame()) {
                endGame();
                break;
            }
            
            //ask for players turn
            player_1.runTurn();
            player_2.runTurn();
            // execute turn each loop
            turn();
            
        }
    }
    
    void endGame() {

    }
    // constructor
    public Battle(int turnLength, int midSize, int sideSize, int map_x, int map_y) {
        maps = new Map[3];
        maps[0] = new Map(sideSize, map_x - 1, map_y - 2);
        maps[1] = new Map(midSize, map_x, map_y);
        maps[2] = new Map(sideSize, map_x - 1, map_y + 2);
        queue = new TurnQ(turnLength);
        setUp();
        
    }
    // constructor helpers
    void setUp() {
        Skript.setBattle(this);
        player_1 = new Player();
        player_2 = new Botplayer();
    }
}