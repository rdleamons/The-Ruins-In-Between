using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class NPCInteract : MonoBehaviour
{
    //public Interact PlayerInteract;
    public GameObject textBox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            textBox.gameObject.SetActive(true);
            textBox.GetComponent<TextMeshProUGUI>().text = "Press 'E' to talk.";
        }
    }
}
