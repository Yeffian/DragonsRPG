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
                if (_tiles.ContainsKey(tile))
                    return;
                
                _tiles.Add(tile, tileData);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
            return;
        
        Vector3Int gridPos = tilemap.WorldToCell(player.position);

        TileBase selectedTile = tilemap.GetTile(gridPos);
        // Debug.Log(selectedTile.name);
        bool isDangerous = _tiles[selectedTile].IsDangerous;
        // Debug.Log(isDangerous);

        if (isDangerous)
            _player.Die(); 
    }
}
