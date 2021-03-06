﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftCamera : MonoBehaviour
{
    public Camera cockpitCamera;
    public Camera thirdPersonCamera;
    public GameObject rearViewMirror;
    public RawImage HUD;
    public RawImage HUDInclination;
    public bool isTPCameraON;

    private bool isCockpitCameraON;
    private bool active = false;
    private bool canSwitch = false;

    // Start is called before the first frame update
    private void Start()
    {
        isCockpitCameraON = true;
        isTPCameraON = false;
        active = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.mouseScrollDelta.y > 0)
        {
            isCockpitCameraON = true;
        }
        else if(Input.mouseScrollDelta.y < 0)
        {
            isTPCameraON = true;
        }

        if (canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                active = !active;
                rearViewMirror.SetActive(active);
            }
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

    private void switchToCockpitCamera()
    {
        cockpitCamera.enabled = true;
        thirdPersonCamera.enabled = false;
        isCockpitCameraON = false;
        canSwitch = true;
        activateHUD();
    }

    private void switchToTPCamera()
    {
        cockpitCamera.enabled = false;
        thirdPersonCamera.enabled = true;
        isTPCameraON = false;
        canSwitch = false;
        rearViewMirror.SetActive(false);
        deactivateHUD();
    }

    private void deactivateHUD()
    {
        HUD.enabled = false;
        HUDInclination.enabled = false;
    }

    private void activateHUD()
    {
        HUD.enabled = true;
        HUDInclination.enabled = true;
    }

}
