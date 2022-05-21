using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell
{
    public string name = "void";
    public string description;
    public int manaCost;
    public int coolDownTemp;
    public int coolDown;
    public string target;

    public int CoolDownTemp { get => coolDownTemp; set => coolDownTemp = value; }

    public virtual string Action(ref TeamContainer TC, int source, int destination)
    {
        return "";
    }

    protected short DamageRoll(int dice, int value)
    {
        short result = 0;
        for (int i = 0; i < dice; i++)
        {
            result += (short)Random.Range(1,value + 1);
        }
        return result;
    }
}


public class baseAttack: Spell
{

    public new int manaCost = 0;
    public new int coolDown = 0;


    public baseAttack()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "baseAttack";
    }
    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        return str;
    }
}

public class SplashAttack : Spell
{

    public new int manaCost = 3;
    public new int coolDown = 2;

    public SplashAttack()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "SplashAttack";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";

        if (TC.GetHero(source).Health.Mp < manaCost)
        {
            str += "Вашей магической сылы не хватило, вы потратили оставшееся впустую";
            TC.GetHero(source).Health.Mp = 0;
            if (Random.Range(0,10) < 2)
            {
                str += "\nМагическое истощение негативно повлияло на " + TC.GetHero(source).Nickname + ". Полученно 1 еденица урона";
                TC.GetHero(source).Health.DamageHP(1);
            }
        }
        else
        {
            TC.GetHero(source).Health.Mp -= (short)manaCost;
            int temp = TC.GetHero(source).Characteristic.Modifier("Intelect") / 2;
            Debug.Log("Intelect " + temp);
            short damage = (short)temp;
            str = TC.GetHero(source).Nickname + " наносит всем противникам " + damage + " урона.";
            TC.GetHeroSelected(destination).Health.DamageHP(damage);
            for (int i = 0; i < TC.Evil.Count(); i++)
            {
                TC.Evil.GetHero(i).Health.DamageHP(damage);
            }
            coolDownTemp = coolDown;
        }
        return str;
    }
}

public class Backstab : Spell
{

    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public Backstab()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "Backstab";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        int temp = TC.GetHero(source).Characteristic.Modifier("Agility") / 2;
        Debug.Log("agil " + temp);
        damage += (short)temp;
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        coolDownTemp = coolDown;
        return str;
    }
}

public class CleavingStrike: Spell
{

    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public CleavingStrike()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "CleavingStrike";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        int temp = TC.GetHero(source).Characteristic.Modifier("Strength") / 2;
        Debug.Log("stren " + temp);
        damage += (short)temp;
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        coolDownTemp = coolDown;
        return str;
    }
}

public class Heal : Spell
{
    public new  int manaCost = 2;
    public new  int coolDown = 2;

    public Heal()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "Heal";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";

        if (TC.GetHero(source).Health.Mp < manaCost)
        {
            str += "Вашей магической сылы не хватило, вы потратили оставшееся впустую";
            TC.GetHero(source).Health.Mp = 0;
            if (Random.Range(0, 10) < 1)
            {
                str += "\nМагическое истощение негативно повлияло на " + TC.GetHero(source).Nickname + ". Полученна 1 еденица урона";
                TC.GetHero(source).Health.DamageHP(1);
            }
        }
        else
        {
            TC.GetHero(source).Health.Mp -= (short)manaCost;
            short damage = TC.GetHero(source).Characteristic.Modifier("Intelect");
            Debug.Log("Intelect " + damage);
            str = TC.GetHero(source).Nickname + " лечит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " здоровья.";
            damage *= (short)-1;
            TC.GetHeroSelected(destination).Health.DamageHP(damage);
            coolDownTemp = coolDown;
            
        }
        return str;
    }
}

public class AccurateShot: Spell
{
    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public AccurateShot()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "AccurateShot";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        damage *= (short)2;
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        coolDownTemp = coolDown;
        return str;
    }
}

public class AStrongBeat : Spell
{
    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public AStrongBeat()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "AStrongBeat";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        int temp = TC.GetHero(source).Characteristic.Modifier("Physique") / 2;
        Debug.Log("Phys " + temp);
        damage += (short)temp;
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        coolDownTemp = coolDown;
        return str;
    }
}

public class Rage : Spell
{
    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public Rage()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "Rage";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        str = TC.GetHero(source).Nickname + " наносит " + damage + " урона ";
        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            if (Random.Range(0,10) <= 4)
            {
                TC.Evil.GetHero(i).Health.DamageHP(damage);
                str += TC.Evil.GetHero(i).Nickname + " ";
            }

        }

        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            if (Random.Range(0, 10) <= 4)
            {
                TC.Friend.GetHero(i).Health.DamageHP(damage);
                str += TC.Evil.GetHero(i).Nickname + " ";
            }

        }
        coolDownTemp = coolDown;
        return str;
    }
}


public class ShieldBash: Spell
{
    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public ShieldBash()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "ShieldBash";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {

        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        damage *= (short)2;
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        coolDownTemp = coolDown;
        return str;
    }
}

public class AccurateHit : Spell
{
    public new  int manaCost = 0;
    public new  int coolDown = 2;

    public AccurateHit()
    {
        name = "Base attack";
        description = "base attackkkkk";
        target = "AccurateHit";
    }

    public override string Action(ref TeamContainer TC, int source, int destination)
    {
        string str = "";
        short damage = DamageRoll(TC.GetHero(source).Equipment.Hand.diceCount, TC.GetHero(source).Equipment.Hand.diceValue);
        damage *= (short)2;
        str = TC.GetHero(source).Nickname + " наносит " + TC.GetHeroSelected(destination).Nickname + " " + damage + " урона.";
        TC.GetHeroSelected(destination).Health.DamageHP(damage);
        coolDownTemp = coolDown;
        return str;
    }
}
