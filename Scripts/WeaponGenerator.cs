using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tester class to generate some weapons.
public class WeaponGenerator : MonoBehaviour {

    [SerializeField] private int weaponsToGenerate;
    [SerializeField] private WeaponModule[] optionsList;
    //List to view at runtime and see the results.
    [SerializeField] private List<Weapon> weaponsList;

    //Generates a number of weapons using the options list. Very basic and doesn't enforce filling out all the slots in the weapon.
    public void Start()
    {
        for(int i =  0; i <= weaponsToGenerate; i++)
        {
            WeaponModule[] randomizedModuleSelection = new WeaponModule[optionsList.Length / 2];
            for (int x = 0; x < optionsList.Length / 2; x++)
            {
                randomizedModuleSelection[x] = optionsList[Random.Range(0, optionsList.Length)];
            }
            Weapon newWeapon = new Weapon(randomizedModuleSelection);
            weaponsList.Add(newWeapon);
        }
    }
}
