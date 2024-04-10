
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using TMPro;

public class ShopController : MonoBehaviour
{
    public TextMeshProUGUI playerTMP, itemTMP;

    // Start is called before the first frame update
    void Start()
    {
        this.updatePlayerTMP();
        this.itemTMP.text = "Item Cost: " + ItemsSingleton.cherryItemCost;
        print("Would you like to buy a powerup? It will increase your HP. It costs one orb. Press Right Shift to buy!");
    }

    private void updatePlayerTMP()
    {
        this.playerTMP.text = "Pellets: " + MySingleton.currentPellets + " (HP: " + MySingleton.thePlayer.getHP() + ")"; ;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightShift))
        {
            if (MySingleton.currentPellets >= ItemsSingleton.cherryItemCost)
            {
                if (MySingleton.currentPellets >= ItemsSingleton.cherryItemCost)
                {
                    MySingleton.currentPellets -= ItemsSingleton.cherryItemCost;
                    MySingleton.thePlayer.addHP(5);
                    this.updatePlayerTMP();
                    print("Item successfully purchased. Press escape to return to the dungeon");
                }
            }

            else
            {
                print("Insufficient funds. Please try again later. Press escape to return to the dungeon");
            }

        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            EditorSceneManager.LoadScene("DungeonRoom");
        }

    }
}
