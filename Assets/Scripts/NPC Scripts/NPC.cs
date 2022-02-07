using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class NPC : MonoBehaviour
{
    public List<string> dialogue;
    public string npcName;

    public GameObject textbox;
    public int index;
    public int maxIndex;

    void Start()
    {
        index = 0;  
        npcName = this.name;
        loadLines();
    }

    public void loadLines()
    {
        dialogue = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/" + npcName + ".txt"));
    }

    public void nextLine()
    {
        if(index != maxIndex)
        {
            index++;
            textbox.GetComponentInChildren<TextMeshProUGUI>().text = dialogue[index];
        }
        
    }
}
