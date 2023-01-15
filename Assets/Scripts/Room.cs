using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Room : MonoBehaviour
{
    [SerializeField] private Transform _leftEnter, _rightEnter, _upEnter, _downEnter;
    
    [SerializeField] private List<Wave> _waves = new List<Wave>();

    public UnityEvent openEvent;
    public UnityEvent closeEvent;
    public UnityEvent<EntitySpawnInfo> wantSpawnEvent;
    public UnityEvent<Entity> spawnEntityEvent;

    public Transform leftEnter => _leftEnter;
    public Transform rightEnter => _rightEnter;
    public Transform upEnter => _upEnter;
    public Transform downEnter => _downEnter;

    private int _wavesCalledCount;

    public void Close()
    {
        closeEvent?.Invoke();
    }

    public void Open()
    {
        openEvent?.Invoke();
    }

    public void CallNextWave()
    {
        Wave currentWave = _waves[_wavesCalledCount];
        foreach(EntitySpawnInfo info in currentWave.entities)
        {
            Entity spawnedEmtity = Instantiate(info.entity, info.position, Quaternion.identity);
            spawnEntityEvent?.Invoke(spawnedEmtity);
        }
    }
}

[Serializable]
public struct EntitySpawnInfo
{
    public Entity entity;
    public Vector2 position;
}

[Serializable]
public struct Wave
{
    public List<EntitySpawnInfo> entities;
}