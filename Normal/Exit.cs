using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit
{
    private string direction;
    private Room destinationRoom;
    private bool foodOn = true;

    public Exit(string direction, Room destinationRoom, bool foodOn)
    {
        this.direction = direction;
        this.destinationRoom = destinationRoom;
        this.foodOn = foodOn;
    }

    public string getDirection()
    {
        return this.direction;
    }

    public Room getDestinationRoom()
    {
        return this.destinationRoom;
    }

    public void setFood(bool foodOn)
    {
        this.foodOn = foodOn;
    }

    public bool getFoodOn()
    {
        return this.foodOn;
    }
}
