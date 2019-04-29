using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GetComponentInParent<EnemyAircraft>().canPursuit = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponentInParent<EnemyAircraft>().canPursuit = false;
        }
        //Debug.Log("not moving");
    }
}
