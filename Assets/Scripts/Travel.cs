using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Travel : MonoBehaviour
{
    public Player player;
    public string scene;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && player.canTravel)
        {
            SceneManager.LoadScene(scene);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            player.textPopup.SetActive(true);
            player.textPopup.GetComponent<TextMeshPro>().text = "Press 'E' to travel.";
            player.canTravel = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.textPopup.SetActive(false);
        player.canTravel = false;
    }
}
