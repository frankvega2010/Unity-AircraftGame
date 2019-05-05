using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMoveCamera : MonoBehaviour
{
    public Camera menuCamera;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    void Update()
    {
        menuCamera.transform.position = menuCamera.transform.position + menuCamera.transform.forward * Time.deltaTime * 10;
    }
}
