using UnityEngine;

[System.Serializable]
public class Pokemon
{
    public string name { get; set; }
    public string url { get; set; }

    public Pokemon(string name, string url)
    {
        this.name = name;
        this.url = url;
    }

    public void display()
    {
        Debug.Log($"Name: {this.name}, URL: {this.url}");
    }
}

[System.Serializable]
public class Results
{
    public int count;
    public string next;
    public string previous;
    public Pokemon[] results;
}
