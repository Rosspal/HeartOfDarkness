using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Item
{
    private string name;
    private string type;
    private int price;
    private double weighs;

    public string Name { get => name; set => name = value; }
    public string Type { get => type; set => type = value; }
    public int Price { get => price; set => price = value; }
    public double Weighs { get => weighs; set => weighs = value; }
}

public class Armor: Item
{
    private string armorType;
    private int armorClass;

    public string ArmorType { get => armorType; set => armorType = value; }
    public int ArmorClass { get => armorClass; set => armorClass = value; }
}

public class Weapon: Item
{
    private Point damage;
    private string damageType;

    public int CountDamage { get => damage.X; set => damage.X = value; }
    public int Damage { get => damage.Y; set => damage.Y = value; }
    public string DamageType { get => damageType; set => damageType = value; }
}

public class Accessory: Item
{
    private string effect;

    public string Effect { get => effect; set => effect = value; }
}
