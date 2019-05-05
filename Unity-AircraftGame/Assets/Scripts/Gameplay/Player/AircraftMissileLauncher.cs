using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftMissileLauncher : MonoBehaviour
{
    public GameObject crosshair;
    public LayerMask rayCastLayer;
    public GameObject missile;
    public bool isFiring;
    public float rayDistance = 2000;
    public float canFireTimer = 1.5f;

    private float lockOnTimer;
    private Color defaultCrosshairColor;
    private RawImage crosshairImage;
    private Transform startFrom;

    // Start is called before the first frame update
    private void Start()
    {
        defaultCrosshairColor = crosshair.GetComponent<RawImage>().color;
        crosshairImage = crosshair.GetComponent<RawImage>();
        missile.GetComponent<BoxCollider>().enabled = false;
        missile.SetActive(false);
        startFrom = GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isFiring)
        {
            crosshairImage.color = Color.yellow;
        }

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit, rayDistance, rayCastLayer))
        {
            Debug.DrawRay(transform.position, transform.forward * hit.distance, Color.yellow);

            string layerHitted = LayerMask.LayerToName(hit.transform.gameObject.layer);

            Debug.Log(layerHitted);

            switch (layerHitted)
            {
                case "enemyAircraft":
                    lockOnTimer += Time.deltaTime;
                    crosshairImage.color = Color.black;
                    if (lockOnTimer > canFireTimer)
                    {
                        crosshairImage.color = Color.green;
                        if (Input.GetMouseButtonDown(0))
                        {
                            if (!isFiring)
                            {
                                isFiring = true;
                                missile.SetActive(true);

                                GameObject missileCopy = Instantiate(missile, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
                                AircraftHomingMissile missileComponentCopy = missileCopy.GetComponent<AircraftHomingMissile>();
                                missileComponentCopy.GetComponent<BoxCollider>().enabled = true;
                                

                                missileComponentCopy.target = hit.transform.gameObject;
                                missileComponentCopy.dirFrom = startFrom.position;
                                lockOnTimer = 0;
                                missileComponentCopy.isFired = true;
                            }
                        }
                    }
                    break;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.white);
            crosshairImage.color = defaultCrosshairColor;
            lockOnTimer = 0;
        }
    }
}
