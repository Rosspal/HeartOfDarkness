using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileClicker : MonoBehaviour
{
    public TileBase tile;
    public TileBase nullTile = null;
    public Tilemap mapHero;
    public Tilemap mapGround;
    public Tilemap mapRoad;
    public Tilemap mapRiver;
    public Tilemap mapSurface;
    public Tilemap mapDecorations;
    private Vector3Int heroPos = new Vector3Int(-14,2,0);

    public Camera battleCamera;
    public Camera townCamera;
    private Camera mainCamera;

    public int speed = 55;

    private Vector3 clickWorldPosition;

    void Start()
    {
        townCamera.enabled = false;
        battleCamera.enabled = false;
        mainCamera = Camera.main;
        
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            clickWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = mapGround.WorldToCell(clickWorldPosition);
            Vector3Int cellGround = CellClickToCellGround(clickCellPosition);


            if (CheckMove(heroPos,clickCellPosition))
            {
                if (CheckTileCost(cellGround))
                {
                    Vector3Int cellPos = mapHero.WorldToCell(clickWorldPosition);
                    mapHero.SetTile(heroPos, nullTile);
                    heroPos = cellPos;
                    mapHero.SetTile(cellPos, tile);
                } 
            }  
        }

        if (Input.GetMouseButtonDown(1))
        {

            clickWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int clickCellPosition = mapSurface.WorldToCell(clickWorldPosition);
            Vector3Int cellGround = CellClickToCellGround(clickCellPosition);
            Debug.Log(clickCellPosition);
            Debug.Log(mapSurface.GetTile(cellGround));
        }
    }

    private Vector3Int CellClickToCellGround(Vector3Int pos)
    {
        if (pos.y % 2 == 1)
        {
            pos.y--;
        }
        else
        {
            pos.x--;
            pos.y--;
        }

        return pos;
    }

    private bool CheckMove(Vector3Int hero, Vector3Int pos)
    {
        if (hero.y % 2 == 1)
        {
            if (hero.x - pos.x == 1)
            {
                if (Mathf.Abs(hero.y - pos.y) == 1)
                {
                    return false;
                }
            }
        }
        else
        {
            if (hero.x - pos.x == -1)
            {
                if (Mathf.Abs(hero.y - pos.y) == 1)
                {
                    return false;
                }
            }
        }
        //обрабатываем два особых случая

        if ( Mathf.Abs(hero.x - pos.x) <= 1)
        {
            if (Mathf.Abs(hero.y - pos.y) <= 1)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckTileCost(Vector3Int pos)
    {
        int cost = 0;
        int saleRoad = 2;

        if (CheckLocation(pos))
        {
            switch (mapGround.GetTile(pos).name)
            {
                case "Tile_ground_1":
                    cost = 3;
                    break;
                case "Tile_ground_2":
                    cost = 3;
                    break;
                case "Tile_ground_3":
                    cost = 3;
                    break;
                case "Tile_ground_4":
                    cost = 3;
                    break;
                case "Tile_ground_5":
                    cost = 3;
                    break;
                case "Tile_ground_6":
                    cost = 3;
                    break;
                case "Tile_ground_7":
                    cost = 3;
                    break;
                case "Tile_ground_8":
                    cost = 3;
                    break;
                case "Tile_ground_9":
                    cost = 3;
                    break;
                case "Tile_ground_10":
                    cost = 3;
                    break;
                case "Tile_ground_11":
                    cost = 3;
                    break;
                case "Tile_ground_12":
                    cost = 3;
                    break;
                case "Tile_ground_13":
                    cost = 3;
                    break;
                case "Tile_ground_14":
                    cost = 3;
                    break;
                case "Tile_ground_15":
                    cost = 3;
                    break;
                case "Tile_ground_16":
                    cost = 3;
                    break;
                case "Tile_ground_17":
                    cost = 3;
                    break;
                case "Tile_ground_18":
                    cost = 3;
                    break;
                case "Tile_ground_19":
                    cost = 3;
                    break;
                case "Tile_ground_20":
                    cost = 3;
                    break;
                case "Tile_ground_21":
                    cost = 3;
                    break;
                case "Tile_ground_22":
                    cost = 3;
                    break;
                case "Tile_ground_23":
                    cost = 3;
                    break;
                case "Tile_ground_24":
                    cost = 3;
                    break;
                case "Tile_ground_25":
                    cost = 3;
                    break;
                case "Tile_ground_26":
                    cost = 3;
                    break;
                case "Tile_ground_27":
                    cost = 3;
                    break;
                case "Tile_ground_28":
                    cost = 3;
                    break;
                case "Tile_ground_29":
                    cost = 3;
                    break;
                case "Tile_ground_30":
                    cost = 3;
                    break;
                case "Tile_ground_31":
                    cost = 3;
                    break;
                case "Tile_ground_32":
                    cost = 3;
                    break;
                case "Tile_ground_33":
                    cost = 3;
                    break;
                case "Tile_ground_34":
                    cost = 3;
                    break;
                case "Tile_ground_35":
                    cost = 3;
                    break;
                case "Tile_ground_36":
                    cost = 3;
                    break;
                case "Tile_ground_37":
                    cost = 3;
                    break;
                case "Tile_ground_38":
                    cost = 3;
                    break;
                case "Tile_ground_39":
                    cost = 3;
                    break;
                case "Tile_ground_40":
                    cost = 3;
                    break;
                case "Tile_ground_41":
                    cost = 3;
                    break;
                case "Tile_ground_42":
                    cost = 3;
                    break;
                case "Tile_ground_43":
                    cost = 3;
                    break;
                case "Tile_ground_44":
                    cost = 3;
                    break;
                case "Tile_ground_45":
                    cost = 3;
                    break;
                case "Tile_ground_46":
                    cost = 3;
                    break;
                case "Tile_ground_47":
                    cost = 3;
                    break;
                case "Tile_ground_48":
                    cost = 3;
                    break;
                case "Tile_ground_49":
                    cost = 3;
                    break;
                case "Tile_ground_50":
                    cost = 3;
                    break;
                default:
                    cost = 3;
                    break;
            }

            if (mapRoad.HasTile(pos))
            {
                cost -= saleRoad;
            }

            if (mapRiver.HasTile(pos))
            {
                return false;
            }

            if (speed - cost >= 0)
            {
                speed -= cost;
                Debug.Log(speed);
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }

        
    }

    
    private bool CheckLocation(Vector3Int pos)
    {
        if (mapSurface.HasTile(pos))
        {
            switch (mapSurface.GetTile(pos).name)
            {
                case "Tile_surface_27": //город 
                    mainCamera.enabled = false;
                    townCamera.enabled = true;
                    return false;
                case "Tile_surface_2"://погост
                    break;
                case "Tile_surface_17"://затеряный храм
                    break;
                case "Tile_surface_28"://деревня 1 уровень
                    break;
                case "Tile_surface_1"://пещера
                    break;
            }
        }
        

        return true;
    }
}
