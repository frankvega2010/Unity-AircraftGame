﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraftShoot : MonoBehaviour
{
    private EnemyAircraft enemy;

    private void Start()
    {
        enemy = GetComponentInParent<EnemyAircraft>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.currentState = EnemyAircraft.enemyState.Attack;
            enemy.switchOnce = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            enemy.currentState = EnemyAircraft.enemyState.Follow;
            enemy.switchOnce = false;
        }
    }
}
