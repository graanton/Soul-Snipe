using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemiesInfo : MonoBehaviour
{
    [SerializeField] private List<Entity> _enemies;

    public UnityEvent<Entity> enemyRegisterEvent;

    public List<Entity> enemies => _enemies;

    private void Start()
    {
        foreach (Entity enemy in _enemies)
        {
            enemyRegisterEvent?.Invoke(enemy);
        }
    }

    public void RegisterEnemy(Entity enemy)
    {
        _enemies.Add(enemy);
        enemyRegisterEvent?.Invoke(enemy);
    }
}
