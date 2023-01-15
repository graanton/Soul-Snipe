using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon")]
public class WeaponData : ScriptableObject
{
    [SerializeField] private int _damage;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private float _fireRate;

    public int damage => _damage;
    public Sprite sprite => _sprite;
    public float fireRate => _fireRate;
}