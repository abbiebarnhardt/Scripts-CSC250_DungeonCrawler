using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerOneController : MonoBehaviour
{
    // Start is called before the first frame update
    MySingleton one;
    Player thePlayer;
    public TextMeshPro playerInfo;
    public GameObject destinationGO;
    public float speed = 1.0f;
    private Transform target;

    public void setInfo()
    {
        //Vector3.moveTowards
        playerInfo.text = "Name: " + this.thePlayer.getName().ToString() + " HP: " + this.thePlayer.getHP().ToString();
        var step = speed * Time.deltaTime; // calculate distance to move
        target = destinationGO.transform;



    }


    void Start()
    {
        //one = new MySingleton('O');
        //print("PlayerOne:");

        this.thePlayer = new Player("Mike");
        setInfo();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.thePlayer.display();
        /*
        int temp = one.countUp();
        if (temp != -1)
        {
            print("PlayerOne: " + temp);
        }
        */
    }

    private void Update()
    {
        var step = speed * Time.deltaTime; // calculate distance to move

        if ((transform.position.x > target.transform.position.x + .55) || (transform.position.x < target.transform.position.x - .55))
        {
            if ((transform.position.z > target.transform.position.z + .35) || (transform.position.z < target.transform.position.z - .35))
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
    }



}
