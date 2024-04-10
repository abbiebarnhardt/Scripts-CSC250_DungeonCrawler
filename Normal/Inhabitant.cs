using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Inhabitant
{
    protected string name;
    protected Room currentRoom;
    protected int hp, ac, maxHP;

    public Inhabitant(string name)
    {
        this.name = name;
        this.currentRoom = null;
        this.hp = Random.Range(10, 16);
        this.maxHP = this.hp;
        this.ac = Random.Range(8, 17);
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        this.currentRoom = r;
    }

    public void takeDamage(int damage)
    {
        this.hp = this.hp - damage;
    }

    public int getHP()
    {
        return this.hp;
    }

    public void addHP(int numHP)
    {
        if (numHP > 0)
        {
            this.hp += numHP;
            //this.hp = this.hp + numHP;
            //dont let our player have more than max hit points to protect against over healing
            if (this.hp > this.maxHP)
            {
                this.hp = this.maxHP;
            }
        }


    }

    public int getAC()
    {
        return this.ac;
    }
}