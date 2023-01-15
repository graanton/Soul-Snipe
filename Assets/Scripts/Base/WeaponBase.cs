using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public abstract WeaponData weaponData { get; }

    public abstract void StartShooting();
    public abstract void StopShooting();
}
