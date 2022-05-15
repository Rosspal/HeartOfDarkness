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
        if (n >= Friend.Count())
        {
            return Evil.GetHero(n - Friend.Count());
        }
        else
        {
            return Friend.GetHero(n);
        }
    }

    /// <summary>
    /// hero count teams
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return Evil.Count() + Friend.Count();
    }

    public Hero GetHeroSelected(int n)
    {
        if (n >= Friend.Count())
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
        if (n > Friend.Count())
        {
            return Evil;
        }
        else
        {
            return Friend;
        }
    }

    public string GetActivTeamName(int n)
    {
        if (n >= Friend.Count())
        {
            return "Evil";
        }
        else
        {
            return "Friend";
        }
    }
}
