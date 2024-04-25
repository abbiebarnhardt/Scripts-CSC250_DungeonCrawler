using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;

public class CryptoController : MonoBehaviour
{
        void Start()
        {
            // Path to the JSON file
            string jsonFilePath = "Assets/DataFiles/bitcoin.txt";

            // Read the JSON file
            string jsonData = File.ReadAllText(jsonFilePath);

            // Deserialize JSON data into CryptoData object
            Crypto cryptoData = JsonConvert.DeserializeObject<Crypto>(jsonData);

            // Use the deserialized data
            Debug.Log($"Name: {cryptoData.name}");
            Debug.Log($"Symbol: {cryptoData.symbol}");
            Debug.Log($"Price USD: {cryptoData.priceUsd}");
            // Add more properties as needed...
        }
    
}
