using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public readonly string name = "void";
    public readonly string description;
    public readonly int manaCost;
    private int coolDownTemp;
    public readonly int coolDown;
    public readonly string target; 

    public int CoolDownTemp { get => coolDownTemp; set => coolDownTemp = value; }
    public virtual void Action(ref HeroTeam hero, ref HeroTeam enemy, int source, int destination)
    {
        
    }
}


public class baseAttack: Spell
{
    public new readonly string name = "Base attack";
    public new readonly string description = "base attackkkkk";
    public new readonly int manaCost = 0;
    public new readonly int coolDown = 0;
    public new readonly string target = "Enemy";

    public override void Action(ref HeroTeam hero, ref HeroTeam enemy, int source, int destination)
    {
        enemy.GetHero(destination).Health.DamageHP((short)hero.GetHero(source).Equipment.Hand.diceValue);
    }
}