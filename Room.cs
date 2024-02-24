using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Room
{
    private static int countOnes = 0;
    private static Room[] theRooms = new Room[100];
    private static int[] theExits = new int[4];
    public static int numRooms = 0;
    public static bool southOpen;
    public static bool northOpen;
    public static bool eastOpen;
    public static bool westOpen;
    public static bool repeat = false;

    public Room()
    {
    }

    public static void addRoom(Room r)
    {
        Room.theRooms[Room.numRooms] = r;
        Room.genExits(theExits);
        Room.numRooms++;
    }

    public static void loadOldRoom()
    {
    }



    public static void genExits(int[] theExits)
    {
        countOnes = 0;
        for (int i = 0; i < 4; i++)
        {
            theExits[i] = Random.Range(0, 2);
        }

        for (int i = 0; i < 4; i++)
        {
            if (theExits[i] == 1)
            {
                Room.countOnes++;
            }
        }

        if (Room.countOnes == 4)
        {
            Room.genExits(theExits);
        }
        else
        {
            return;
        }
    }

    public static int[] getTheExits()
    {
        return theExits;
    }
    public static Room[] getTheRooms()
    {
        return theRooms;
    }
}
