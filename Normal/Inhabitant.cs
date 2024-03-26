
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;

    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
    }
}
