using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class theCollectionManager : MonoBehaviour
{
    public Material placeHolderMaterial, potionMaterial;
    public GameObject itemPrefab;
    private Vector3 startPosition;
    private int itemSpawned = 0;
    private int currentLeftPos = 0;
    private List<GameObject> theItemsGO = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(wait());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftArrow) && this.currentLeftPos <= this.theItemsGO.Count - 5)
        {
            //move everything left one item
            GameObject tempLeft = null, tempRight = null;

            //goes through our items and moves them appropriately and makes them visible/invisible as needed
            for (int i = 0; i < this.theItemsGO.Count; i++)
            {
                this.theItemsGO[i].transform.Translate(Vector3.left * 10.0f);
                if (i == this.currentLeftPos)
                {
                    tempLeft = this.theItemsGO[i];
                }

                if (i == this.currentLeftPos + 4)
                {
                    tempRight = this.theItemsGO[i];
                }
            }
            tempLeft.SetActive(false);
            tempRight.SetActive(true);
            this.currentLeftPos++;

        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) && this.currentLeftPos >= 1)
        {
            //move everything left one item
            GameObject tempLeft = null, tempRight = null;

            for (int i = 0; i < this.theItemsGO.Count; i++)
            {
                this.theItemsGO[i].transform.Translate(Vector3.right * 10.0f);
                if (i == this.currentLeftPos - 1)
                {
                    tempLeft = this.theItemsGO[i];
                }

                if (i == this.currentLeftPos + 3)
                {
                    tempRight = this.theItemsGO[i];
                }
            }
            tempLeft.SetActive(true);
            tempRight.SetActive(false);
            this.currentLeftPos--;

        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < pokemonAPI.numberOfPokemon; i++)
        {
            this.startPosition = new Vector3(-25f + (this.itemSpawned * 2.51f), .25f, 0f);
            GameObject newObect = Instantiate(this.itemPrefab, this.startPosition, Quaternion.identity);
            TextMeshPro tmp = newObect.transform.GetChild(0).GetComponent<TextMeshPro>();
            tmp.SetText("Item: " + pokemonAPI.pokemons[i].name + "\nURL: " + pokemonAPI.pokemons[i].url);
            newObect.transform.SetParent(this.gameObject.transform);
            newObect.transform.localPosition = this.startPosition;
            newObect.transform.localRotation = Quaternion.identity;
            if (this.itemSpawned >= 4)
            {
                newObect.SetActive(false);
            }
            this.itemSpawned++;
            this.theItemsGO.Add(newObect);
        }

        //read json file with serialization
        string jsonString = MySingleton.readJsonString();

        // Parse the JSON string
        RootObject root = JsonUtility.FromJson<RootObject>(jsonString);

    }
}