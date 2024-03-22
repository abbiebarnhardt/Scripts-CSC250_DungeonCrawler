
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

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
        this.turnOffExits();


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
        if (other.CompareTag("door") && SceneManager.GetActiveScene().name.Equals("Dungeon Scene"))
        {
            print("Loading scene");

            MySingleton.thePlayer.getCurrentRoom().removePlayer(MySingleton.currentDirection);
            EditorSceneManager.LoadScene("Dungeon Scene");
        }
        else if (other.CompareTag("power-pellet"))
        {

            other.gameObject.SetActive(false);
            Room theCurrentRoom = MySingleton.thePlayer.getCurrentRoom();
            theCurrentRoom.removePellet(other.GetComponent<pelletController>().direction);
            playerObject.transform.position = new Vector3(-12.9f, 23.3f, 7.8f);
            MySingleton.currentDirection = "?";

            EditorSceneManager.LoadScene("Fight Scene");
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
    }

    void Update()
    {
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
    }
}
