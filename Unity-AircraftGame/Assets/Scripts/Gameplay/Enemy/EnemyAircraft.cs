using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAircraft : MonoBehaviour
{
    public enum enemyState
    {
        Idle,
        Follow,
        Attack,
        Escape,
        maxStates,
    }

    public GameObject playerAircraft;
    public enemyState currentState;

    private Vector3 dir;
    private UIFollowTarget target;
    private AircraftMachinegun enemyMG;

    // Start is called before the first frame update
    void Start()
    {
        target = GetComponentInChildren<UIFollowTarget>();
        enemyMG = GetComponentInChildren<AircraftMachinegun>();
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q01 = Quaternion.identity;
        q01.SetLookRotation(playerAircraft.transform.position - transform.position, transform.up); // similar to LookRotation

        enemyMG.isBotFiring = false;

        switch (currentState)
        {
            case enemyState.Idle:
                break;
            case enemyState.Follow:
                dir = transform.position - playerAircraft.transform.position;
                transform.position = transform.position - dir * 0.5f * Time.deltaTime;
                transform.rotation = q01;
                break;
            case enemyState.Attack:
                dir = transform.position - playerAircraft.transform.position;
                transform.position = transform.position - dir * 0.5f * Time.deltaTime;
                transform.rotation = q01;
                target.crosshair.color = Color.red;
                enemyMG.isBotFiring = true;
                break;
            case enemyState.Escape:
                dir = playerAircraft.transform.position - transform.position;
                transform.position = transform.position - dir * 0.5f * Time.deltaTime;
                transform.rotation = playerAircraft.transform.rotation;
                target.crosshair.color = Color.green;
                enemyMG.isBotFiring = false;
                break;
            default:
                break;
        }
    }
}
