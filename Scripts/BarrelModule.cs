using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "WeaponModules/BarrelModule")]
public class BarrelModule : WeaponModule {

    [SerializeField] private int damageAdjustment;
    [SerializeField] private int shotVolumeAdjustment;
    [SerializeField] private int rangeAdjustment;
    [SerializeField] private float accuracyAdjustment;
    
    //If slot is taken, compare the priority and replace the module if this has higher or equal priority. Adjust stats.
    public override void InitializeModule(Weapon weapon)
    {
        if(weapon.barrel != null && weapon.barrel.modulePriority <= modulePriority)
        {
            weapon.barrel.ProcessStatChanges(weapon, true);
            ProcessStatChanges(weapon, false);
            weapon.barrel = this;
        } else
        {
            ProcessStatChanges(weapon, false);
            weapon.barrel = this;
        }
    }

    //Go through all stat adjustments, clamping the value afterwards to avoid -ve values.
    public override void ProcessStatChanges(Weapon weapon, bool revert)
    {
        int adjSign = (!revert) ? 1 : -1;

        weapon.damage += damageAdjustment * adjSign;
        weapon.damage = Mathf.Clamp(weapon.damage, 0, int.MaxValue);

        weapon.shotVolume += shotVolumeAdjustment * adjSign;
        weapon.shotVolume = Mathf.Clamp(weapon.shotVolume, 0, int.MaxValue);

        weapon.accuracy += accuracyAdjustment * adjSign;
        weapon.accuracy = Mathf.Clamp(weapon.accuracy, 0, 100);

        weapon.range += rangeAdjustment * adjSign;
        weapon.range = Mathf.Clamp(weapon.range, 0, int.MaxValue);
    }
}
