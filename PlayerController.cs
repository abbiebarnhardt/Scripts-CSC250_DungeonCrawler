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
        this.turnOffExits();
        if (!MySingleton.currentDirection.Equals("?"))
        {
            if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.northExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
            else if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.southExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.westExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.eastExit.transform.position;
                this.amAtMiddleOfRoom = false;
            }
        }
      }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            EditorSceneManager.LoadScene("Scene One");
        }
        else if (other.CompareTag("middleOfTheRoom") && !MySingleton.currentDirection.Equals("?"))
        {
            this.amAtMiddleOfRoom = true;
        }

    }

    void Update()
    {
        if (this.amAtMiddleOfRoom)
        {
            amMoving = false;
            MySingleton.currentDirection =  "?";
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            Quaternion target = Quaternion.Euler(33, -125, 33);
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target, 5.0f);
            this.amAtMiddleOfRoom = false;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            Quaternion target = Quaternion.Euler(33, 45, 33);
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target, 5.0f);
            this.amAtMiddleOfRoom = false;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            Quaternion target = Quaternion.Euler(26, 143, 30);
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target, 5.0f);
            this.amAtMiddleOfRoom = false;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow) && !this.amMoving)
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            Quaternion target = Quaternion.Euler(33, -33, 33);
            this.gameObject.transform.rotation = Quaternion.Slerp(transform.rotation, target, 5.0f);
            this.amAtMiddleOfRoom = false;
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
