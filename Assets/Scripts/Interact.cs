using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject textBox;
    private int index;
    private int convoIndex;
    public GameObject textPopup;

    private List<string> nifraLines;
    private List<string> adaLines;
    private bool talkNifra;
    private bool talkAda;

    void Start()
    {
        nifraLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Nifra.txt"));
        adaLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Ada.txt"));

        index = 0;
        textPopup.SetActive(false);
    }

    private void Update()
    {
        if (textBox.GetComponent<TextMeshProUGUI>().text == " ")
            textBox.gameObject.SetActive(false);
        else
            textBox.gameObject.SetActive(true);


        if (Input.GetKeyDown(KeyCode.Return) && talkNifra)
        {
            Debug.Log(index);
            textBox.GetComponent<TextMeshProUGUI>().text = nifraLines[index++];
        }

        if (talkNifra && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log(index);
            textPopup.SetActive(false);
            textBox.GetComponent<TextMeshProUGUI>().text = nifraLines[index];

            if (index >= nifraLines.Count)
                talkNifra = false;
            
        }
        else if (talkAda)
        {
            textPopup.SetActive(false);
            textBox.GetComponent<TextMeshProUGUI>().text = adaLines[index];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                NextLine(adaLines);
            }
        }
    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            index = 0;
            textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to talk."; 
            textPopup.SetActive(true);

            if (other.gameObject.name == "Nifra")
                talkNifra = true;
            else if (other.gameObject.name == "Ada")
                talkAda = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            //talkNifra = false;
            //talkAda = false;
            textPopup.SetActive(false);
        }
    }

    void NextLine(List<string> lines)
    {
        textBox.GetComponent<TextMeshProUGUI>().text = lines[index++];

        if(index == lines.Count)
        {
            talkNifra = false;
            talkAda = false;
        }
            
    }
}
