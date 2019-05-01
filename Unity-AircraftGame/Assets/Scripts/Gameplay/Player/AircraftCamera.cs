﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftCamera : MonoBehaviour
{
    public Camera cockpitCamera;
    public Camera thirdPersonCamera;
    public RawImage HUD;
    public RawImage HUDInclination;

    private bool isCockpitCameraON;
    private bool isTPCameraON;

    // Start is called before the first frame update
    private void Start()
    {
        isCockpitCameraON = true;
        isTPCameraON = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            isCockpitCameraON = true;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isTPCameraON = true;
        }


        if (isCockpitCameraON)
        {
            switchToCockpitCamera();
            isTPCameraON = false;
        }
        else if(isTPCameraON)
        {
            switchToTPCamera();
            isCockpitCameraON = false;
        }
    }

    public void switchToCockpitCamera()
    {
        cockpitCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        isCockpitCameraON = false;
        activateHUD();
    }

    public void switchToTPCamera()
    {
        cockpitCamera.enabled = false;
        thirdPersonCamera.enabled = true;
        isTPCameraON = false;
        deactivateHUD();
    }

    public void deactivateHUD()
    {
        HUD.enabled = false;
        HUDInclination.enabled = false;
    }

    public void activateHUD()
    {
        HUD.enabled = true;
        HUDInclination.enabled = true;
    }

}