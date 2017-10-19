using System;
using System.Threading;
// class battle
// controls map unit and queue
class Battle {
    // references
    Map[] maps;
    TurnQ queue;
    Entity player;
    Entity nonPlayer;
    // get set
    public TurnQ getQueue() {
        return queue;
    }
    public Map getMap(int num) {
        return maps[num];
    }
    public Entity getPlayer(bool isPlayer) {
        if(isPlayer) {
            return player;
        } else {
            return nonPlayer;
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
            player.runTurn();
            nonPlayer.runTurn();
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
        player = new Player();
        nonPlayer = new Botplayer();
    }
}