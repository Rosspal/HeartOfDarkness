using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClicker : MonoBehaviour
{
    public TileBase tile;
    public TileBase nullTile = null;
    public Tilemap map;
    public Tilemap mapGround;
    private Vector3Int heroPos = new Vector3Int(-14,2,0);
    private Camera mainCamera;

    public int speed = 15;

    void Start()
    {
        mainCamera = Camera.main;
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            Vector3 clickWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = map.WorldToCell(clickWorldPosition);
            Debug.Log(mapGround.GetTile(clickCellPosition));
            if (checkMove(heroPos,clickCellPosition))
            {
                map.SetTile(heroPos, nullTile);
                heroPos = clickCellPosition;
                map.SetTile(clickCellPosition, tile);

                Debug.Log(clickCellPosition);
            }

            
        }
    }

    private bool checkMove(Vector3Int hero, Vector3Int pos)
    {
        if ( Mathf.Abs(hero.x - pos.x) <= 1)
        {
            if (Mathf.Abs(hero.y - pos.y) <= 1)
            {
                return checkTileSpeed(pos);
            }
        }
        return false;
    }

    private bool checkTileSpeed(Vector3Int pos)
    {
        return true;
    }
}
