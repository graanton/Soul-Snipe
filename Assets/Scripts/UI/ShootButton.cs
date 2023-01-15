using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private WeaponKeeper _weaponHaver;

    public void OnPointerDown(PointerEventData eventData)
    {
        _weaponHaver.keepedWeapon.StartShooting();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _weaponHaver.keepedWeapon.StopShooting();
    }
}
