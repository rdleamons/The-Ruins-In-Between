using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerLightControl : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D lanternLight;

    // Start is called before the first frame update
    void Start()
    {
        lanternLight.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            toggleLantern(lanternLight);
    }

    void toggleLantern(UnityEngine.Experimental.Rendering.Universal.Light2D light)
    {
        if (light.enabled == true)
            light.enabled = false;
        else
            light.enabled = true;
    }
}
