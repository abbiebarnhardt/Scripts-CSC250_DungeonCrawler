using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonController : MonoBehaviour
{
    public GameObject southBlock;
    public GameObject northBlock;
    public GameObject eastBlock;
    public GameObject westBlock;
    public static bool southOpen;
    public static bool northOpen;
    public static bool eastOpen;
    public static bool westOpen;

    // Start is called before the first frame update
    void Start()
    {
        Room r = new Room("A room");
        MySingleton.addRoom(r);
        turnOffBlocks();


        for(int i = 0; i<4;i++)
        {
            print(MySingleton.getExits()[i]);
        }
    }

    public void turnOnBlocks()
    {
        this.northBlock.gameObject.SetActive(true);
        this.southBlock.gameObject.SetActive(true);
        this.eastBlock.gameObject.SetActive(true);
        this.westBlock.gameObject.SetActive(true);
    }

    public void turnOffBlocks()
    {
        this.northBlock.gameObject.SetActive(false);
        this.southBlock.gameObject.SetActive(false);
        this.eastBlock.gameObject.SetActive(false);
        this.westBlock.gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

        if (MySingleton.currentDirection.Equals("?"))
        {
            turnOnBlocks();
            if (MySingleton.getExits()[0] == 0)
            {
                southBlock.SetActive(false);
                DungeonController.southOpen = true;
            }
            if (MySingleton.getExits()[1] == 0)
            {
                northBlock.SetActive(false);
                DungeonController.northOpen = true;
            }
            if (MySingleton.getExits()[2] == 0)
            {
                eastBlock.SetActive(false);
                DungeonController.eastOpen = true;
            }
            if (MySingleton.getExits()[3] == 0)
            {
                westBlock.SetActive(false);
                DungeonController.westOpen = true;
            }
        }

        if (MySingleton.currentDirection.Equals("middle"))
        {
            turnOnBlocks();
            if (MySingleton.getExits()[0] == 0)
            {
                southBlock.SetActive(false);
                DungeonController.southOpen = true;
            }
            if (MySingleton.getExits()[1] == 0)
            {
                northBlock.SetActive(false);
                DungeonController.northOpen = true;
            }
            if (MySingleton.getExits()[2] == 0)
            {
                eastBlock.SetActive(false);
                DungeonController.eastOpen = true;
            }
            if (MySingleton.getExits()[3] == 0)
            {
                westBlock.SetActive(false);
                DungeonController.westOpen = true;
            }
        }
    }
}
