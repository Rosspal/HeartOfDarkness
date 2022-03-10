using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Weapon hand;
    private Armor helmet;
    private Armor footwear;
    private Armor pants;
    private Armor torso;
    private Belt belt;
    private Accessory oneRing;
    private Accessory twoRing;
    private Accessory gloves;
    private Accessory amulet;

    public Equipment() { }

    public Weapon Hand { get => hand; set => hand = value; }
    public Armor Helmet { get => helmet; set => helmet = value; }
    public Armor Footwear { get => footwear; set => footwear = value; }
    public Armor Pants { get => pants; set => pants = value; }
    public Armor Torso { get => torso; set => torso = value; }
    public Belt Belt { get => belt; set => belt = value; }
    public Accessory OneRing { get => oneRing; set => oneRing = value; }
    public Accessory TwoRing { get => twoRing; set => twoRing = value; }
    public Accessory Gloves { get => gloves; set => gloves = value; }
    public Accessory Amulet { get => amulet; set => amulet = value; }

    public void SetItem(Accessory item)
    {
        switch (item.Type)
        {
            case "oneRing":
                oneRing = item;
                break;
            case "twoRing":
                twoRing = item;
                break;
            case "gloves":
                gloves = item;
                break;
            case "amulet":
                amulet = item;
                break;
        }
    }

    public void SetItem(Weapon item)
    {
        hand = item;
    }

    public void SetItem(Armor item)
    {
        switch(item.Type){
            case "helmet":
                helmet = item;
                break;
            case "footwear":
                footwear = item;
                break;
            case "pants":
                pants = item;
                break;
            case "torso":
                torso = item;
                break;
        }
    }

    public void SetItem(Belt item)
    {
        belt = item;
    }

    public void TakeOff(string type)
    {
        switch (type)
        {
            case "helmet":
                helmet = new Armor();
                break;
            case "footwear":
                footwear = new Armor();
                break;
            case "pants":
                pants = new Armor();
                break;
            case "torso":
                torso = new Armor();
                break;
            case "oneRing":
                oneRing = new Accessory();
                break;
            case "twoRing":
                twoRing = new Accessory();
                break;
            case "gloves":
                gloves = new Accessory();
                break;
            case "amulet":
                amulet = new Accessory();
                break;
            case "weapon":
                hand = new Weapon();
                break;
            case "belt":
                belt = new Belt();
                break;
        }
    }

    //вывод общей брони
    public int GetAllArmor()
    {
        return helmet.ArmorClass + footwear.ArmorClass + pants.ArmorClass + torso.ArmorClass;
    }
}
