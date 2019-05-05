using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttack : MonoBehaviour
{
    private Turret enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Turret>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.currentState = Turret.enemyTurretState.Attack;
            enemy.switchOnce = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.currentState = Turret.enemyTurretState.Idle;
            enemy.switchOnce = false;
        }
    }
}
