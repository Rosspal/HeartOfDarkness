using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControler : MonoBehaviour
{
    private EnemyTeam EnemyTeam;
    private HeroTeam Team = new HeroTeam();
    private HeroTeam TavernaTeam = new HeroTeam();
    private GenerateHero Gen = new GenerateHero();

    private bool checkTaverna = false;


    private void Start()
    {
    }

    private void Update()
    {

    }

    public void RefreshTaverna()
    {
        
        if (checkTaverna)
        {
            GetComponent<CharacterDisplay>().ClearDisplay();
            TavernaTeam.DeleteHeroAll();
            checkTaverna = false;
        }
        
        TavernaTeam.AddHero(Gen.Generate());
        TavernaTeam.AddHero(Gen.Generate());
        TavernaTeam.AddHero(Gen.Generate());
        TavernaTeam.AddHero(Gen.Generate());
        TavernaTeam.AddHero(Gen.Generate());

        Debug.Log(TavernaTeam.Info(0));
        Debug.Log(TavernaTeam.Info(1));
        Debug.Log(TavernaTeam.Info(2));
        Debug.Log(TavernaTeam.Info(3));

        GetComponent<CharacterDisplay>().Display(TavernaTeam.ModelNameAll());
        checkTaverna = true;
    }

}
