using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Corridor : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Pool<TileBase> _floorTilesPool;
    [SerializeField] private TileBase _fenseTile;

    private void Start()
    {
        Build(new RectInt(0, 0, 20, 10), CorridorType.Horizontal);
    }

    public void Build(RectInt border, CorridorType type)
    {
        if (type == CorridorType.Horizontal)
        {
            CreateFence(border.position, Vector2Int.right, border.width);
            CreateFence(border.position + Vector2Int.up * border.height, Vector2Int.right, border.width);
        }
        else if (type == CorridorType.Vertical)
        {
            CreateFence(border.position, Vector2Int.up, border.height);
            CreateFence(border.position + Vector2Int.right * border.width, Vector2Int.up, border.height);
        }

        for (int x = 1; x < border.width - 1; x++)
        {
            for (int y = 1; y < border.height; y++)
            {
                _tilemap.SetTile(new Vector3Int(x, y), _floorTilesPool.GetRandomWeightedObject().obj);
            }
        }
    }

    private void CreateFence(Vector2Int startPosition, Vector2Int direction, int length)
    {
        Vector2Int currentPosition = startPosition;
        for (int i = 0; i < length; i++)
        {
            _tilemap.SetTile((Vector3Int)currentPosition, _fenseTile);
            currentPosition += direction;
        }
    }
}

public enum CorridorType
{
    Horizontal,
    Vertical
}