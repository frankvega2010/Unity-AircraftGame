using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AircraftBullet : MonoBehaviour
{
    public bool isFired = false;
    public bool isBot = false;
    public Vector3 dirDestination;
    public Vector3 dirFrom;

    private Vector3 dir;
    private float lifespan;
    private GameObject objectAffected;
    private UIFollowTarget target;
    private JetStatus playerJet;

    private void Start()
    {
        transform.position = dirFrom;
        playerJet = JetStatus.Get();
    }

    // Update is called once per frame
    private void Update()
    {
        if (isFired)
        {
            lifespan += Time.deltaTime;
            dir = transform.position - dirDestination;
            transform.position = transform.position - dir * 0.3f * Time.deltaTime;
            
            if (lifespan > 3)
            {
                lifespan = 0;
                isFired = false;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(!isBot)
        {
            //if (collision.gameObject.tag == "enemy")
            //{
            //    Debug.Log("toco");
            //    collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            //    objectAffected = collision.gameObject;
            //    Invoke("RestoreColor", 0.1f);
            //    //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            //}

            if (collider.gameObject.tag == "enemyAircraft")
            {
                Debug.Log("toco nave enemiga");
                target = collider.gameObject.GetComponentInChildren<UIFollowTarget>();
                target.crosshair.color = Color.magenta;
                collider.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                collider.gameObject.GetComponentInParent<EnemyAircraft>().fuel--;
                objectAffected = collider.gameObject;
                Invoke("RestoreColor", 0.1f);
                //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }

            if (collider.gameObject.tag == "enemyTurret")
            {
                Debug.Log("toco nave enemiga");
                target = collider.gameObject.GetComponentInChildren<UIFollowTarget>();
                target.crosshair.color = Color.magenta;
                collider.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                collider.gameObject.GetComponent<Turret>().fuel--;
                objectAffected = collider.gameObject;
                Invoke("RestoreColor", 0.1f);
                //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }

        if (isBot)
        {
            if (collider.gameObject.tag == "Player")
            {
                Debug.Log("has sido atacado");
                playerJet.fuel--;
                //Destroy(collider);
                //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }

    private void RestoreColor()
    {
        if(!isBot)
        {
            if (objectAffected.gameObject.tag == "enemy")
            {
                objectAffected.GetComponent<MeshRenderer>().material.color = Color.white;
            }

            if (objectAffected.gameObject.tag == "enemyAircraft")
            {
                objectAffected.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                objectAffected.gameObject.GetComponentInParent<EnemyAircraft>().switchOnce = false;
                //target.crosshair.color = Color.green;
            }

            if (objectAffected.gameObject.tag == "enemyTurret")
            {
                objectAffected.GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                objectAffected.gameObject.GetComponent<Turret>().switchOnce = false;
                //target.crosshair.color = Color.green;
            }
        }
        

        Destroy(gameObject);
    }
}
