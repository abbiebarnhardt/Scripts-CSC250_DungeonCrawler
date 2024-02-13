using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject destinationGO;
    public GameObject player;
    public float speed = 1.0f;
    private Transform target;

    void Awake()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(destinationGO);
    }
    void Start()
    {
        target = destinationGO.transform;
    }

    // Update is called once per frame
    private void Update()
    {
        var step = speed * Time.deltaTime;
        if (target != null)
        {
            
            if (((transform.position.x > target.transform.position.x) || (transform.position.x < target.transform.position.x)) && ((transform.position.z > target.transform.position.z) || (transform.position.z < target.transform.position.z)))
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, step);
            }
        }

        else
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0f, 0f, 0f), step);
        }
    }

}
