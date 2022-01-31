using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTeam : Team
{
    public new List<EnemyHero> team = new()
    {
        new EnemyHero(),
        new EnemyHero(),
        new EnemyHero(),
        new EnemyHero()
    };
}
