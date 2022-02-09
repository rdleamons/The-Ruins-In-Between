using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class InteractTest : MonoBehaviour
{
    public NPC npc;
    public TextMeshProUGUI speakerName;
    public GameObject textPopup;
    public GameObject Maguffin;
    public GameObject stoneSprite;
    public Sprite stoneRuby;

    public GameObject textBox;

    private bool canPutStone;
    public bool hasStone;
    private bool canCollect;
    private bool talkNPC;

    public GameObject nifraUI;
    public GameObject adaUI;

    public PlayerMovement playMove;

    void Start()
    {
        textPopup.SetActive(false);
        hasStone = false;
        canCollect = false;
        canPutStone = false;
        nifraUI.SetActive(false);
        adaUI.SetActive(false);
        //npc.npcImage.SetActive(false);
    }

    private void Update()
    {
        if (textBox.GetComponentInChildren<TextMeshProUGUI>().text == " " || textBox.GetComponentInChildren<TextMeshProUGUI>().text == "")
        {
            playMove.canMove = true;
            textBox.gameObject.SetActive(false);
            npc.npcImage.SetActive(false);
        }
        else
            textBox.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return) && talkNPC)
        {
            speakerName.text = npc.npcName;
            npc.nextLine();
        }

        if (talkNPC && Input.GetKeyDown(KeyCode.E))
        {
            if (hasStone)
            {
                npc.index = 7;
                npc.maxIndex = 14;
            }
            else
            {
                npc.index = 0;
                npc.maxIndex = 6;
            }

            npc.npcImage.SetActive(true);
            textPopup.SetActive(false);
            speakerName.text = npc.npcName;
            playMove.canMove = false;

            textBox.GetComponentInChildren<TextMeshProUGUI>().text = npc.dialogue[npc.index];
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

            StartCoroutine("Win");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            npc = other.gameObject.GetComponent<NPC>();
            speakerName.text = npc.npcName;
            textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to talk.";
            textPopup.SetActive(true);

            talkNPC = true;
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        textPopup.SetActive(false);
        if (other.CompareTag("NPC"))
            talkNPC = false;
        else if (other.CompareTag("pickup"))
            canCollect = false; 
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(2.0f);

        if (stoneSprite.name == "natureStone")
            nifraUI.SetActive(true);
        else if (stoneSprite.name == "techStone")
            adaUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}


