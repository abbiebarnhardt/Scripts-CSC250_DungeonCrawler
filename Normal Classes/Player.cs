using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player
{
    private string name;
    private int hp;
    private TextMeshProUGUI playerInfo;

    public Player(string name)
    {
        this.hp = (int)Random.Range(10.0f, 20.0f);
        this.name = name;
    }

    public void display()
    {
        Debug.Log(this.name + "-> HP: " + this.hp);
    }

    public int getHP()
    {
        return this.hp;
    }

    public string getName()
    {
        return this.name;
    }

}