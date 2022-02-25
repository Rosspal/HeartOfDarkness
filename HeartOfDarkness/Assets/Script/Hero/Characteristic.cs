using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristic
{
    private short strength = 0;
    private short agility = 0;
    private short intelect = 0;
    private short wisdom = 0;
    private short charisma = 0;
    private short physique = 0;

    private bool ownStrength = false;
    private bool ownAgility = false;
    private bool ownIntelect = false;
    private bool ownWisdom = false;
    private bool ownCharisma = false;
    private bool ownPhysique = false;

    public short Strength { get => strength; set => strength = value; }
    public short Agility { get => agility; set => agility = value; }
    public short Intelect { get => intelect; set => intelect = value; }
    public short Wisdom { get => wisdom; set => wisdom = value; }
    public short Charisma { get => charisma; set => charisma = value; }
    public short Physique { get => physique; set => physique = value; }

    public void SetCharacteristic(short str, short agi, short intel, short wis, short charis, short phy)
    {
        strength = str;
        agility = agi;
        intelect = intel;
        wisdom = wis;
        charisma = charis;
        physique = phy;
    }


    /// <summary>
    /// 1)strength 2)agility 3)intelect
    /// 4)wisdom 5)charisma 6)physique
    /// </summary>
    /// <param name="number"></param>
    /// <param name="k"></param>
    public void AddByNumber(short number, short k)
    {
        switch (number)
        {
            case 1:
                strength += k;
                break;
            case 2:
                agility += k;
                break;
            case 3:
                intelect += k;
                break;
            case 4:
                wisdom += k;
                break;
            case 5:
                charisma += k;
                break;
            case 6:
                physique += k;
                break;
        }
    }

    public void AddAll(short n)
    {
        strength += n;
        agility += n;
        intelect += n;
        wisdom += n;
        charisma += n;
        physique += n;
    }

    // прибавить к параметрам
    public void AddStrength(short n)
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

    public void AddAgility(short n)
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

    public void AddIntelect(short n)
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

    public void AddWisdom(short n)
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

    public void AddCharisma(short n)
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

    public void AddPhysique(short n)
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
    public short Modifier(string name, short bonus)
    {
        short n = 0;
        short bm = 0; // бонус мастерства что прибавитьс€
        switch (name)
        {
            case "Strength":
                n = strength;
                if (ownStrength)
                {
                    bm = bonus;
                }
                break;
            case "Agility":
                if (ownAgility)
                {
                    bm = bonus;
                }
                n = agility;
                break;
            case "Intelect":
                if (ownIntelect)
                {
                    bm = bonus;
                }
                n = intelect;
                break;
            case "Wisdom":
                if (ownWisdom)
                {
                    bm = bonus;
                }
                n = wisdom;
                break;
            case "Charisma":
                if (ownCharisma)
                {
                    bm = bonus;
                }
                n = charisma;
                break;
            case "Physique":
                if (ownPhysique)
                {
                    bm = bonus;
                }
                n = physique;
                break;
            default:
                Debug.LogError(" поиск модификатора неизвестной характеристики");
                break;
        }


        switch (n)
        {
            case >= 0 and <= 1:
                return (short)(-5 + bm);
            case >= 2 and <= 3:
                return (short)(-4 + bm);
            case >= 4 and <= 5:
                return (short)(-3 + bm);
            case >= 6 and <= 7:
                return (short)(-2 + bm);
            case >= 8 and <= 9:
                return (short)(-1 + bm);
            case >= 10 and <= 11:
                return (short)(0 + bm);
            case >= 12 and <= 13:
                return (short)(1 + bm);
            case >= 14 and <= 15:
                return (short)(2 + bm);
            case >= 16 and <= 17:
                return (short)(3 + bm);
            case >= 18 and <= 19:
                return (short)(4 + bm);
            case >= 20 and <= 21:
                return (short)(5 + bm);
            case >= 22 and <= 23:
                return (short)(6 + bm);
            case >= 24 and <= 25:
                return (short)(7 + bm);
            case >= 26 and <= 27:
                return (short)(8 + bm);
            case >= 28 and <= 29:
                return (short)(9 + bm);
            case 30:
                return (short)(10 + bm);
            default:
                Debug.LogError("превышенно значение характеристики в модификаторе");
                return 0;
        }
    }

    public short Modifier(string name)
    {
        short n = 0;
        switch (name)
        {
            case "Strength":
                n = strength;
                break;
            case "Agility":
                n = agility;
                break;
            case "Intelect":
                n = intelect;
                break;
            case "Wisdom":
                n = wisdom;
                break;
            case "Charisma":
                n = charisma;
                break;
            case "Physique":
                n = physique;
                break;
            default:
                Debug.LogError(" поиск модификатора неизвестной характеристики");
                break;
        }


        switch (n)
        {
            case >= 0 and <= 1:
                return 5;
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

    public string Info()
    {
        return strength + "/" + agility + "/" + intelect + "/" + wisdom + "/" + charisma + "/" + physique;
    }
}
