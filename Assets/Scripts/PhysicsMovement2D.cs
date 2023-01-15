using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PhysicsMovement2D : MovementBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(_rigidbody.position + direction.normalized * _speed * Time.deltaTime);

        moveEvent?.Invoke(direction);
    }
}
