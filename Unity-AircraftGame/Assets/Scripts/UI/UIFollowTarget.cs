using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowTarget : MonoBehaviour
{
    public RawImage crosshair;
    public GameObject enemy;

    // Update is called once per frame
    private void Update()
    {
        Vector3 uiPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);
        crosshair.transform.position = uiPosition + new Vector3(0,0,0); 
    }
}
