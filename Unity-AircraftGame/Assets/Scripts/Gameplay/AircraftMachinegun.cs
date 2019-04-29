using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftMachinegun : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletDestObject;
    public bool isBotFiring;

    private Vector3 mousePos;
    private Vector3 dir;
    private Vector3 dirDestination;
    private JetStatus jet;
    private float fireRate;
    private bool isFiring;

    // Start is called before the first frame update
    void Start()
    {
        bullet.GetComponent<MeshRenderer>().enabled = false;
        bullet.GetComponent<BoxCollider>().enabled = false;
        bullet.SetActive(false);
        jet = JetStatus.Get();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;

        if (isFiring)
        {
            fireRate += Time.deltaTime;
        }

        if(fireRate > 0.10f)
        {
            isFiring = false;
            fireRate = 0;
        }

        if (Input.GetMouseButton(0))
        {
            if(!isFiring)
            {
                isFiring = true;
                bullet.SetActive(true);

                GameObject bulletCopy = Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                AircraftBullet aircraftBulletCopy = bulletCopy.GetComponent<AircraftBullet>();
                bulletCopy.GetComponent<MeshRenderer>().enabled = true;
                bulletCopy.GetComponent<BoxCollider>().enabled = true;

                mousePos.z = 1000.0f;
                bulletDestObject.transform.position = Camera.main.ScreenToWorldPoint(mousePos);

                aircraftBulletCopy.transform.rotation = transform.rotation;
                aircraftBulletCopy.dirDestination = bulletDestObject.transform.position;

                aircraftBulletCopy.isFired = true;
            }
            
        }

        if(isBotFiring)
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

                mousePos.z = 1000.0f;
                bulletDestObject.transform.position = GetComponentInParent<Transform>().position + (Vector3.forward * 1000);

                aircraftBulletCopy.transform.rotation = GetComponentInParent<Transform>().rotation;
                aircraftBulletCopy.dirDestination = bulletDestObject.transform.position;
                aircraftBulletCopy.dirFrom = GetComponentInParent<Transform>().position;

                //aircraftBulletCopy.transform.rotation = GetComponentInParent<Transform>().rotation;
                //bulletDestObject.transform.position = Vector3.forward * 1000;
                //aircraftBulletCopy.dirDestination = bulletDestObject.transform.position;



                aircraftBulletCopy.isFired = true;
            }
        }
    }
}
