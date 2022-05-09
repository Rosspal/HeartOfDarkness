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

        Debug.Log("Название = " + weapon.title);
        equipment.SetBase(weapon);
        equipment.SetBase(item);
        equipment.SetBase(armor);
        equipment.SetBase(belt);

        return equipment;
    }
}
