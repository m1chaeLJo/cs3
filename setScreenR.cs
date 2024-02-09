using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setScreenR : MonoBehaviour
{
    public int AimFPSmin;
    public int AimFPSmax;
    public float delta;
    public int screenX;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 165;

    }

    // Update is called once per frame
    void Update()
    {
        if (screenX < 800)
        {
            screenX = 800;
        }
        delta = 1/Time.deltaTime;
        if (1/Time.deltaTime <AimFPSmin)
        {
            screenX=screenX-10;
            Screen.SetResolution(screenX,screenX*9/16, true);
        }
        if (1/Time.deltaTime >AimFPSmax)
        {
            screenX = screenX + 10;
            Screen.SetResolution(screenX, screenX * 1080 / 1920, true);
        }

    }
}
