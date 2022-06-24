using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponDate", menuName = "Item/weapon")]
public class Weapon : Item
{
    public int diceCount;
    public int diceValue;
    public string damageType;
}


