using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DVJ02.Clase04
{
public class QuaternionsExample : MonoBehaviour
{
        public GameObject movingobject;
        public Transform pingPongTransform;
        public Camera testCamera;
        public float giro;
       // public Camera testCamera;
        public Transform SetLookRotation;

        private float smooth = 3.0f;

    private void Update()
    {
            // Jet Maneuver ---START---
            float tiltAroundZ = Input.GetAxis("Horizontal");
            float x = Input.GetAxis("Mouse X");
            float y = Input.GetAxis("Mouse Y");
            Vector3 mousePos = Input.mousePosition;
            Vector3 v3 = Input.mousePosition;
            Vector3 dir = movingobject.transform.position -
                              pingPongTransform.position;

            movingobject.transform.position = movingobject.transform.position - dir * 0.5f * Time.deltaTime;
            v3.z = 30.0f;
            pingPongTransform.transform.position = Camera.main.ScreenToWorldPoint(v3);

            Quaternion q01 = Quaternion.identity;
            q01.SetLookRotation(pingPongTransform.position - SetLookRotation.position, Vector3.up); // similar to LookRotation
            SetLookRotation.rotation = q01;

            if (tiltAroundZ > 0)
            {
                giro -= 100 * Time.deltaTime;
            }
            else if (tiltAroundZ < 0)
            {
                giro += 100 * Time.deltaTime;
            }

            SetLookRotation.transform.rotation = SetLookRotation.transform.rotation * Quaternion.Euler(new Vector3(0, 0, giro));
            movingobject.transform.rotation = Quaternion.Slerp(movingobject.transform.rotation, SetLookRotation.transform.rotation, Time.deltaTime * smooth);
            // Jet Manuever ---END---

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
    }
}
}
