using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AircraftFuel : MonoBehaviour
{
    public GameObject player;
    public int fuelMaxTime;
    public float timerDecreaseFuel;

    private AircraftMovement playerMovement;
    private Rigidbody playerGravity;
    private JetStatus jet;
    private Scrollbar fuelBar;
    // Start is called before the first frame update
    private void Start()
    {
        jet = JetStatus.Get();
        playerMovement = player.GetComponent<AircraftMovement>();
        playerGravity = player.GetComponent<Rigidbody>();
        fuelBar = GetComponent<Scrollbar>();
    }

    // Update is called once per frame
    private void Update()
    {
        timerDecreaseFuel += Time.deltaTime;
        fuelBar.size = jet.fuel * 0.01f;

        if (jet.fuel < 0)
        {
            jet.fuel = 0;
        }

        if (timerDecreaseFuel >= fuelMaxTime)
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
            timerDecreaseFuel = 0;
        }
    }
}
