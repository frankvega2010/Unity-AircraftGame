using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftFuel : MonoBehaviour
{
    public GameObject player;
    public int fuelMaxTime;

    private AircraftMovement playerMovement;
    private Rigidbody playerGravity;
    private JetStatus jet;
    private float timer;
    private Scrollbar fuelBar;
    // Start is called before the first frame update
    void Start()
    {
        jet = JetStatus.Get();
        playerMovement = player.GetComponent<AircraftMovement>();
        playerGravity = player.GetComponent<Rigidbody>();
        fuelBar = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= fuelMaxTime)
        {
            if (jet.fuel > 0)
            {
                jet.fuel--;
            }
            else
            {
                playerMovement.hasFuel = false;
                playerGravity.useGravity = true;
            }
            fuelBar.size = jet.fuel * 0.01f;
            timer = 0;
        }
    }
}
