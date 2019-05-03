using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCollision : MonoBehaviour
{
    public GameObject player;

    private AircraftMovement playerAircraft;
    private Rigidbody playerRigidbody;
    private JetStatus jet;

    private void Start()
    {
        playerAircraft = player.GetComponentInParent<AircraftMovement>();
        playerRigidbody = player.GetComponentInParent<Rigidbody>();
        jet = JetStatus.Get();
    }

    private void OnTriggerEnter(Collider collider)
    {
        switch (collider.gameObject.tag)
        {
            case "bullet":
                break;
            case "homingMissile":
                break;
            case "enemy":
                break;
            case "LevelBounds":
                break;
            case "enemyBullet":
                break;
            default:
                //collider.GetComponent<Transform>().position = new Vector3(0, 0, 0);
                playerAircraft.hasFuel = false;
                jet.fuel = 0;
                playerRigidbody.useGravity = true;
                GetComponentInParent<BoxCollider>().isTrigger = false;
                playerAircraft.enabled = false;
                Debug.Log("avion toco");
                break;
        }
        
    }
}
