using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomWalker : MonoBehaviour
{
    public UnityEvent<Room> roomEnterEvent;
    public UnityEvent<Room> roomExitEvent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out Room room))
        {
            roomEnterEvent?.Invoke(room);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out Room room))
        {
            roomExitEvent?.Invoke(room);
        }
    }
}
