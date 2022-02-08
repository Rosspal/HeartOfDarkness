using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    private EnemyTeam EnemyTeam;
    private HeroTeam Team = new HeroTeam();
    private GenerateHero Gen = new GenerateHero();


    private void Start()
    {
        Team.AddHero(Gen.Generate());
        Debug.Log(Team.Info());
    }
}
