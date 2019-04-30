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

    private void Start()
    {
        if(isBot)
        {
            transform.position = dirFrom;
        }
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

    private void OnCollisionEnter(Collision collision)
    {
        if(!isBot)
        {
            if (collision.gameObject.tag == "enemy")
            {
                Debug.Log("toco");
                collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                objectAffected = collision.gameObject;
                Invoke("RestoreColor", 0.1f);
                //collision.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
            }

            if (collision.gameObject.tag == "enemyAircraft")
            {
                Debug.Log("toco nave enemiga");
                target = collision.gameObject.GetComponentInChildren<UIFollowTarget>();
                target.crosshair.color = Color.black;
                collision.gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                objectAffected = collision.gameObject;
                Invoke("RestoreColor", 0.1f);
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
                target.crosshair.color = Color.green;
            }
        }
        

        Destroy(gameObject);
    }
}
