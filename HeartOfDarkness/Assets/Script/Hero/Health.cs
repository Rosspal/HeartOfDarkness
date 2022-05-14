using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Health
{
    private short maxHP = 0;
    private short hp = 0;
    private short maxMP = 0;
    private short mp = 0;
    private short maxTempHP = 0; //подумать над её необходимотью
    private short tempHp = 0;
    private Point boneHits = new Point(0,0); // X - количество, Y - значение (1d8,2d12 ...)
    private short hpForLevel = 0;

    public delegate void handler(string code);
    public event handler Signal;

    /// <summary>
    /// конструктор 
    /// </summary>
    public Health(short _maxHp, short _hp, short _tempHp, int x, int y)
    {
        maxHP = _maxHp;
        hp = _hp;
        tempHp = _tempHp;
        boneHits.X = x;
        boneHits.Y = y;
    }


    public Health()
    {

    }

    
    public short MaxHP { get => maxHP; set => maxHP = value; }
    public short MaxTempHP { get => maxTempHP; set => maxTempHP = value; }
    public short TempHp { get => tempHp; set => tempHp = value; }
    public Point BoneHits { get => boneHits; set => boneHits = value; }
    public short Hp { get => hp; set => hp = value; }
    public short HpForLevel { get => hpForLevel; set => hpForLevel = value; }
    public short MaxMP { get => maxMP; set => maxMP = value; }
    public short Mp { get => mp; set => mp = value; }

    /// <summary>
    /// проверка умер ли герой
    /// </summary>
    private void CheckDead()
    {
        if (hp <= 0)
        {
            Signal?.Invoke("dead");
        }
    }

    public void SetHPOneLevel(short phy)
    {
        hp = maxHP = (short)(boneHits.Y + phy);
    }

    public void DamageHP(short n)
    {
        if (tempHp > 0)
        {
            tempHp -= n;
            if (tempHp < 0)
            {
                hp += tempHp; //прибавляем оставшийся урон к основному здоровью
                tempHp = 0;
                CheckDead();
            }
        }
        else
        {
            hp -= n;
            CheckDead();
        }
    }

    public void addHp(short n)
    {
        if (hp + n > maxHP)
        {
            hp = maxHP;
        }
        else
        {
            hp += n;
        }
    }  

    //кость хитов
    public void AddBone(int n)
    {
        boneHits.X += n;
    }

    public void SetBoneValue(int n)
    {
        boneHits.Y = n;
    }

    public void SetBoneCount(int n)
    {
        boneHits.X = n;
    }

    public void SetBone(int x, int y)
    {
        boneHits.X = x;
        boneHits.Y = y;
    }

    public int CountBone()
    {
        return boneHits.X;
    }

    public int BoneValue()
    {
        return boneHits.Y;
    }

    public string Info()
    {
        return maxHP + "/" + hp + "/" + tempHp + "/" + boneHits.X + "d" + boneHits.Y;
    }

    //public void DamageMP(short n)
    //{
    //        tempHp -= n;
    //        if (tempHp < 0)
    //        {
    //            hp += tempHp; //прибавляем оставшийся урон к основному здоровью
    //            tempHp = 0;
    //        }
    //}

    public void addMp(short n)
    {
        if (mp + n > maxMP)
        {
            mp = maxMP;
        }
        else
        {
            mp += n;
        }
    }
}
