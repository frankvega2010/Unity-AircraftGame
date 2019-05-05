using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftCollision : MonoBehaviour
{
    public GameObject player;
    public GameObject explosion;

    private AircraftMovement playerAircraft;
    private Rigidbody playerRigidbody;
    private JetStatus jet;
    private ParticleSystem explosionParticles;

    private void Start()
    {
        playerAircraft = player.GetComponentInParent<AircraftMovement>();
        playerRigidbody = player.GetComponentInParent<Rigidbody>();
        jet = JetStatus.Get();
        explosionParticles = explosion.GetComponent<ParticleSystem>();
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
                playerAircraft.hasFuel = false;
                explosionParticles.Play();
                jet.fuel = 0;
                playerRigidbody.useGravity = true;
                GetComponentInParent<BoxCollider>().isTrigger = false;
                playerAircraft.enabled = false;
                break;
        }
        
    }
}
