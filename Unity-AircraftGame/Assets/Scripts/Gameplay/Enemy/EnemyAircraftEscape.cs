using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftEscape : MonoBehaviour
{
    private EnemyAircraft enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentInParent<EnemyAircraft>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.currentState = EnemyAircraft.enemyState.Escape;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.currentState = EnemyAircraft.enemyState.Attack;
        }
    }
}
