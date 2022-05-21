using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEquipment : MonoBehaviour
{
    
    [SerializeField] Item item;
    [SerializeField] Armor armor;
    [SerializeField] Weapon weapon;
    [SerializeField] Belt belt;

    public Equipment GenerateBase()
    {
        Equipment equipment = new Equipment();

        equipment.SetBase(weapon);
        weapon.diceValue = 2;
        weapon.diceCount = 2;
        equipment.SetBase(item);
        equipment.SetBase(armor);
        equipment.SetBase(belt);

        return equipment;
    }
}
