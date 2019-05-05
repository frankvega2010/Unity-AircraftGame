using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftCollision : MonoBehaviour
{
    public GameObject enemy;

    private EnemyAircraft enemyAircraft;

    private void Start()
    {
        enemyAircraft = GetComponent<EnemyAircraft>();
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
                enemyAircraft.fuel = 0;
                break;
        }

    }
}
