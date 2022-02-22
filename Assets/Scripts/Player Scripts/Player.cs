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
    public Sprite stoneRuby;

    public GameObject textBox;

    public bool canPutStone;
    public bool hasStone;
    public bool canCollect;
    public bool talkNPC;

    public GameObject nifraUI;
    public GameObject adaUI;
    public GameObject objectUI;

    public PlayerMovement playMove;

    void Start()
    {
        textPopup.SetActive(false);
        hasStone = false;
        canCollect = false;
        canPutStone = false;
        nifraUI.SetActive(false);
        adaUI.SetActive(false);
        objectUI.SetActive(false);
    }
}
