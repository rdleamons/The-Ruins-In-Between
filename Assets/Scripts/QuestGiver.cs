using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;
    public Interact player;
    public GameObject textbox;
    //public CharacterController player;

    public void OfferQuest()
    {
        textbox.SetActive(true);
        textbox.GetComponent<TextMeshProUGUI>().text = quest.title + ": " + quest.description;
    }

    public void AcceptQuest()
    {
        //player.quest = quest;
    }
}
