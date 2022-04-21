using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class InteractTest : MonoBehaviour
{
    public NPC npc;
    public Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        // Lantern control
        if (player.hasLantern)
        {
            player.lantern.SetActive(true);
        }
        else if (!player.hasLantern)
        {
            player.lantern.SetActive(false);
        }

        if (player.textBox.GetComponentInChildren<TextMeshProUGUI>().text == " " || player.textBox.GetComponentInChildren<TextMeshProUGUI>().text == "")
        {
            player.playMove.canMove = true;
            player.textBox.gameObject.SetActive(false);
            npc.npcImage.SetActive(false);
        }
        else
            player.textBox.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.Return) && player.talkNPC)
        {
            player.speakerName.text = npc.npcName;
            npc.nextLine();
        }

        if (player.talkNPC && Input.GetKeyDown(KeyCode.E))
        {
            if(npc.name == "Nifra" || npc.name == "Ada")
            {
                if (player.hasStone)
                {
                    npc.index = 7;
                    npc.maxIndex = 14;
                }
                else
                {
                    npc.index = 0;
                    npc.maxIndex = 6;
                }
            }

            if(npc.name == "NPC")
            {
                if (!player.hasLantern)
                {
                    npc.index = 0;
                    npc.maxIndex = 3;
                    player.hasLantern = true;
                    PlayerPrefs.SetInt("hasLantern", player.hasLantern ? 1 : 0);
                    PlayerPrefs.Save();
                    
                }
                else
                {
                    npc.index = 4;
                    npc.maxIndex = 7;
                }
            }

            npc.npcImage.SetActive(true);
            player.textPopup.SetActive(false);
            player.speakerName.text = npc.npcName;
            player.playMove.canMove = false;

            player.textBox.GetComponentInChildren<TextMeshProUGUI>().text = npc.dialogue[npc.index];
        }

        if (player.canCollect && Input.GetKeyDown(KeyCode.E))
        {
            player.hasStone = true;
            player.Maguffin.SetActive(false);
            StartCoroutine("ShowObject");
        }

        if (player.canPutStone && Input.GetKeyDown(KeyCode.E))
        {
            player.hasStone = false;
            player.stoneSprite.SetActive(false);

            StartCoroutine("Win");
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            npc = other.gameObject.GetComponent<NPC>();
            player.speakerName.text = npc.npcName;
            player.textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to talk.";
            player.textPopup.SetActive(true);

            player.talkNPC = true;
        }
        else if (other.CompareTag("pickup"))
        {
            player.textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to pick up.";
            player.textPopup.SetActive(true);
            player.canCollect = true;

        }
        else if (other.CompareTag("stone") && player.hasStone)
        {
            player.textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to place the stone.";
            player.textPopup.SetActive(true);
            player.canPutStone = true;

            player.stoneSprite = other.gameObject;
        }
        else if (other.CompareTag("bounds"))
        {
            if(!player.hasLantern)
            {
                player.speakerName.text = "Cyrus";
                player.textBox.GetComponentInChildren<TextMeshProUGUI>().text = "It's too dark. I should find a lantern.";
            }
            else
            {
                player.textPopup.GetComponent<TextMeshPro>().text = "Press 'L' to use your lantern.";
                player.textPopup.SetActive(true);
                other.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        player.textPopup.SetActive(false);
        player.textBox.GetComponentInChildren<TextMeshProUGUI>().text = "";
        if (other.CompareTag("NPC"))
            player.talkNPC = false;
        else if (other.CompareTag("pickup"))
            player.canCollect = false; 
    }

    private IEnumerator ShowObject()
    {
        player.playMove.canMove = false;
        player.objectUI.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        player.objectUI.SetActive(false);
        player.playMove.canMove = false;
    }

    private IEnumerator Win()
    {
        yield return new WaitForSeconds(2.0f);

        if (player.stoneSprite.name == "natureStone")
            player.nifraUI.SetActive(true);
        else if (player.stoneSprite.name == "techStone")
            player.adaUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

}


