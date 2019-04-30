using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftMovement : MonoBehaviour
{
    public RawImage floorLocation;
    public GameObject aimedObject;
    public GameObject aircraftModel;
    public float giro;
    public float inclination;
    public bool hasPassedBounds = false;

    private float tiltAroundZ;
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
        smooth = 3.0f;
        inclination = 0;
        jet = JetStatus.Get();
        speedLimit = 100;
        jet.speed = 0;
    }

    private void Update()
    {
        if(hasPassedBounds)
        {
            transform.position = new Vector3(0, 120, -700);
            hasPassedBounds = false;
        }
        tiltAroundZ = Input.GetAxisRaw("Horizontal");
        GetAxisForward = Input.GetAxis("Vertical");
        mousePos = Input.mousePosition;
        v3 = Input.mousePosition;
        dir = transform.position - aimedObject.transform.position;

        transform.position = transform.position - dir * 0.5f * (jet.speed * 0.1f) * Time.deltaTime;
        v3.z = 30.0f;
        aimedObject.transform.position = Camera.main.ScreenToWorldPoint(v3);

        if(GetAxisForward > 0)
        {
            if (jet.speed > speedLimit)
            {
                jet.speed = speedLimit;
            }
            else
            {
                jet.speed += 10 * Time.deltaTime;
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
                jet.speed -= 10 * Time.deltaTime;
            }
        }
        else
        {
            if (jet.speed < 0)
            {
                jet.speed = 0;
            }
            else
            {
                jet.speed -= 10 * Time.deltaTime;
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
            giro += 10 * Time.deltaTime; // Usar rotate?
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

        jet.altitude = transform.position.y;

        
        floorLocation.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z * (-1)));
        floorLocation.rectTransform.localPosition = new Vector3(0, inclination, 0);
        transform.rotation = Quaternion.Slerp(aimedObject.transform.rotation, transform.rotation, Time.deltaTime * smooth);
        transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(0, 0, giro)); // Usar rotate?
        aimedObject.transform.rotation = transform.rotation;
        

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
    }
}
