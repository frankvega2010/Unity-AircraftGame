using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public enum enemyTurretState
    {
        Idle,
        Attack,
        maxStates,
    }

    public GameObject playerAircraft;
    public GameObject explosion;
    public enemyTurretState currentState;
    public bool switchOnce = false;
    public int fuel;

    private Vector3 dir;
    private UIFollowTarget target;
    private AircraftMachinegun enemyMG;
    private JetStatus player;
    private EnemiesDestroyed enemiesDestroyed;
    private bool discountOnce = false;
    private ParticleSystem explosionParticles;

    // Start is called before the first frame update
    private void Start()
    {
        target = GetComponentInChildren<UIFollowTarget>();
        enemyMG = GetComponentInChildren<AircraftMachinegun>();
        player = JetStatus.Get();
        enemiesDestroyed = EnemiesDestroyed.Get();
        player.enemiesLeft++;
        explosionParticles = explosion.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (fuel > 0)
        {
            enemyMG.isBotFiring = false;

            switch (currentState)
            {
                case enemyTurretState.Idle:
                    if (!switchOnce)
                    {
                        target.crosshair.color = Color.green;
                        switchOnce = true;
                    }
                    break;
                case enemyTurretState.Attack:
                    Quaternion q01 = Quaternion.identity;
                    q01.SetLookRotation(playerAircraft.transform.position - transform.position, transform.up);
                    transform.rotation = q01;
                    if (!switchOnce)
                    {
                        target.crosshair.color = Color.red;
                        switchOnce = true;
                    }
                    enemyMG.isBotFiring = true;
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (!switchOnce)
            {
                target.crosshair.color = new Vector4(0, 0, 0, 0);
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Collider>().isTrigger = false;
                if (!discountOnce)
                {
                    enemiesDestroyed.enemiesDestroyed++;
                    player.enemiesLeft--;
                    discountOnce = true;
                    explosionParticles.Play();
                    Invoke("DestroyEnemy", 3);
                    enemyMG.isBotFiring = false;
                }
                switchOnce = true;
            }
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
