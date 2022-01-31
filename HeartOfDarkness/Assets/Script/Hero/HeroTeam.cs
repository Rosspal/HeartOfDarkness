using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTeam : Team
{
    public new List<Hero> team = new()
        {
            new Hero(),
            new Hero(),
            new Hero(),
            new Hero()
        };
}
