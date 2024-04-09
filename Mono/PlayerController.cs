using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfTheRoom;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;
    public GameObject playerObject;
    public TextMeshProUGUI orbCountText;
    public GameObject northPellet, southPellet, eastPellet, westPellet;
    public GameObject shopKeeper;
    public GameObject shopSpot;
    public bool amAtShop = false;



    private void turnOffExits()
    {
        this.northExit.gameObject.SetActive(false);
        this.southExit.gameObject.SetActive(false);
        this.eastExit.gameObject.SetActive(false);
        this.westExit.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.northExit.gameObject.SetActive(true);
        this.southExit.gameObject.SetActive(true);
        this.eastExit.gameObject.SetActive(true);
        this.westExit.gameObject.SetActive(true);
    }

    void Start()
    {
        this.shopKeeper.SetActive(false);
        this.turnOffExits();
        this.setPellets();
        this.middleOfTheRoom.SetActive(false);

        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;
            this.middleOfTheRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.northExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.southExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.westExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.eastExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("shop"))
            {
                this.gameObject.transform.position = this.shopKeeper.transform.position;
                this.gameObject.transform.LookAt(this.shopKeeper.transform.position);
            }
        }
        else
        {
            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            this.middleOfTheRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfTheRoom.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            print("Loading scene");
            MySingleton.thePlayer.getCurrentRoom().removePlayer(MySingleton.currentDirection);
            EditorSceneManager.LoadScene("DungeonRoom");
        }

        else if (other.CompareTag("power-pellet"))
        {
            MySingleton.pelletHitName = other.GetComponent<Collider>().gameObject.name;
            MySingleton.pelletHitDirection = MySingleton.pelletHitName.Substring(0, MySingleton.pelletHitName.Length - 6);
            this.amMoving = false;
            MySingleton.currentDirection = "?";
            EditorSceneManager.LoadScene("FightScene");

        }

        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            this.middleOfTheRoom.SetActive(false);
            this.turnOnExits();
            print("middle");
            this.amAtMiddleOfRoom = true;
            this.amMoving = false;
            MySingleton.currentDirection = "middle";
        }

        else if (other.CompareTag("shopSpot"))
        {
            print("shop");
            MySingleton.currentDirection = "?";
            amAtShop = true;
            this.amMoving = false;
        }
    }

    void Update()
    {
        orbCountText.text = "Orb Count: " + MySingleton.orbCount.ToString();
        if (fightController.lastFightOutcome.Equals("hero"))
        {
            heroWonFight(MySingleton.pelletHitDirection);
            fightController.lastFightOutcome = "";
        }

        else if (fightController.lastFightOutcome.Equals("monster"))
        {
            fightController.lastFightOutcome = "";
        }

        if (Input.GetKeyUp(KeyCode.A) && !this.amMoving)
        {
            this.shopKeeper.SetActive(true);
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "shop";
            this.gameObject.transform.LookAt(this.shopKeeper.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("north"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
        }

        if (MySingleton.currentDirection.Equals("shop"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.shopSpot.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.northExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.southExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.westExit.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.eastExit.transform.position, this.speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.Y) && amAtShop)
        {
            if (MySingleton.orbCount >= 1)
            {
                MySingleton.orbCount--;
                MySingleton.heroMaxHitPoints = MySingleton.heroMaxHitPoints + 2;
                print("Transaction Complete");
                amAtShop = false;
            }

            else
            {
                print("Sorry, incomplete payment! Try again after winnning a fight");
                amAtShop = false;
            }
        }

        if (Input.GetKeyUp(KeyCode.N) && amAtShop)
        {
            print("Come back later and keep exploring");
            amAtShop = false;
        }
    }

    private void setPellets()
    {
        Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
        if (!theCurrentRoom.hasPellet("north"))
        {
            this.northPellet.SetActive(false);

        }
        if (!theCurrentRoom.hasPellet("south"))
        {
            this.southPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("east"))
        {
            this.eastPellet.SetActive(false);
        }

        if (!theCurrentRoom.hasPellet("west"))
        {
            this.westPellet.SetActive(false);
        }
    }


    public void heroWonFight(string direction)
    {
        print(direction);
        if (direction.Equals("North"))
        {
            northPellet.SetActive(false);
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            theCurrentRoom.removePellet(northPellet.GetComponent<pelletController>().direction);
        }

        else if (direction.Equals("South"))
        {
            southPellet.SetActive(false);
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            theCurrentRoom.removePellet(southPellet.GetComponent<pelletController>().direction);
        }

        else if (direction.Equals("East"))
        {
            eastPellet.SetActive(false);
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            theCurrentRoom.removePellet(eastPellet.GetComponent<pelletController>().direction);
        }

        else if (direction.Equals("West"))
        {
            westPellet.SetActive(false);
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            theCurrentRoom.removePellet(westPellet.GetComponent<pelletController>().direction);
        }
        MySingleton.orbCount++;
    }
}