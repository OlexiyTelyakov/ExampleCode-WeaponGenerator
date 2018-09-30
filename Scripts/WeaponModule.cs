using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Parent class for all modules
public abstract class WeaponModule : ScriptableObject {

    public int modulePriority;

    abstract public void InitializeModule(Weapon weapon);
    abstract public void ProcessStatChanges(Weapon weapon, bool revert);
}
