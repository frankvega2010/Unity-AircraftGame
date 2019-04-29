using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraft : MonoBehaviour
{
    public GameObject playerAircraft;
    public bool inSight = false;
    public bool canPursuit = false;

    private Vector3 dir;
    private UIFollowTarget target;
    private AircraftMachinegun enemyMG;
    private bool canShoot;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponentInChildren<UIFollowTarget>();
        enemyMG = GetComponentInChildren<AircraftMachinegun>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q01 = Quaternion.identity;
        q01.SetLookRotation(playerAircraft.transform.position - transform.position, transform.up); // similar to LookRotation

        //transform.position = transform.position + Vector3.forward * 50 * Time.deltaTime;
        //transform.rotation.SetLookRotation(playerAircraft.transform.position - transform.position, Vector3.up);


        if (inSight)
        {
            //Debug.Log("escaping");
            dir = playerAircraft.transform.position - transform.position;
            transform.position = transform.position - dir * 0.5f * Time.deltaTime;
            transform.rotation = playerAircraft.transform.rotation;
            target.crosshair.color = Color.green;
            enemyMG.isBotFiring = false;
        }

        if (canPursuit)
        {
            //Debug.Log("following");
            dir = transform.position - playerAircraft.transform.position;
            transform.position = transform.position - dir * 0.5f * Time.deltaTime;
            transform.rotation = q01;
            target.crosshair.color = Color.red;
            enemyMG.isBotFiring = true;
            //transform.rotation = playerAircraft.transform.rotation;

        }

        if(canShoot)
        {

        }
    }
}
