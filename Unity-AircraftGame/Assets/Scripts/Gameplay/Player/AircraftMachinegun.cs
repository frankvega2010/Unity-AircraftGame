﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMachinegun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletDestObject;
    public bool isBotFiring;
    public bool isBot;
    public float fireRate;

    private Vector3 mousePos;
    private Vector3 dir;
    private Vector3 dirDestination;
    private JetStatus jet;
    private bool isFiring;
    private Transform destObject;
    private Transform parentTransform;

    // Start is called before the first frame update
    private void Start()
    {
        bullet.GetComponent<MeshRenderer>().enabled = false;
        bullet.GetComponent<BoxCollider>().enabled = false;
        bullet.SetActive(false);
        jet = JetStatus.Get();
        destObject = GetComponentInParent<Transform>();
        parentTransform = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        mousePos = Input.mousePosition;
        bulletDestObject.transform.position = parentTransform.position - (parentTransform.forward  * 1000) * (-1);

        if (isFiring)
        {
            fireRate += Time.deltaTime;
        }

        if(fireRate > 0.10f)
        {
            isFiring = false;
            fireRate = 0;
        }

        if(!isBot)
        {
            if (Input.GetMouseButton(0))
            {
                if (!isFiring)
                {
                    isFiring = true;
                    bullet.SetActive(true);

                    GameObject bulletCopy = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    AircraftBullet aircraftBulletCopy = bulletCopy.GetComponent<AircraftBullet>();
                    bulletCopy.GetComponent<MeshRenderer>().enabled = true;
                    bulletCopy.GetComponent<BoxCollider>().enabled = true;

                    aircraftBulletCopy.transform.rotation = destObject.rotation;
                    aircraftBulletCopy.dirDestination = bulletDestObject.transform.position;
                    aircraftBulletCopy.dirFrom = destObject.position;

                    aircraftBulletCopy.isFired = true;
                }

            }
        }

        if(isBot)
        {
            if (isBotFiring)
            {
                if (!isFiring)
                {
                    isFiring = true;
                    bullet.SetActive(true);

                    GameObject bulletCopy = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                    AircraftBullet aircraftBulletCopy = bulletCopy.GetComponent<AircraftBullet>();
                    aircraftBulletCopy.isBot = true;
                    bulletCopy.GetComponent<MeshRenderer>().enabled = true;
                    bulletCopy.GetComponent<BoxCollider>().enabled = true;

                    bulletDestObject.transform.position = bulletDestObject.transform.position + destObject.forward * 100;

                    aircraftBulletCopy.transform.rotation = destObject.rotation;
                    aircraftBulletCopy.dirDestination = bulletDestObject.transform.position;
                    aircraftBulletCopy.dirFrom = destObject.position;

                    aircraftBulletCopy.isFired = true;
                }
            }
        }

    }
}
