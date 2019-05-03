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
    void Start()
    {
        playerMissileLauncher = missileLauncher.GetComponent<AircraftMissileLauncher>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            weaponSwitch = !weaponSwitch;
            weaponSwitch2 = !weaponSwitch2;

            missileLauncher.SetActive(weaponSwitch);
            machineGun.SetActive(weaponSwitch2);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {

        }

        


        if(weaponSwitch2)
        {
            //missileLauncher.SetActive(false);
            ammoText.text = "Current Ammo: -";
            weaponText.text = "Current Weapon: Machine Gun";
            ammoText.color = Color.green;
        }
        else if(weaponSwitch)
        {
            //machineGun.SetActive(false);
            if(playerMissileLauncher.isFiring)
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
