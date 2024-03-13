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

    void Start()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (theCurrentRoom.hasExit("north"))
        {
            this.northBlock.SetActive(false);
        }

        if (MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.eastBlock.SetActive(false);
        }

        if (theCurrentRoom.hasExit("south"))
        {
            this.southBlock.SetActive(false);
        }

        if (theCurrentRoom.hasExit("west"))
        {
            this.westBlock.SetActive(false);
        }
    }
}
