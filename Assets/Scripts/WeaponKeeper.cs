using UnityEngine;
using UnityEngine.Events;

public class WeaponKeeper : MonoBehaviour
{
    public WeaponBase keepedWeapon { get; private set; }
    public UnityEvent<WeaponBase> weaponKeepEvent;

    public void KeepWeapon(WeaponBase weapon)
    {
        if (keepedWeapon != null)
        {
            Destroy(keepedWeapon.gameObject);
        }

        keepedWeapon = Instantiate(weapon, transform.position, transform.rotation, transform);
        weaponKeepEvent?.Invoke(keepedWeapon);
    }
}