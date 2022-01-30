using System.Collections.Generic;
using System.Collections;
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
    public GameObject stoneSprite;
    public Sprite stoneRuby;

    private List<string> nifraLines;
    private List<string> adaLines;
    private bool talkNifra;
    private bool talkAda;

    public bool hasStone;
    private bool canCollect;
    private bool canPutStone;
    private bool helpedNifra;
    private bool helpedAda;

    public GameObject nifraUI;
    public GameObject adaUI;

    public PlayerMovement playMove;

    void Start()
    {
        nifraLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Nifra.txt"));
        adaLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Ada.txt"));

        index = 0;
        textPopup.SetActive(false);
        hasStone = false;
        canPutStone = false;
        helpedAda = false;
        helpedNifra = false;
        nifraUI.SetActive(false);
        adaUI.SetActive(false);
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
            Debug.Log(index);


            textBox.GetComponentInChildren<TextMeshProUGUI>().text = nifraLines[index];

            if (!hasStone && index >= 6)
            {
                talkNifra = false;
            }
            else if (hasStone && index == nifraLines.Count)
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
            Debug.Log(index);

            textBox.GetComponentInChildren<TextMeshProUGUI>().text = adaLines[index];

            if (index >= adaLines.Count)
            {
                talkAda = false;
            }
        }

        if (canCollect && Input.GetKeyDown(KeyCode.E))
        {
            hasStone = true;
            Maguffin.SetActive(false);
        }

        if (canPutStone && Input.GetKeyDown(KeyCode.E))
        {
            hasStone = false;
            stoneSprite.SetActive(false);
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
        else if (other.CompareTag("stone") && hasStone)
        {
            textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to place the stone.";
            textPopup.SetActive(true);
            canPutStone = true;

            stoneSprite = other.gameObject;
            if (other.gameObject.name == "natureStone")
            {
                helpedNifra = true;
                StartCoroutine("nifraWin");
            }
            else
            {
                helpedAda = true;
                StartCoroutine("adaWin");
            }

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
    private IEnumerator nifraWin()
    {
        yield return new WaitForSeconds(2.0f);
        nifraUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private IEnumerator adaWin()
    {
        yield return new WaitForSeconds(2.0f);
        adaUI.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}


