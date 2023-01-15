using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StandartProjectile : ProjectileBase
{
    [SerializeField] private float _speed, _lifeTime = 10;

    private Rigidbody2D _rigidbody;
    private Vector2 _velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        onShoot.AddListener(OnShoot);
        Destroy(gameObject, _lifeTime);
    }

    private void OnShoot()
    {
        _velocity = initialDirection;
    }

    private void Update()
    {
        _rigidbody.MovePosition(_rigidbody.position + _velocity * _speed * Time.deltaTime);
    }
}
