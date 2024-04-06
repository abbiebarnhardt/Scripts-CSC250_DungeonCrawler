
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject northDoor, southDoor, eastDoor, westDoor;

    public DungeonController ()
    {

    }
    void Start()
    { 
        this.setDoors();
        
    }


    //all doors are on by default, so turn off the doors that should not be there.
    private void setDoors()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("north"))
        {
            northDoor.SetActive(false);

        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("east"))
        {
            this.eastDoor.SetActive(false);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westDoor.SetActive(false);
        }
    }

    //all pellets are on by default, so turn off the ones that shouldnt be there
   
    // Update is called once per frame
    void Update()
    {

    }



}