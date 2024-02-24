using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject northExit;
    public GameObject southExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject middleOfRoom;
    private float speed = 5.0f;
    private bool amMoving = false;
    private bool amAtMiddleOfRoom = false;

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
        Rigidbody rb = this.gameObject.GetComponent<Rigidbody>();
        this.turnOffExits();
        this.middleOfRoom.SetActive(false);

        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.amMoving = true;
            this.middleOfRoom.SetActive(true);
            this.amAtMiddleOfRoom = false;

            if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.gameObject.transform.LookAt(this.southExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.gameObject.transform.LookAt(this.northExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.gameObject.transform.LookAt(this.eastExit.transform.position);
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.gameObject.transform.LookAt(this.westExit.transform.position);
            }
        }
        else
        {
            this.amMoving = false;
            this.amAtMiddleOfRoom = true;
            this.middleOfRoom.SetActive(false);
            this.gameObject.transform.position = this.middleOfRoom.transform.position;
        }
      }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            
            MySingleton.oldDirection = MySingleton.currentDirection;
            if (MySingleton.currentDirection.Equals("north"))
            {
                MySingleton.doorEntered = "north";
                MySingleton.doorExited = "south";
                MySingleton.chosen = true;
            }
            if (MySingleton.currentDirection.Equals("south"))
            {
                MySingleton.doorEntered = "south";
                MySingleton.doorExited = "north";
                MySingleton.chosen = true;
            }
            if (MySingleton.currentDirection.Equals("east"))
            {
                MySingleton.doorEntered = "east";
                MySingleton.doorExited = "west";
                MySingleton.chosen = true;
            }
            if (MySingleton.currentDirection.Equals("west"))
            {
                MySingleton.doorEntered = "west";
                MySingleton.doorExited = "east";
                MySingleton.chosen = true;
            }

            EditorSceneManager.LoadScene("Scene One");
        }
        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            MySingleton.oldDirection = MySingleton.currentDirection;
            this.middleOfRoom.SetActive(false);
            this.turnOnExits();
            this.amAtMiddleOfRoom = true;
            this.amMoving = false;
            MySingleton.currentDirection = "middle";
        }

    }

    void Update()
    {
        MySingleton.chosen = false;
        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving && Room.northOpen)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.northExit.transform.position);
            MySingleton.chosen = true;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving && Room.southOpen)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.southExit.transform.position);
            MySingleton.chosen = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving && Room.westOpen)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.westExit.transform.position );
            MySingleton.chosen = true;

        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving && Room.eastOpen)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.eastExit.transform.position);
            MySingleton.chosen = true;
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
