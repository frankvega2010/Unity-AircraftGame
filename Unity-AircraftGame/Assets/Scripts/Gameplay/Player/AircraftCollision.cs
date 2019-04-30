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
                
                //collider.GetComponent<Transform>().position = new Vector3(0, 0, 0);
                Debug.Log("avion toco");
                break;
        }
        
    }
}
