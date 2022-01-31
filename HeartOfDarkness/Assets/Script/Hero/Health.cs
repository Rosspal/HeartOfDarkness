using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Health : MonoBehaviour
{
    private short maxHP = 0;
    private short hp = 0;
    private short maxTempHP = 0; //подумать над её необходимотью
    private short tempHp = 0;
    private Point boneHits = new Point(0,0); // X - количество, Y - значение (1d8,2d12 ...)

    public delegate void handler(string code);
    public event handler Signal;

    public Health(short _maxHp, short _hp, short _tempHp, int x, int y)
    {
        maxHP = _maxHp;
        hp = _hp;
        tempHp = _tempHp;
        boneHits.X = x;
        boneHits.Y = y;
    }

    
    public short MaxHP { get => maxHP; set => maxHP = value; }
    public short MaxTempHP { get => maxTempHP; set => maxTempHP = value; }
    public short TempHp { get => tempHp; set => tempHp = value; }
    public Point BoneHits { get => boneHits; set => boneHits = value; }
    public short Hp { get => hp; set => hp = value; }

    /// <summary>
    /// проверка умер ли герой
    /// </summary>
    private void checkDead()
    {
        if (hp <= 0)
        {
            Signal?.Invoke("dead");
        }
    }

    public void damageHP(short n)
    {
        if (tempHp > 0)
        {
            tempHp -= n;
            if (tempHp < 0)
            {
                hp += tempHp; //прибавляем оставшийся урон к основному здоровью
                tempHp = 0;
                checkDead();
            }
        }
        else
        {
            hp -= n;
            checkDead();
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
    public void addBone(int n)
    {
        boneHits.X += n;
    }

    public void setBoneValue(int n)
    {
        boneHits.Y = n;
    }

    public void setBoneCount(int n)
    {
        boneHits.X = n;
    }

    public int countBone()
    {
        return boneHits.X;
    }

    public int boneValue()
    {
        return boneHits.Y;
    }
}
