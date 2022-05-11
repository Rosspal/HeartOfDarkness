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
    public virtual string Action(ref HeroTeam hero, ref HeroTeam enemy, int source, int destination)
    {
        return "";
    }

    protected short DamageRoll(int dice, int value)
    {
        short result = 0;
        for (int i = 0; i < dice; i++)
        {
            result += (short)Random.Range(0,value + 1);
        }
        return result;
    }
}


public class baseAttack: Spell
{
    public new readonly string name = "Base attack";
    public new readonly string description = "base attackkkkk";
    public new readonly int manaCost = 0;
    public new readonly int coolDown = 0;
    public new readonly string target = "Enemy";

    public override string Action(ref HeroTeam hero, ref HeroTeam enemy, int source, int destination)
    {
        string str = "";
        Debug.Log("name " + enemy.GetHero(destination).Nickname);
        short damage = DamageRoll(hero.GetHero(source).Equipment.Hand.diceCount, hero.GetHero(source).Equipment.Hand.diceValue);
        str = hero.GetHero(source).Nickname + " наносит " + enemy.GetHero(destination).Nickname + " " + damage + " урона." ;
        enemy.GetHero(destination).Health.DamageHP(damage);
        return str;
    }
}

