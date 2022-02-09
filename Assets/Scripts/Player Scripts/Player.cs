using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.IO;
using TMPro;

public class Player : MonoBehaviour
{
    public NPC npc;
    public TextMeshProUGUI speakerName;
    public GameObject textPopup;
    public GameObject Maguffin;
    public GameObject stoneSprite;
    public Sprite stoneRuby;

    public GameObject textBox;

    private bool canPutStone;
    public bool hasStone;
    private bool canCollect;
    private bool talkNPC;

    public GameObject nifraUI;
    public GameObject adaUI;

    public PlayerMovement playMove;
}
