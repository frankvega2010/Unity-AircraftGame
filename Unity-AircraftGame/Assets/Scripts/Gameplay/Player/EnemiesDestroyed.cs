using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesDestroyed : MonoBehaviourSingleton<EnemiesDestroyed>
{
    public int enemiesDestroyed;

    public override void Awake()
    {
        base.Awake();
    }
}
