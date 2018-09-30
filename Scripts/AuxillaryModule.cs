using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponModules/AuxillaryModule")]
public class AuxillaryModule : WeaponModule
{
    [SerializeField] private int damageAdjustment;
    [SerializeField] private int rangeAdjustment;
    [SerializeField] private int ammoLimitAdjustment;
    [SerializeField] private float accuracyAdjustment;

    //If slot is taken, compare the priority and replace the module if this has higher or equal priority. Adjust stats.
    public override void InitializeModule(Weapon weapon)
    {
        if (weapon.auxillary != null && weapon.auxillary.modulePriority <= modulePriority)
        {
            weapon.auxillary.ProcessStatChanges(weapon, true);
            ProcessStatChanges(weapon, false);
            weapon.auxillary = this;
        }
        else
        {
            ProcessStatChanges(weapon, false);
            weapon.auxillary = this;
        }
    }

    //Go through all stat adjustments, clamping the value afterwards to avoid -ve values.
    public override void ProcessStatChanges(Weapon weapon, bool revert)
    {
        int adjSign = (!revert) ? 1 : -1;
        weapon.damage += damageAdjustment * adjSign;
        weapon.damage = Mathf.Clamp(weapon.damage, 0, int.MaxValue);
        weapon.ammoLimit += ammoLimitAdjustment * adjSign;
        weapon.ammoLimit = Mathf.Clamp(weapon.ammoLimit, 0, int.MaxValue);
        weapon.accuracy += accuracyAdjustment * adjSign;
        weapon.accuracy = Mathf.Clamp(weapon.accuracy, 0, 100);
        weapon.range += rangeAdjustment * adjSign;
        weapon.range = Mathf.Clamp(weapon.range, 0, int.MaxValue);
    }
}
