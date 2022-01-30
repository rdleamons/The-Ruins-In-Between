using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class Interact : MonoBehaviour
{
    public GameObject textBox;
    public TextMeshProUGUI speakerName;
    private int index;
    public GameObject textPopup;
    public GameObject Maguffin;

    private List<string> nifraLines;
    private List<string> adaLines;
    private bool talkNifra;
    private bool talkAda;

    public bool hasStone;
    private bool canCollect;

    public PlayerMovement playMove;

    void Start()
    {
        nifraLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Nifra.txt"));
        adaLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Ada.txt"));

        index = 0;
        textPopup.SetActive(false);
        hasStone = false;
    }

    private void Update()
    {
        if (textBox.GetComponentInChildren<TextMeshProUGUI>().text == " " || textBox.GetComponentInChildren<TextMeshProUGUI>().text == "")
        {
            playMove.canMove = true;
            textBox.gameObject.SetActive(false);
        }
        else
            textBox.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return) && talkNifra)
        {
            speakerName.text = "Nifra";
            index++;
            textBox.GetComponentInChildren<TextMeshProUGUI>().text = nifraLines[index];
        }
        if (Input.GetKeyDown(KeyCode.Return) && talkAda)
        {
            speakerName.text = "A.D.A.";
            index++;
            textBox.GetComponentInChildren<TextMeshProUGUI>().text = adaLines[index];
        }

        if (talkNifra && Input.GetKeyDown(KeyCode.E))
        {
            textPopup.SetActive(false);
            speakerName.text = "Nifra";
            if (hasStone)
                index = 7;
            else
                index = 0;

            playMove.canMove = false;
            
            textBox.GetComponentInChildren<TextMeshProUGUI>().text = nifraLines[index];

            if (!hasStone && index >= 6)
            {
                talkNifra = false;
            }
            else if(hasStone && index == nifraLines.Count)
            {
                talkNifra = false;
            }
        }
        if (talkAda && Input.GetKeyDown(KeyCode.E))
        {
            textPopup.SetActive(false);
            speakerName.text = "A.D.A.";
            if (hasStone)
                index = 6;
            else
                index = 0;
            playMove.canMove = false;
            
            textBox.GetComponentInChildren<TextMeshProUGUI>().text = adaLines[index];

            if (index >= adaLines.Count)
            {
                talkAda = false;
            }
        }

        if(canCollect && Input.GetKeyDown(KeyCode.E))
        {
            Maguffin.SetActive(false);
            hasStone = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to talk."; 
            textPopup.SetActive(true);

            if (other.gameObject.name == "Nifra")
            {
                talkNifra = true;
            }
            else if (other.gameObject.name == "Ada")
            {
                talkAda = true;
            }
        }
        else if (other.CompareTag("pickup"))
        {
            textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to pick up.";
            textPopup.SetActive(true);
            canCollect = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        textPopup.SetActive(false);
        //speakerName.text = "";
        if (other.CompareTag("NPC"))
        {
            talkNifra = false;
            talkAda = false;
        }
        else if (other.CompareTag("pickup"))
        {
            canCollect = false;
        }
    }
}
