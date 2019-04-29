using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "bullet":
                break;
            case "enemy":
                break;
            default:
                Debug.Log("avion toco");
                break;
        }
        
    }
}
