using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
    public static string currentDirection = "?";
    public static Player thePlayer;
    public static Dungeon theDungeon = MySingleton.generateDungeon();
    public static Exit targetExit;
    public static int countFood;

    private static Dungeon generateDungeon()
    {
        Room r1 = new Room("R1");
        Room r2 = new Room("R2");
        Room r3 = new Room("R3");
        Room r4 = new Room("R4");
        Room r5 = new Room("R5");
        Room r6 = new Room("R6");

        r1.addExit("north", r2, true);
        r2.addExit("south", r1, true);
        r2.addExit("north", r3, true);
        r3.addExit("south", r2, true);
        r3.addExit("west", r4, true);
        r3.addExit("north", r6, true);
        r3.addExit("east", r5, true);
        r4.addExit("east", r3, true);
        r5.addExit("west", r3, true);
        r6.addExit("south", r3, true);

        Dungeon theDungeon = new Dungeon("the cross");
        theDungeon.setStartRoom(r1);
        MySingleton.thePlayer = new Player("Mike");
        theDungeon.addPlayer(MySingleton.thePlayer);
        return theDungeon;
    }

    public static void setTargetExit(Exit goalExit)
    {
        targetExit = goalExit; 
    }

}