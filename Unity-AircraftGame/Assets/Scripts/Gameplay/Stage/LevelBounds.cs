using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBounds : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        switch(other.gameObject.tag)
        {
            case "Player":
                collider.GetComponent<AircraftMovement>().hasPassedBounds = true;
                Debug.Log("player teleported");
                break;
            case "enemyAircraft":
                other.gameObject.transform.position = new Vector3(0, 0, -700);
                Debug.Log("enemy teleported");
                break;
            default:
                break;
        }
        
    }
}
