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
    public TextMeshProUGUI countFood;

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

    void SetCountFood()
    {
        countFood.text = "Count: " + MySingleton.countFood.ToString();
    }

    void Start()
    {
        this.turnOffExits();
        this.middleOfTheRoom.SetActive(false);
        SetCountFood();



        if (!MySingleton.currentDirection.Equals("?"))
        {
            MySingleton.thePlayer.setCurrentRoom(MySingleton.targetExit.getDestinationRoom());
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
        if (other.CompareTag("northFood"))
        {
            MySingleton.thePlayer.getCurrentRoom().getTheExits()[0].setFood(false);
            other.gameObject.SetActive(false);
            MySingleton.countFood++;
            SetCountFood();
        }
        else if (other.CompareTag("eastFood"))
        {
            MySingleton.thePlayer.getCurrentRoom().getTheExits()[3].setFood(false);
            other.gameObject.SetActive(false);
            MySingleton.countFood++;
            SetCountFood();
        }

        else if (other.CompareTag("southFood"))
        {
            MySingleton.thePlayer.getCurrentRoom().getTheExits()[1].setFood(false);
            other.gameObject.SetActive(false);
            MySingleton.countFood++;
            SetCountFood();
        }

        else if (other.CompareTag("westFood"))
        {
            MySingleton.thePlayer.getCurrentRoom().getTheExits()[2].setFood(false);
            other.gameObject.SetActive(false);
            MySingleton.countFood++;
            SetCountFood();
        }

        else if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Scene One");
        }

        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            this.middleOfTheRoom.SetActive(false);
            this.turnOnExits();

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

            MySingleton.setTargetExit(MySingleton.thePlayer.getCurrentRoom().getTheExits()[0]);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("south"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);

            MySingleton.setTargetExit(MySingleton.thePlayer.getCurrentRoom().getTheExits()[1]);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("west"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position);

            MySingleton.setTargetExit(MySingleton.thePlayer.getCurrentRoom().getTheExits()[2]);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && MySingleton.thePlayer.getCurrentRoom().hasExit("east"))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);

            MySingleton.setTargetExit(MySingleton.thePlayer.getCurrentRoom().getTheExits()[3]);

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
