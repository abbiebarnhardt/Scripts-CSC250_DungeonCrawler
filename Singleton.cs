using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySingleton
{
    public static string currentDirection = "?";
    private static Room[] theRooms = new Room[100];
    private static int[] theExits = new int[4];
    private static int numRooms = 0;
    private static int countOnes = 0;
    public static bool amAtMiddleOfRoom = false;

    public static void addRoom(Room r)
    {
        MySingleton.theRooms[numRooms] = r;
        MySingleton.numRooms++;
        MySingleton.genExits(theExits);
    }

    public static void genExits(int[] theExits)
    {
        for (int i = 0; i < 4; i++)
        {
            theExits[i] = Random.Range(0,2);
        }

        for (int i = 0; i < 4; i++)
        {
            if (theExits[i] == 1)
            {
                MySingleton.countOnes++;
            }
        }

       if (MySingleton.countOnes ==4)
        {
            MySingleton.genExits(theExits);
        }
        else
        {
            return;
        }
    }

    public static int[] getExits()
    {
        return theExits;
    }
}