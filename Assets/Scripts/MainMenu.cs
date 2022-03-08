using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsUI;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        creditsUI.SetActive(false);
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Village");
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
