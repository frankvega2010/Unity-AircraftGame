using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftMovement : MonoBehaviour
{
    public RawImage floorLocation;
    public GameObject aimedObject;
    public GameObject aircraftModel;
    public int value;
    public float upLimit1; //300
                           // public float upLimit2 = 200; //220
    public float downLimit1; //70
                             // public float downLimit2 = 180; //200
    public float giro;
    public float inclination;
    public bool switchOnce1 = false;
    public bool switchOnce2 = false;
    public bool isSwitching = false;
    public Vector3 jetUp;

    private float tiltAroundZ;
    //private float tiltAroundX;
    private float smooth;
    private Vector3 mousePos;
    private Vector3 v3;
    private Vector3 dir;
    private float calculoRot;
    private JetStatus jet;
    private float GetAxisForward;
    private float speedLimit;

    private void Start()
    {
        jetUp = new Vector3(0, 1, 0);
        smooth = 3.0f;
        inclination = 0;
        jet = JetStatus.Get();
        speedLimit = 100;
        jet.speed = 0;
    }

    private void Update()
    {
        tiltAroundZ = Input.GetAxisRaw("Horizontal");
        GetAxisForward = Input.GetAxis("Vertical");
        // tiltAroundX = Input.GetAxis("Mouse Y");
        mousePos = Input.mousePosition;
        v3 = Input.mousePosition;
        dir = transform.position - aimedObject.transform.position;

        transform.position = transform.position - dir * 0.5f * (jet.speed * 0.1f) * Time.deltaTime;
        v3.z = 30.0f;
        aimedObject.transform.position = Camera.main.ScreenToWorldPoint(v3);

        //Angle Check --START--
        //isSwitching = false;
        //if (transform.rotation.eulerAngles.x > upLimit1)
        //{
        //    isSwitching = true;
        //    if (!switchOnce1)
        //    {
        //        value = value * (-1);
        //        //giro = 1;
        //        Debug.Log(transform.rotation.eulerAngles.x);
        //        Debug.Log("z1 " + transform.rotation.eulerAngles.z);
        //        switchOnce1 = true;
        //        switchOnce2 = false;
        //    }
        //    //SetLookRotation.transform.eulerAngles = new Vector3(SetLookRotation.transform.rotation.eulerAngles.x, upLimit1, SetLookRotation.transform.rotation.eulerAngles.z);
        //    jetUp = new Vector3(0, value, 0);
        //}
        //else if (transform.rotation.eulerAngles.x > downLimit1)
        //{
        //    isSwitching = true;
        //    if (!switchOnce2)
        //    {
        //        //giro = 1;
        //        value = value * (-1);
        //        switchOnce1 = false;
        //        switchOnce2 = true;
        //        Debug.Log("2: " + transform.rotation.eulerAngles.x);
        //        Debug.Log("2z " + transform.rotation.eulerAngles.z);
        //    }
        //    // SetLookRotation.transform.eulerAngles = new Vector3(SetLookRotation.transform.rotation.eulerAngles.x, downLimit1, SetLookRotation.transform.rotation.eulerAngles.z);
        //    jetUp = new Vector3(0, value, 0);
        //}

        //if (!isSwitching)
        //{
        //    if (switchOnce2)
        //    {
        //        switchOnce2 = false;
        //    }

        //    if (switchOnce1)
        //    {
        //        switchOnce1 = false;
        //    }
        //}
        //Angle Check --END--
        //Debug.Log("something: " + transform.rotation.eulerAngles.x);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            value = value * (-1);
            jetUp = new Vector3(0, value, 0);
            Debug.Log(value);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            value = value * (-1);
            jetUp = new Vector3(0, value, 0);
            Debug.Log(value);
            //Debug.Log("inclinado: " + SetLookRotation.transform.rotation.eulerAngles.y);
            //jet.speed
        }

        if(GetAxisForward > 0)
        {
            if (jet.speed > speedLimit)
            {
                jet.speed = speedLimit;
            }
            else
            {
                jet.speed += 1  * 10 * Time.deltaTime;
            }    
        }
        else if (GetAxisForward < 0)
        {
            if(jet.speed < 0)
            {
                jet.speed = 0;
            }
            else
            {
                jet.speed -= 1 * 10 * Time.deltaTime;
            }
        }


        Quaternion q01 = Quaternion.identity;
        q01.SetLookRotation(aimedObject.transform.position - transform.position, transform.up); // similar to LookRotation
        transform.rotation = q01;

        if (tiltAroundZ > 0)
        {
            giro -= 10 * Time.deltaTime;
            // Debug.Log("inclinado: " + SetLookRotation.transform.rotation.eulerAngles.y);
        }
        else if (tiltAroundZ < 0)
        {
            giro += 10 * Time.deltaTime;
            //Debug.Log("inclinado: " + SetLookRotation.transform.rotation.eulerAngles.y);
        }
        else if(tiltAroundZ == 0)
        {
            giro = 0;
        }


        calculoRot = (transform.localEulerAngles.x + 360) % 360;

        if(calculoRot > 270)//270 y 90
        {
            inclination = calculoRot - 360;
            //Debug.Log("tabla baja: " + inclination);
        }
        else
        {
            inclination = calculoRot;
            //Debug.Log("tabla sube: " + inclination);
        }

        //if (mousePos.y > Screen.height / 2) // tabla sube
        //{
        //    //Debug.Log("tabla sube: " + inclination);
        //    inclination = (((transform.localEulerAngles.x + 360) % 360));
        //}
        //else if (mousePos.y < Screen.height / 2) // tabla baja
        //{
            
        //    //Debug.Log("tabla baja: " + inclination);
        //    inclination = (((transform.localEulerAngles.x + 360) % 360) - 360);
        //}


        //Debug.Log("rotacion x: " + transform.localEulerAngles.x);
        //if(inclination < 0)
        //{
        //    //localRotX = (transform.localEulerAngles.x + 360) % 360;
        //    inclination = (((transform.rotation.eulerAngles.x + 360) ) * 0.1f) * (-1);
        //}
        //else
        //{
        //    inclination = (transform.rotation.eulerAngles.x * 0.1f) * (-1);
        //}

        jet.altitude = transform.position.y;

        
        floorLocation.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z * (-1)));
        floorLocation.rectTransform.localPosition = new Vector3(0, inclination, 0);
        transform.rotation = Quaternion.Slerp(aimedObject.transform.rotation, transform.rotation, Time.deltaTime * smooth);
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, giro));
        aimedObject.transform.rotation = transform.rotation;
        

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
    }
}
