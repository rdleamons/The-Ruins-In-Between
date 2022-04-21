using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class PlayerLightControl : MonoBehaviour
{
    private Player player;
    public UnityEngine.Experimental.Rendering.Universal.Light2D lanternLight;

    // Start is called before the first frame update
    void Start()
    {
        lanternLight.enabled = false;
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasLantern && Input.GetKeyDown(KeyCode.L))
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
