using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{
    public GameObject textBox;
    private int index;

    private List<string> lines;

    void Start()
    {
        lines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Intro.txt"));
        index = 0;
        textBox.SetActive(true);
        textBox.GetComponent<TextMeshProUGUI>().text = lines[0];
    }
    private void Update()
    {
        if (textBox.GetComponent<TextMeshProUGUI>().text == "")
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
            textBox.GetComponent<TextMeshProUGUI>().text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("NPC"))
        {
            textBox.GetComponent<TextMeshProUGUI>().text = "Press 'E' to talk.";
            Debug.Log("NPC.");
        }
    }
}
