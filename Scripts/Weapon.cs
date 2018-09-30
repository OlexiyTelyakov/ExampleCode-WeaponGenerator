using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon {

    [Header("Modules in use")]
    public WeaponModule barrel;
    public WeaponModule scope;
    public WeaponModule auxillary;

    [Header("Stats")]
    public int damage = 10;
    public int shotVolume = 10;
    public int range = 10;
    public int ammoLimit = 7;
    public float accuracy = 20f; 

    //Constructor
    public Weapon(WeaponModule[] weaponModules)
    {
        //Run through and initialize all the modules.
        for(int i = 0;i < weaponModules.Length; i++)
        {
            weaponModules[i].InitializeModule(this);
        }
        Debug.Log(barrel + "" + scope + "" + auxillary);
    }
}
