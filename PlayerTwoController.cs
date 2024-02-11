using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerTwoController : MonoBehaviour
{
    Player thePlayer;
    MySingleton two;
    public TextMeshPro playerInfo;

    public void setInfo()
    {
        playerInfo.text = "Name: " + this.thePlayer.getName().ToString() + " HP: " + this.thePlayer.getHP().ToString();
    }

    void Start()
    {
        this.thePlayer = new Player("Dave");
        setInfo();
        // two = new MySingleton('E');
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.thePlayer.display();
        /*
        int temp = two.countUp();
        if (temp != -1)
        {
            print("PlayerTwo: " + temp);
        }
        */
    }



}
