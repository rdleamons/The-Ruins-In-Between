using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class IntroText : MonoBehaviour
{
    public GameObject textBox;
    private List<string> introLines;
    private int index;
    private bool readIntro;

    void Start()
    {
        index = 0;
        introLines = new List<string>(File.ReadAllLines(Application.streamingAssetsPath + "/Intro.txt"));
        textBox.GetComponent<TextMeshProUGUI>().text = introLines[index];
        readIntro = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (readIntro)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                index++;
                textBox.GetComponent<TextMeshProUGUI>().text = introLines[index];
            }

            if (index >= introLines.Count)
                readIntro = false;
        }
    }
}
