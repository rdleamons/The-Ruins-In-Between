using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI speakerName;
    public GameObject textPopup;
    public GameObject Maguffin;
    public GameObject stoneSprite;
    public GameObject lantern;
    public Sprite stoneRuby;

    public GameObject textBox;

    public bool canPutStone;
    public bool hasStone;
    public bool canCollect;
    public bool talkNPC;
    public bool canTravel;
    public bool hasLantern;

    public GameObject nifraUI;
    public GameObject adaUI;
    public GameObject objectUI;

    public PlayerMovement playMove;

    static private int numScenesLoaded = 0;

    void Start()
    {
        Debug.Log(numScenesLoaded);
        textPopup.SetActive(false);
        hasStone = false;
        canCollect = false;
        canPutStone = false;
        canTravel = false;
        hasLantern = PlayerPrefs.GetInt("hasLantern") == 1 ? true : false;

        nifraUI.SetActive(false);
        adaUI.SetActive(false);
        objectUI.SetActive(false);

        numScenesLoaded++;
        PlayerPrefs.SetInt("numScenesLoaded", numScenesLoaded);
        PlayerPrefs.Save();
        Debug.Log(numScenesLoaded);
    }

    private void Update()
    {
        numScenesLoaded = PlayerPrefs.GetInt("numScenesLoaded");

        if(numScenesLoaded == 1)
        {
            hasLantern = false;
            lantern.SetActive(false);
            PlayerPrefs.SetInt("hasLantern", hasLantern ? 1 : 0);
            PlayerPrefs.Save();
        }

    }
}
