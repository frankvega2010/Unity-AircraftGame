using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFollowTarget : MonoBehaviour
{
    public RawImage crosshair;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        //crossh.text = "SAMPLE TEXT";
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 uiPosition = Camera.main.WorldToScreenPoint(enemy.transform.position);
        crosshair.transform.position = uiPosition + new Vector3(0,8,0);
        
    }
}
