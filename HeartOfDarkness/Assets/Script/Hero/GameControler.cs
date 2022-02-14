using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControler : MonoBehaviour
{
    private EnemyTeam EnemyTeam;
    private HeroTeam Team = new HeroTeam();
    private GenerateHero Gen = new GenerateHero();


    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Team.AddHero(Gen.Generate());
            Team.AddHero(Gen.Generate());
            Team.AddHero(Gen.Generate());
            Team.AddHero(Gen.Generate());

            Debug.Log(Team.Info(0));
            Debug.Log(Team.Info(1));
            Debug.Log(Team.Info(2));
            Debug.Log(Team.Info(3));

            GetComponent<CharacterDisplay>().Display(Team.ModelNameAll());
        }

        if (Input.GetMouseButtonDown(1))
        {
            GetComponent<CharacterDisplay>().ClearDisplay();
            Team.DeleteHero();
        }
    }

    
}
