using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    //public CinemachineVirtualCamera natureCam;
    //public CinemachineVirtualCamera ruinsCam;

    void Start()
    {
        cam2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(cam1.activeInHierarchy)
            {
                cam1.SetActive(false);
                cam2.SetActive(true);
            }
            else if(cam2.activeInHierarchy)
            {
                cam1.SetActive(true);
                cam2.SetActive(false);
            }
                
        }
    }
}
