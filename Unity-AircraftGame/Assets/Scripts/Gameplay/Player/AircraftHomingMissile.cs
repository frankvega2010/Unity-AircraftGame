using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftHomingMissile : MonoBehaviour
{
    public GameObject playerMissileLauncher;
    public GameObject target;
    public bool isFired = false;
    //public Vector3 dirDestination;
    public Vector3 dirFrom;

    private Vector3 dir;
    private float lifespan;
    private GameObject objectAffected;
    private UIFollowTarget targetUI;
    private AircraftMissileLauncher missileLauncher;

    private void Start()
    {
        transform.position = dirFrom;
        missileLauncher = playerMissileLauncher.GetComponent<AircraftMissileLauncher>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isFired)
        {
            lifespan += Time.deltaTime;
            dir = transform.position - target.transform.position;
            transform.position = transform.position - dir * 2.5f * Time.deltaTime;

            Quaternion q01 = Quaternion.identity;
            q01.SetLookRotation(target.transform.position - transform.position, transform.up);
            transform.rotation = q01;

            if (lifespan > 10)
            {
                lifespan = 0;
                isFired = false;
                missileLauncher.isFiring = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "enemyAircraft")
        {
            EnemyAircraft enemyTarget = collider.gameObject.GetComponent<EnemyAircraft>();
            Debug.Log("kill confirmed");
            targetUI = collider.gameObject.GetComponentInChildren<UIFollowTarget>();
            targetUI.crosshair.color = Color.magenta;
            collider.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            enemyTarget.fuel = enemyTarget.fuel - 10;
            objectAffected = collider.gameObject;
            Invoke("RestoreColor", 0.1f);
            //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (collider.gameObject.tag == "enemyTurret")
        {
            Turret enemyTarget = collider.gameObject.GetComponent<Turret>();
            Debug.Log("kill confirmed");
            targetUI = collider.gameObject.GetComponentInChildren<UIFollowTarget>();
            targetUI.crosshair.color = Color.magenta;
            collider.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            enemyTarget.fuel = enemyTarget.fuel - 10;
            objectAffected = collider.gameObject;
            Invoke("RestoreColor", 0.1f);
            //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
    }

    private void RestoreColor()
    {
        if (objectAffected.gameObject.tag == "enemy")
        {
            objectAffected.GetComponent<MeshRenderer>().material.color = Color.white;
        }

        if (objectAffected.gameObject.tag == "enemyAircraft")
        {
            objectAffected.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
            objectAffected.gameObject.GetComponent<EnemyAircraft>().switchOnce = false;
            missileLauncher.isFiring = false;
            //target.crosshair.color = Color.green;
        }

        if (objectAffected.gameObject.tag == "enemyTurret")
        {
            objectAffected.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
            objectAffected.gameObject.GetComponent<Turret>().switchOnce = false;
            missileLauncher.isFiring = false;
            //target.crosshair.color = Color.green;
        }

        Destroy(gameObject);
    }
}
