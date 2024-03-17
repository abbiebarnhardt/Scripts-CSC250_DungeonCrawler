using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Room
{
    public string name;

    private Exit[] theExits = new Exit[4];
    private Player currentPlayer;
    public Room(string name)
    {
        this.name = name;
        this.currentPlayer = null;
    }

    public void addPlayer(Player thePlayer)
    {
        this.currentPlayer = thePlayer;
        this.currentPlayer.setCurrentRoom(this);
    }

    public bool hasExit(string direction)
    {
        for (int i = 0; i < 4; i++)
        {
            if (this.theExits[i] != null)
            {
                if (this.theExits[i].getDirection().Equals(direction))
                {
                    return true;
                }
            }
        }
        return false;
    }


    public void addExit(string direction, Room destinationRoom, bool foodOn)
    {
        Exit e = new Exit(direction, destinationRoom, foodOn);
        if (direction.Equals("north"))
        {
            this.theExits[0] = e;
        }
        if (direction.Equals("south"))
        {
            this.theExits[1] = e;
        }
        if (direction.Equals("east"))
        {
            this.theExits[3] = e;
        }
        if (direction.Equals("west"))
        {
            this.theExits[2] = e;
        }
    }
    public Exit[] getTheExits()
    {
        return theExits;
    }
    public string getRoomName()
    {
        return this.name;
    }

}
