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
                Debug.Log("player entered");
                break;
            case "enemyAircraft":
                Debug.Log("enemy entered");
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
                //player.GetComponent<AircraftMovement>().hasPassedBounds = true;
                //other.GetComponentInParent<Transform>().position = new Vector3(0, 120, -700);
                Debug.Log("player teleported");
                break;
            case "enemyAircraft":
                other.gameObject.transform.position = new Vector3(0, 120, -1200);
                Debug.Log("enemy teleported");
                break;
            default:
                break;
        }
    }
}
