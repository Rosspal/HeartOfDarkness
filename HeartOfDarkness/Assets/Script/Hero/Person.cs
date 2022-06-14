using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Person
{
    public Health Health = new Health();
    public Characteristic Characteristic = new Characteristic();
    public Skills Skills = new Skills();
    public Abilities Abilities = new Abilities();
    public Equipment Equipment;
    public List<Spell> Spells = new List<Spell>();

    private string nickname = "void";
    private short level = 1;
    private int exp = 0;
    private int skillPoint = 0;
    private string specialization = "void";
    private string race = "void";
    private short skillBonus = 2;
    private short initiative = 0;
    private string modelName = "void";
    private int attack = 1;
    private int armor = 1;



    public string Nickname { get => nickname; set => nickname = value; }
    public short Level { get => level; set => level = value; }
    public string Specialization { get => specialization; set => specialization = value; }
    public string Race { get => race; set => race = value; }
    public short SkillBonus { get => skillBonus; set => skillBonus = value; }
    public short Initiative { get => initiative; set => initiative = value; }
    public string Modelname { get => modelName; set => modelName = value; }
    public int SkillPoint { get => skillPoint; set => skillPoint = value; }
    public int Exp { get => exp; }
    public int Attack { get => attack; set => attack = value; }
    public int Armor { get => armor; set => armor = value; }

    public void RefreshStats()
    {
        initiative = Characteristic.Modifier("Agility");
        Health.MaxMP = Health.Mp = (short)(Characteristic.Wisdom * 2);
        Health.HpUp(Characteristic.Modifier("Physique"), level);
    }

    public void LevelUp()
    {
        level += 1;
        skillPoint += 2;
        RefreshStats();
    }

    public void AddExp(int n)
    {
        if ((exp + n) >= 50)
        {
            LevelUp();
            int next = (exp + n) - 50;
            exp = 0;
            AddExp(next);
            
        }
        else
        {
            exp += n;
        }
    }

    public void AddSpell(Spell spell)
    {
        Spells.Add(spell);
    }


    public void RefreshSkills()
    {
        short str = Characteristic.Modifier("Strength");
        short agi = Characteristic.Modifier("Agility");
        short intel = Characteristic.Modifier("Intelect");
        short wis = Characteristic.Modifier("Wisdom");
        short cha = Characteristic.Modifier("Charisma");
        Skills.refreshValue(str, agi, intel, wis, cha, skillBonus);
    }

    public string Info()
    {
        return nickname + "/" + race + "/" + specialization + "/" + level + "/" + exp + "/"+ Health.Info() + "/" + Characteristic.Info() + "/" + Abilities.Info() + "/" + Skills.Info();
    }
}
