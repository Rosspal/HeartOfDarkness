using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Drawing;

public class Item
{
    protected string name;
    protected string type;
    protected int price;
    protected double weighs;

    public string Name { get => name; set => name = value; }
    public string Type { get => type; set => type = value; }
    public int Price { get => price; set => price = value; }
    public double Weighs { get => weighs; set => weighs = value; }

    public Item(string n, string t, int p, double w)
    {
        name = n;
        type = t;
        price = p;
        weighs = w;
    }

    public Item() { }

    public virtual string info()
    {
        return name + "/" + type + "/" + price + "/" + weighs;
    }

    public virtual List<object> Data()
    {
        List<object> data = new List<object>();
        data.Add(name);
        data.Add(type);
        data.Add(price);
        data.Add(weighs);
        return data;
    }

    public virtual void Copy(List<object> data)
    {

    }
}

public class Armor: Item
{
    private string armorType;
    private int armorClass;

    public string ArmorType { get => armorType; set => armorType = value; }
    public int ArmorClass { get => armorClass; set => armorClass = value; }

    public Armor(string n, string t, int p, double w, string at, int ac)
    {
        name = n;
        type = t;
        price = p;
        weighs = w;
        armorType = at;
        armorClass = ac;
    }

    public Armor() { }

    public override string info()
    {
        return name + "/" + type + "/" + price + "/" + weighs + "/" + armorType + "/" + armorClass;
    }

    public override List<object> Data()
    {
        List<object> data = new List<object>();
        data.Add(name);
        data.Add(type);
        data.Add(price);
        data.Add(weighs);
        data.Add(armorType);
        data.Add(armorClass);
        return data;
    }

    
}

public class Weapon: Item
{
    private Point damage;
    private string damageType;

    public int CountDamage { get => damage.X; set => damage.X = value; }
    public int Damage { get => damage.Y; set => damage.Y = value; }
    public string DamageType { get => damageType; set => damageType = value; }

    public Weapon(string n, string t, int p, double w, string dt, int x,int y)
    {
        name = n;
        type = t;
        price = p;
        weighs = w;
        damageType = dt;
        CountDamage = x;
        Damage = y;
    }

    public Weapon() { }

    public override string info()
    {
        return name + "/" + type + "/" + price + "/" + weighs + "/" + CountDamage + "/" + Damage + "/" + damageType;
    }

    public override List<object> Data()
    {
        List<object> data = new List<object>();
        data.Add(name);
        data.Add(type);
        data.Add(price);
        data.Add(weighs);
        data.Add(CountDamage);
        data.Add(Damage);
        data.Add(DamageType);
        return data;
    }

    public override void Copy(List<object> data)
    {
        name =(string) data[0];
        type = (string)data[1];
        price = (int)data[2];
        weighs = (double)data[3];
        CountDamage = (int)data[4];
        Damage = (int)data[5];
        DamageType = (string)data[6];
    }
}

public class Accessory: Item
{
    private string effect;

    public string Effect { get => effect; set => effect = value; }

    public Accessory(string n, string t, int p, double w, string e)
    {
        name = n;
        type = t;
        price = p;
        weighs = w;
        effect = e;
    }

    public Accessory() { }

    public override List<object> Data()
    {
        List<object> data = new List<object>();
        data.Add(name);
        data.Add(type);
        data.Add(price);
        data.Add(weighs);
        data.Add(effect);
        return data;
    }
}

public class Belt : Item
{
    public int capacity;

    public Belt(string n, string t, int p, double w, int c)
    {
        name = n;
        type = t;
        price = p;
        weighs = w;
        capacity = c;
    }

    public Belt() { }

    public override List<object> Data()
    {
        List<object> data = new List<object>();
        data.Add(name);
        data.Add(type);
        data.Add(price);
        data.Add(weighs);
        data.Add(capacity);
        return data;
    }
}
