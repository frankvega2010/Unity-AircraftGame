using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftMovement : MonoBehaviour
{
    public RawImage floorLocation;
    public RawImage crosshair;
    public GameObject aimedObject;
    public Camera tpcamera;
    public float rotationSpeed;
    public float speedLimit;
    public bool hasPassedBounds = false;
    public bool hasFuel = true;

    private float inclination;
    private float tiltAroundZ;
    private float smooth;
    private Vector3 v3;
    private Vector3 dir;
    private Vector3 mousePos;
    private float calculoRot;
    private JetStatus jet;
    private float GetAxisForward;
    

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
        crosshair.transform.position = mousePos;
        tpcamera.transform.position = transform.position + (transform.up *2.2f) + (transform.forward*-1) * 7;

        if (hasFuel)
        {
            if (GetAxisForward > 0)
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
                if (jet.speed < 0)
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
        }
        else
        {
            jet.speed = 0;
        }

        Quaternion q01 = Quaternion.identity;
        q01.SetLookRotation(aimedObject.transform.position - transform.position, transform.up);
        transform.rotation = q01;

        calculoRot = (transform.localEulerAngles.x + 360) % 360;

        if(calculoRot > 270)
        {
            inclination = calculoRot - 360;
        }
        else
        {
            inclination = calculoRot;
        }

        jet.altitude = transform.position.y;
        
        floorLocation.rectTransform.rotation = Quaternion.Euler(new Vector3(0, 0, transform.rotation.eulerAngles.z * (-1)));
        floorLocation.rectTransform.localPosition = new Vector3(0, inclination, 0);
        tpcamera.transform.rotation = Quaternion.Slerp(aimedObject.transform.rotation, tpcamera.transform.rotation, Time.deltaTime * 5);
        transform.rotation = Quaternion.Slerp(aimedObject.transform.rotation, transform.rotation, Time.deltaTime * smooth);
        
        if (tiltAroundZ > 0)
        {
            transform.Rotate(new Vector3(0, 0, -rotationSpeed));
        }
        else if (tiltAroundZ < 0)
        {
            transform.Rotate(new Vector3(0, 0, rotationSpeed));
        }
        else if (tiltAroundZ == 0)
        {
            transform.Rotate(new Vector3(0, 0, 0));
        }

        aimedObject.transform.rotation = transform.rotation;
        

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
    }
}
