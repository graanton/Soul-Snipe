using System;
using UnityEngine;
using UnityEngine.Events;

public abstract class MovementBehaviour : MonoBehaviour
{
    public MoveEvent moveEvent;

    public abstract void Move(Vector2 direction);
}

[Serializable]
public class MoveEvent: UnityEvent<Vector2> { }