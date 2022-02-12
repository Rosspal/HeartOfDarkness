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
            team.Add(hero);
        }
    }

    public void DeleteHero()
    {
        team.Clear(); 
    }

    public string Info(int i)
    {
        return team[i].Info();
    }
}
