using System.Collections;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    public abstract int hp { get; }

    public abstract void TakeDamage(int damage);
}