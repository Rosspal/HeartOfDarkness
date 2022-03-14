using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemDate", menuName = "Item/item")]
public class Item: ScriptableObject
{
    public string Name;
    public string type;
    public int price;
    public float weighs;
    public string effect;
}


