using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DVJ02.Clase04
{
public class QuaternionsExample : MonoBehaviour
{
        public float localRotX;
        public GameObject movingobject;
        public Transform pingPongTransform;
        public Camera testCamera;
        public float giro;
       // public Camera testCamera;
        public Transform SetLookRotation;
        public Vector3 jetUp;
        public int value;
        public bool switchOnce1 = false;
        public bool switchOnce2 = false;
        public bool isSwitching = false;
        public float upLimit1 = 300;
        public float upLimit2 = 200;
        public float upLimit3 = 8;
        public float upLimit4 = 20;
        public float downLimit1 = 60;
        public float downLimit2 = 180;

        private float smooth = 3.0f;

        private void Start()
        {
            value = 1;
            jetUp = new Vector3(0, value, 0);
        }

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
            localRotX = (movingobject.transform.localEulerAngles.x + 360) % 360;

            movingobject.transform.position = movingobject.transform.position - dir * 0.5f * Time.deltaTime;
            v3.z = 30.0f;
            pingPongTransform.transform.position = Camera.main.ScreenToWorldPoint(v3);


            isSwitching = false;
            if (movingobject.transform.rotation.eulerAngles.x < upLimit1 && movingobject.transform.rotation.eulerAngles.x > upLimit2)
            {
                isSwitching = true;
                if (!switchOnce1)
                {
                    value = value * (-1);
                    Debug.Log(SetLookRotation.transform.rotation.eulerAngles.x);

                    switchOnce1 = true;
                    switchOnce2 = false;
                }
                //SetLookRotation.transform.eulerAngles = new Vector3(SetLookRotation.transform.rotation.eulerAngles.x, upLimit1, SetLookRotation.transform.rotation.eulerAngles.z);
                jetUp = new Vector3(0, value, 0);
            }
            else if (movingobject.transform.rotation.eulerAngles.x > downLimit1 && movingobject.transform.rotation.eulerAngles.x < downLimit2)
            {
                isSwitching = true;
                if (!switchOnce2)
                {
                    value = value * (-1);
                    switchOnce1 = false;
                    switchOnce2 = true;
                    Debug.Log("2: " + SetLookRotation.transform.rotation.eulerAngles.x);
                }
                // SetLookRotation.transform.eulerAngles = new Vector3(SetLookRotation.transform.rotation.eulerAngles.x, downLimit1, SetLookRotation.transform.rotation.eulerAngles.z);
                jetUp = new Vector3(0, value, 0);
            }

            //if (SetLookRotation.transform.rotation.eulerAngles.x > 250)
            //{
            //    isSwitching = true;
            //    if (!switchOnce1)
            //    {
            //        value = value * (-1);
            //        Debug.Log(SetLookRotation.transform.rotation.eulerAngles.x);

            //        switchOnce1 = true;
            //        switchOnce2 = false;
            //    }
            //    jetUp = new Vector3(0, value, 0);
            //}
            //else if (SetLookRotation.transform.rotation.eulerAngles.x > 70)
            //{
            //    isSwitching = true;
            //    if (!switchOnce2)
            //    {
            //        value = value * (-1);
            //        switchOnce1 = false;
            //        switchOnce2 = true;
            //        Debug.Log("2: " + SetLookRotation.transform.rotation.eulerAngles.x);
            //    }
            //    jetUp = new Vector3(0, value, 0);
            //}

            if (!isSwitching)
            {
                if (switchOnce2)
                {
                    switchOnce2 = false;
                }

                if (switchOnce1)
                {
                    switchOnce1 = false;
                }
            }
            //Debug.Log("3: " + SetLookRotation.transform.rotation.eulerAngles.x);
            //jetUp = new Vector3(0, value, 0);
            //Debug.Log(SetLookRotation.transform.rotation.eulerAngles.y);
           Debug.Log("something: " + SetLookRotation.transform.rotation.eulerAngles.x);


            //if (localRotX > 65.0f)
            //{
            //    Debug.Log("es mayor");
            //    jetUp = new Vector3(0, -1, 0);
            //}
            //else
            //{
            //    Debug.Log("es menor");
            //    jetUp = new Vector3(0, 1, 0);
            //}

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
            }


            Quaternion q01 = Quaternion.identity;
            q01.SetLookRotation(pingPongTransform.position - SetLookRotation.position, jetUp); // similar to LookRotation //
            SetLookRotation.rotation = q01;

            if (tiltAroundZ > 0)
            {
                giro -= 100 * Time.deltaTime;
               // Debug.Log("inclinado: " + SetLookRotation.transform.rotation.eulerAngles.y);
            }
            else if (tiltAroundZ < 0)
            {
                giro += 100 * Time.deltaTime;
                //Debug.Log("inclinado: " + SetLookRotation.transform.rotation.eulerAngles.y);
            }

            SetLookRotation.transform.rotation = SetLookRotation.transform.rotation * Quaternion.Euler(new Vector3(0, 0, giro));
            movingobject.transform.rotation = Quaternion.Slerp(movingobject.transform.rotation, SetLookRotation.transform.rotation, Time.deltaTime * smooth); //
            pingPongTransform.rotation = movingobject.transform.rotation;

            // Jet Manuever ---END---

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);
    }
}
}
