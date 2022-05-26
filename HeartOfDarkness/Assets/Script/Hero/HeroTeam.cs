using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTeam : Team
{
    public new List<Hero> team = new();

    public void AddHero(Hero hero)
    {
        if (team.Count < 4)
        {
            team.Add(hero);// ����������
        }
    }

    public void HealTeam()
    {
        for (int i = 0; i < team.Count; i++)
        {
            team[i].Health.Hp = team[i].Health.MaxHP;
        }
    }

    public int Count()
    {
        return team.Count;
    }

    public void DeleteHeroAll()
    {
        if (team.Count != 0)
        {
            team.Clear();
        }
    }

    public void DeleteHero(int n)
    {
        if (team.Count > n)
        {
            team.RemoveAt(n);
        }
        
    }

    public string Info(int i)
    {
        return team[i].Info();
    }

    public string[] ModelNameAll()
    {
        string[] result = new string[team.Count];
        int count = 0;

        foreach (var hero in team)
        {
            result[count] = hero.Modelname;
            count++;
        }

        return result;
    }

    public Hero GetHero(int n)
    {
        if (team.Count > n)
        {
            return team[n];
        }
        Hero hero = new Hero();
        hero.Nickname = "Void";
        return hero; // �������� ������
    }
}
