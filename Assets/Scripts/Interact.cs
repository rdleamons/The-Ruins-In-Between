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
    public SpriteRenderer backgroundToChange;
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
        if (textBox.GetComponent<TextMeshProUGUI>().text == " " || textBox.GetComponent<TextMeshProUGUI>().text == "")
        {
            playMove.canMove = true;
            textBox.gameObject.SetActive(false);
        }
        else
            textBox.gameObject.SetActive(true);


        if (Input.GetKeyDown(KeyCode.Return) && talkNifra)
        {
            Debug.Log(index);
            index++;
            textBox.GetComponent<TextMeshProUGUI>().text = nifraLines[index];
        }
        if (Input.GetKeyDown(KeyCode.Return) && talkAda)
        {
            Debug.Log(index);
            index++;
            textBox.GetComponent<TextMeshProUGUI>().text = adaLines[index];
        }

        if (talkNifra && Input.GetKeyDown(KeyCode.E))
        {
            index = 0;
            playMove.canMove = false;
            textPopup.GetComponent<TextMeshPro>().text = "Nifra";
            textBox.GetComponent<TextMeshProUGUI>().text = nifraLines[index];

            if (index == nifraLines.Count)
            {
                talkNifra = false;
            }
        }
        if (talkAda && Input.GetKeyDown(KeyCode.E))
        {
            index = 0;
            playMove.canMove = false;
            textPopup.GetComponent<TextMeshPro>().text = "Ada";
            textBox.GetComponent<TextMeshProUGUI>().text = adaLines[index];

            if (index >= adaLines.Count)
            {
                talkAda = false;
            }
        }

        if(canCollect && Input.GetKeyDown(KeyCode.E))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Maguffin.SetActive(false);
                //hasStone = true;
                backgroundToChange.color = Color.cyan;
            }
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
