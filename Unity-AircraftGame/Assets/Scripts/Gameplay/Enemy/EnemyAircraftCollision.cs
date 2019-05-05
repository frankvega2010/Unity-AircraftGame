using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftCollision : MonoBehaviour
{
    public GameObject enemy;
    //public GameObject explosion;

    //private AircraftMovement playerAircraft;
    private EnemyAircraft enemyAircraft;
    //private JetStatus jet;
    //private ParticleSystem explosionParticles;

    private void Start()
    {
        // enemyAircraft = enemy.GetComponentInParent<AircraftMovement>();
        enemyAircraft = enemy.GetComponent<EnemyAircraft>();
        //jet = JetStatus.Get();
        //explosionParticles = explosion.GetComponent<ParticleSystem>();
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
            case "enemyAircraft":
                break;
            case "enemyTurret":
                break;
            case "LevelBounds":
                break;
            case "enemyBullet":
                break;
            default:
                //playerAircraft.hasFuel = false;
                enemyAircraft.fuel = 0;
                Debug.Log("enemigo choco: " + collider.gameObject.tag);
                break;
        }

    }
}
