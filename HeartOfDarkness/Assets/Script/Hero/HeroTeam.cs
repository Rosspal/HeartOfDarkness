using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTeam : Team
{
    public new List<Hero> team = new();
    public int count = 0;

    public void AddHero(Hero hero)
    {
        team.Add(hero);
        count++;
    }
}
