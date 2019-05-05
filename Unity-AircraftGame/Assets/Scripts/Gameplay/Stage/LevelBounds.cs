using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
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
                other.gameObject.transform.position = new Vector3(other.gameObject.transform.position.x, 320, other.gameObject.transform.position.z) + other.gameObject.transform.forward * -1 * 3000;
                break;
            case "MainCamera":
                other.gameObject.transform.position = other.gameObject.transform.position + other.gameObject.transform.forward*-1 * 1000;
                break;
            default:
                break;
        }
    }
}
