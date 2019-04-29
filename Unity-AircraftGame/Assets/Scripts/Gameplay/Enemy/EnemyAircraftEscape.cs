using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftEscape : MonoBehaviour
{
    private Transform enemy;
    private Transform player;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<Transform>();
        player = GetComponentInParent<EnemyAircraft>().playerAircraft.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            if (GetComponentInParent<EnemyAircraft>().canPursuit)
            {
                GetComponentInParent<EnemyAircraft>().canPursuit = false;
                GetComponentInParent<EnemyAircraft>().inSight = true;

            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!GetComponentInParent<EnemyAircraft>().canPursuit)
            {
                GetComponentInParent<EnemyAircraft>().inSight = false;
                GetComponentInParent<EnemyAircraft>().canPursuit = true;
            }
            //Debug.Log("not moving");
        }
    }
}
