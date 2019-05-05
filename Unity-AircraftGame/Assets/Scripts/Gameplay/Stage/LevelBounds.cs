using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    //public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Player":
                break;
            case "enemyAircraft":
                break;
            default:
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                other.gameObject.GetComponentInParent<AircraftMovement>().hasPassedBounds = true;
                break;
            case "enemyAircraft":
                other.gameObject.GetComponentInParent<EnemyAircraft>().hasPassedBounds = true;
                break;
            case "MainCamera":
                other.gameObject.transform.position = other.gameObject.transform.position + other.gameObject.transform.forward*-1 * 1000;
                break;
            default:
                break;
        }
    }
}
