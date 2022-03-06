using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct effect
{
    public string name;
    public int time;
}

public class Spell
{
    public string name;
    public int coolDown;
    public effect effect = new effect();
    public virtual int Damage() { return 0; }
    public Spell()
    {
        name = "void";
        coolDown = 0;
        effect.name = "void";
        effect.time = 0;
    }
}

public class BaseAttack : Spell
{
    public override int Damage()
    {
        return base.Damage();

        //hu
    }
}
