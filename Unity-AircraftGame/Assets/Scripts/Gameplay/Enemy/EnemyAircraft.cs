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
        NotSeen,
        maxStates,
    }

    public GameObject playerAircraft;
    public enemyState currentState;
    public bool switchOnce = false;

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
            case enemyState.NotSeen:
                dir = transform.position - (transform.position + transform.forward * 50);
                transform.position = transform.position - dir * 0.2f * Time.deltaTime;
                if (!switchOnce)
                {
                    target.crosshair.color = new Vector4(0, 0, 0, 0);
                    switchOnce = true;
                }
                break;
            case enemyState.Idle:
                dir = transform.position - (transform.position + transform.forward * 50);
                transform.position = transform.position - dir * 0.2f * Time.deltaTime;
                if (!switchOnce)
                {
                    target.crosshair.color = Color.green;
                    switchOnce = true;
                }
                break;
            case enemyState.Follow:
                dir = transform.position - playerAircraft.transform.position;
                transform.position = transform.position - dir * 0.5f * Time.deltaTime;
                transform.rotation = q01;
                if (!switchOnce)
                {
                    target.crosshair.color = Color.green;
                    switchOnce = true;
                }
                break;
            case enemyState.Attack:
                dir = transform.position - playerAircraft.transform.position;
                transform.position = transform.position - dir * 0.5f * Time.deltaTime;
                transform.rotation = q01;
                if (!switchOnce)
                {
                    target.crosshair.color = Color.red;
                    switchOnce = true;
                }
                enemyMG.isBotFiring = true;
                break;
            case enemyState.Escape:
                dir = playerAircraft.transform.position - transform.position;
                transform.position = transform.position - dir * 0.5f * Time.deltaTime;
                transform.rotation = playerAircraft.transform.rotation;
                if (!switchOnce)
                {
                    target.crosshair.color = Color.green;
                    switchOnce = true;
                }
                enemyMG.isBotFiring = false;
                break;
            default:
                break;
        }
    }
}
