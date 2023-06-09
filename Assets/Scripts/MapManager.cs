using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private List<TileData> data;
    [SerializeField] private Transform player;

    private Dictionary<TileBase, TileData> tiles;

    private void Awake()
    {
        tiles = new();

        foreach (var tileData in data)
        {
            foreach (var tile in tileData.tiles)
            {
                tiles.Add(tile, tileData);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int gridPos = tilemap.WorldToCell(player.position);

        TileBase selectedTile = tilemap.GetTile(gridPos);
        bool isDangerous = tiles[selectedTile].IsDangerous;
        
        Debug.Log(isDangerous ? "dangerous tile" : "safe tile");
    }
}
