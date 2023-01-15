using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToMovementWeaponRotater : MonoBehaviour
{
    [SerializeField] private WeaponBase _target;
    [SerializeField] private MovementBehaviour _movement;

    private void Awake()
    {
        _movement.moveEvent.AddListener(OnMove); 
    }

    private void OnMove(Vector2 direction)
    {
        float Angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        _target.transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
    }

    public void SetTarget(WeaponBase target)
    {
        _target = target;
    }
}
