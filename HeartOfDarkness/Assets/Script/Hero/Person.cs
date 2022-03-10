using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Person
{
    public Health Health = new Health();
    public Characteristic Characteristic = new Characteristic();
    public Skills Skills = new Skills();
    public Abilities Abilities = new Abilities();
    public Equipment Equipment = new Equipment();

    private string nickname = "void";
    private short level = 1;
    private int exp = 0;
    private string specialization = "void";
    private string race = "void";
    private short skillBonus = 2;
    private short initiative = 0;
    private string modelName = "void";



    public string Nickname { get => nickname; set => nickname = value; }
    public short Level { get => level; set => level = value; }
    public int Exp { get => exp; set => exp = value; }
    public string Specialization { get => specialization; set => specialization = value; }
    public string Race { get => race; set => race = value; }
    public short SkillBonus { get => skillBonus; set => skillBonus = value; }
    public short Initiative { get => initiative; set => initiative = value; }
    public string Modelname { get => modelName; set => modelName = value; }

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
