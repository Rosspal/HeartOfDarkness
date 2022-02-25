using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam : Team
{
    public new List<EnemyHero> team = new();


    public void AddHero(EnemyHero hero)
    {
        if (team.Count < 4)
        {
            team.Add(hero);
        }
    }

    public string Info(int i)
    {
        return team[i].Info();
    }

}
