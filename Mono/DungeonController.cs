using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DungeonController : MonoBehaviour
{
    public GameObject southBlock;
    public GameObject northBlock;
    public GameObject eastBlock;
    public GameObject westBlock;

    public GameObject southFood;
    public GameObject northFood;
    public GameObject westFood;
    public GameObject eastFood;

    void Start()
    {
        this.northFood.SetActive(false);
        this.eastFood.SetActive(false);
        this.southFood.SetActive(false);
        this.westFood.SetActive(false);


        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("north"))
        {
            this.northBlock.SetActive(false);
            if (MySingleton.thePlayer.getCurrentRoom().getTheExits()[0] != null && MySingleton.thePlayer.getCurrentRoom().getTheExits()[0].getFoodOn())
            {
                this.northFood.SetActive(true);
            }
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastBlock.SetActive(false);
            if ((MySingleton.thePlayer.getCurrentRoom().getTheExits()[3] != null && MySingleton.thePlayer.getCurrentRoom().getTheExits()[3].getFoodOn()))
            {
                this.eastFood.SetActive(true);
            }
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southBlock.SetActive(false);
            if (MySingleton.thePlayer.getCurrentRoom().getTheExits()[1] != null && MySingleton.thePlayer.getCurrentRoom().getTheExits()[1].getFoodOn())
            {
                this.southFood.SetActive(true);
            }
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westBlock.SetActive(false);
            if (MySingleton.thePlayer.getCurrentRoom().getTheExits()[2] != null && MySingleton.thePlayer.getCurrentRoom().getTheExits()[2].getFoodOn())
            {
                this.westFood.SetActive(true);
            }
        }
    }

}
