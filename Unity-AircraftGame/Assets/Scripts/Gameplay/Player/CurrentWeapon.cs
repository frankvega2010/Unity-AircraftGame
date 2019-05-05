using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWeapon : MonoBehaviour
{
    public Text ammoText;
    public Text weaponText;
    public GameObject machineGun;
    public GameObject missileLauncher;

    private AircraftMissileLauncher playerMissileLauncher;
    private bool weaponSwitch = true;
    private bool weaponSwitch2 = false;
    // Start is called before the first frame update
    private void Start()
    {
        playerMissileLauncher = missileLauncher.GetComponent<AircraftMissileLauncher>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            weaponSwitch = true;
            weaponSwitch2 = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weaponSwitch2 = true;
            weaponSwitch = false;
        }

        if (weaponSwitch)
        {
            machineGun.SetActive(weaponSwitch);
            missileLauncher.SetActive(weaponSwitch2);
            ammoText.text = "Current Ammo: -";
            weaponText.text = "Current Weapon: Machine Gun";
            ammoText.color = Color.green;
        }
        else if(weaponSwitch2)
        {
            machineGun.SetActive(weaponSwitch);
            missileLauncher.SetActive(weaponSwitch2);
            if (playerMissileLauncher.isFiring)
            {
                ammoText.text = "Current Ammo: RELOADING...";
                ammoText.color = Color.red;
            }
            else
            {
                ammoText.text = "Current Ammo: 1";
                ammoText.color = Color.green;
            }
            
            weaponText.text = "Current Weapon: Missile Launcher";
        }
    }
}
