using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private List<TileData> data;
    [SerializeField] private Transform player;

    private Dictionary<TileBase, TileData> _tiles;
    private MovementController _player;

    private void Awake()
    {
        _tiles = new();
        _player = FindObjectOfType<MovementController>();

        foreach (var tileData in data)
        {
            foreach (var tile in tileData.tiles)
            {
                _tiles.Add(tile, tileData);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int gridPos = tilemap.WorldToCell(player.position);

        TileBase selectedTile = tilemap.GetTile(gridPos);
        bool isDangerous = _tiles[selectedTile].IsDangerous;

        if (isDangerous)
        {
            _player.Die();
        }
    }
}
