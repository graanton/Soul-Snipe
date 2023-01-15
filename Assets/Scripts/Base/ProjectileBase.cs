using UnityEngine;
using UnityEngine.Events;

public abstract class ProjectileBase : MonoBehaviour
{
    public GameObject owner { get; private set; }
    public Vector2 initialPosition { get; private set; }
    public Vector2 initialDirection { get; private set; }

    public UnityEvent onShoot;

    public void Shoot(WeaponBase weapon)
    {
        initialDirection = transform.right;
        initialPosition = transform.position;

        onShoot?.Invoke();
    }
}