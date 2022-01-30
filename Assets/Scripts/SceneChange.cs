using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;
    public Scene currentScene;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "UnderConstruction")
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
    }

    public void changeScene()
    {
        SceneManager.LoadScene(scene);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            SceneManager.LoadScene(scene);
        }
    }
}
