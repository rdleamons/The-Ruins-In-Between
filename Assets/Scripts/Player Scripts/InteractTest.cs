using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class InteractTest : MonoBehaviour
{
    public NPC npc;
    public TextMeshProUGUI speakerName;
    private int index;
    public GameObject textPopup;
    public GameObject Maguffin;
    public GameObject stoneSprite;
    public Sprite stoneRuby;

    public GameObject textBox;

    public bool hasStone;
    private bool talkNPC;

    public GameObject nifraUI;
    public GameObject adaUI;

    public PlayerMovement playMove;

    void Start()
    {
        index = 0;
        textPopup.SetActive(false);
        hasStone = false;
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
            textPopup.SetActive(false);
            speakerName.text = npc.npcName;
            if (hasStone)
                index = 7;
            else
                index = 0;

            playMove.canMove = false;

            textBox.GetComponentInChildren<TextMeshProUGUI>().text = npc.dialogue[npc.index];
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


