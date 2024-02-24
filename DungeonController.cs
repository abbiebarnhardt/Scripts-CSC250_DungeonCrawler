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


    // Start is called before the first frame update
    void Start()
    {
        turnOffBlocks();
        StartCoroutine(wait());

        /*for (int i = 0; i < 4; i++)
        {
            print(Room.getTheExits()[i]);
        }*/
    }

    IEnumerator wait()
    {
        yield return new WaitUntil(() => MySingleton.currentDirection.Equals("?") || MySingleton.currentDirection.Equals("middle")) ;
        StartCoroutine(wait2());
    }
    IEnumerator wait2()
    {
        yield return new WaitUntil(() => MySingleton.chosen);

        print(Room.numRooms);
        if (MySingleton.currentDirection.Equals(MySingleton.doorExited))
        {
            print("Repeat");
            Room.loadOldRoom();
        }
        else
        {
            print("New Room");
            Room r = new Room();
            Room.addRoom(r);
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
        if(!Room.repeat)
        {
            if (MySingleton.currentDirection.Equals("middle") || MySingleton.currentDirection.Equals("?"))
            {
                turnOnBlocks();
                if (Room.getTheExits()[0] == 0 || MySingleton.doorExited.Equals("south"))
                {
                    southBlock.SetActive(false);
                    Room.southOpen = true;
                }

                if (Room.getTheExits()[1] == 0 || MySingleton.doorExited.Equals("north"))
                {
                    northBlock.SetActive(false);
                    Room.northOpen = true;
                }

                if (Room.getTheExits()[2] == 0 || MySingleton.doorExited.Equals("east"))
                {
                    eastBlock.SetActive(false);
                    Room.eastOpen = true;
                }

                if (Room.getTheExits()[3] == 0 || MySingleton.doorExited.Equals("west"))
                {
                    westBlock.SetActive(false);
                    Room.westOpen = true;
                }
            }
        }
        else
        {
            if (MySingleton.currentDirection.Equals("middle") || MySingleton.currentDirection.Equals("?"))
            {
                turnOnBlocks();
                if (Room.getTheExits()[0] == 0 || MySingleton.doorExited.Equals("south"))
                {
                    southBlock.SetActive(false);
                    Room.southOpen = true;
                }

                if (Room.getTheExits()[1] == 0 || MySingleton.doorExited.Equals("north"))
                {
                    northBlock.SetActive(false);
                    Room.northOpen = true;
                }

                if (Room.getTheExits()[2] == 0 || MySingleton.doorExited.Equals("east"))
                {
                    eastBlock.SetActive(false);
                    Room.eastOpen = true;
                }

                if (Room.getTheExits()[3] == 0 || MySingleton.doorExited.Equals("west"))
                {
                    westBlock.SetActive(false);
                    Room.westOpen = true;
                }
            }
        }

    }
}
