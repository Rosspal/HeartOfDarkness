using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamContainer : MonoBehaviour
{
    public HeroTeam Evil = new HeroTeam(); // ��������
    public HeroTeam Friend = new HeroTeam();

    /// <summary>
    /// ���������� ����� �� ��� �������
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public Hero GetHero(int n)
    {
        if (n > 3)
        {
            return Evil.GetHero(n - 4);
        }
        else
        {
            return Friend.GetHero(n);
        }
    }
    
    /// <summary>
    /// ���������� ������� � ������� ��������� ��������� �����
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public HeroTeam GetActivTeam(int n)
    {
        if (n > 3)
        {
            return Evil;
        }
        else
        {
            return Friend;
        }
    }
}
