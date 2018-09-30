using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "WeaponModules/ScopeModule")]
public class ScopeModule : WeaponModule {

    [SerializeField] private int rangeAdjustment;
    [SerializeField] private float accuracyAdjustment;

    //If slot is taken, compare the priority and replace the module if this has higher or equal priority. Adjust stats.
    public override void InitializeModule(Weapon weapon)
    {
        if (weapon.scope != null && weapon.scope.modulePriority <= modulePriority)
        {
            weapon.scope.ProcessStatChanges(weapon, true);
            ProcessStatChanges(weapon, false);
            weapon.scope = this;
        }
        else
        {
            ProcessStatChanges(weapon, false);
            weapon.scope = this;
        }
    }

    //Go through all stat adjustments, clamping the value afterwards to avoid -ve values.
    public override void ProcessStatChanges(Weapon weapon, bool revert)
    {
        int adjSign = (!revert) ? 1 : -1;

        weapon.accuracy += accuracyAdjustment * adjSign;
        weapon.accuracy = Mathf.Clamp(weapon.accuracy, 0, 100);
        
        weapon.range += rangeAdjustment * adjSign;
        weapon.range = Mathf.Clamp(weapon.range, 0, int.MaxValue);
    }
}
