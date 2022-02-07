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
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        textPopup.SetActive(false);
        if (other.CompareTag("NPC"))
        {
            talkNPC = false;
        }
    }

}


