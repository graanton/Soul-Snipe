using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DungeonGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _spacing;
    [SerializeField] private int _pathLength;
    [SerializeField] private int _pathCount;
    [SerializeField] private Transform _parent;
    [SerializeField] private Pool<Room> _pool;

    public List<Room> rooms = new();

    private readonly List<Vector2Int> _walkDirections = new() { Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left };

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        List<Vector2Int> points = new(DungeonPointsAlgorithm(_pathCount, _pathLength));

        foreach (Vector2Int point in points)
        {
            AddRoom(_pool.GetRandomWeightedObject().obj, point);
        }
    }

    private HashSet<Vector2Int> DungeonPointsAlgorithm(int pathCount, int pathLength)
    {
        HashSet<Vector2Int> points = new();

        for (int pathes = 0; pathes < pathCount; pathes++)
        {
            List<Vector2Int> path = new();
            for (int lenght = 0; lenght < pathLength; lenght++)
            {
                Vector2Int previousPoint;
                if (path.Count == 0)
                {
                    previousPoint = Vector2Int.zero;
                }
                else
                {
                    previousPoint = path[path.Count - 1];
                }
                Vector2Int newPoint = previousPoint + _walkDirections[Random.Range(0, _walkDirections.Count)];
                path.Add(newPoint);
            }
            foreach (Vector2Int point in path)
            {
                points.Add(point);
            }
        }

        return points;
    }

    public void AddRoom(Room room, Vector2Int position)
    {
        Instantiate(room, new Vector3(position.x, position.y) + _parent.position, Quaternion.identity, _parent);
    }
}