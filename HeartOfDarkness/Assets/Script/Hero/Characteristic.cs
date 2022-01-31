using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic : MonoBehaviour
{
    private short strength = 0;
    private short agility = 0;
    private short intelect = 0;
    private short wisdom = 0;
    private short charisma = 0;
    private short physique = 0;

    public short Strength { get => strength; set => strength = value; }
    public short Agility { get => agility; set => agility = value; }
    public short Intelect { get => intelect; set => intelect = value; }
    public short Wisdom { get => wisdom; set => wisdom = value; }
    public short Charisma { get => charisma; set => charisma = value; }
    public short Physique { get => physique; set => physique = value; }

    // прибавить к параметрам
    public void addStrength(short n)
    {
        if (strength + n < 0)
        {
            strength = 0;
        }
        else
        {
            strength += n;
        }
    }

    public void addAgility(short n)
    {
        if (agility + n < 0)
        {
            agility = 0;
        }
        else
        {
            agility += n;
        }
    }

    public void addIntelect(short n)
    {
        if (intelect + n < 0)
        {
            intelect = 0;
        }
        else
        {
            intelect += n;
        }
    }

    public void addWisdom(short n)
    {
        if (wisdom + n < 0)
        {
            wisdom = 0;
        }
        else
        {
            wisdom += n;
        }
    }

    public void addCharisma(short n)
    {
        if (charisma + n < 0)
        {
            charisma = 0;
        }
        else
        {
            charisma += n;
        }
    }

    public void addPhysique(short n)
    {
        if (physique + n < 0)
        {
            physique = 0;
        }
        else
        {
            physique += n;
        }
    }

    /// <summary>
    /// ¬ывод модификатора характеристики
    /// по конечному значению характеристики 
    /// </summary>
    public short modifier(string name)
    {
        short n = 0;

        switch (name)
        {
            case "strength":
                n = strength;
                break;
            case "agility":
                n = agility;
                break;
            case "intelect":
                n = intelect;
                break;
            case "wisdom":
                n = wisdom;
                break;
            case "charisma":
                n = charisma;
                break;
            case "physique":
                n = physique;
                break;
            default:
                Debug.LogError(" поиск модификатора неизвестной характеристики");
                break;
        }

        switch (n)
        {
            case >= 0 and <= 1:
                return -5;
            case >= 2 and <= 3:
                return -4;
            case >= 4 and <= 5:
                return -3;
            case >= 6 and <= 7:
                return -2;
            case >= 8 and <= 9:
                return -1;
            case >= 10 and <= 11:
                return 0;
            case >= 12 and <= 13:
                return 1;
            case >= 14 and <= 15:
                return 2;
            case >= 16 and <= 17:
                return 3;
            case >= 18 and <= 19:
                return 4;
            case >= 20 and <= 21:
                return 5;
            case >= 22 and <= 23:
                return 6;
            case >= 24 and <= 25:
                return 7;
            case >= 26 and <= 27:
                return 8;
            case >= 28 and <= 29:
                return 9;
            case 30:
                return 10;
            default:
                Debug.LogError("превышенно значение характеристики в модификаторе");
                return 0;
        }
    }
}
