using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject textBox;
    private int index;
    public GameObject textPopup;

    private List<string> lines;

    void Start()
    {
        lines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Intro.txt"));
        index = 0;
        textBox.SetActive(true);
        textBox.GetComponent<TextMeshProUGUI>().text = lines[0];
        textPopup.SetActive(false);
    }
    private void Update()
    {
        if (textBox.GetComponent<TextMeshProUGUI>().text == " ")
        {
            textBox.gameObject.SetActive(false);
        }
        else
        {
            textBox.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            index++;
            textBox.GetComponent<TextMeshProUGUI>().text = lines[index];
        }

        if (index == lines.Count)
        {
            textBox.GetComponent<TextMeshProUGUI>().text = " ";
        }

        //if (index >= lines.Count)
          //  index = lines.Count;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to talk."; 
            textPopup.SetActive(true);
        }
    }
}
