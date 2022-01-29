using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsUI;
    private bool creditsActive;

    private void Start()
    {
        creditsUI.SetActive(false);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Ruins");
    }

    public void Credits()
    {
        creditsUI.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsUI.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
