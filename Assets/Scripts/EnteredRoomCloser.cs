using System;
using System.Collections;
using UnityEngine;

public class EnteredRoomCloser : MonoBehaviour
{
    [SerializeField] private RoomWalker _roomEnterer;

    private void Awake()
    {
        _roomEnterer.roomEnterEvent.AddListener(OnRoomEnter);
    }

    private void OnRoomEnter(Room room)
    {
        room.Close();
    }
}