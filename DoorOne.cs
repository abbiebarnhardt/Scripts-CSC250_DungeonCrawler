using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class DoorOne : MonoBehaviour
{
    public GameObject destinationGO;
    public GameObject player;
    public GameObject destinationGO2;


    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -player.transform.position.z);
        EditorSceneManager.LoadScene("Scene Two");
        EditorSceneManager.MoveGameObjectToScene(gameObject, EditorSceneManager.GetSceneByName("Scene Two"));

    }

}
