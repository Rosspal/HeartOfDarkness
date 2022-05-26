using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameControler : MonoBehaviour
{
    private GenerateHero Gen;

    /// <summary>
    /// Объект содержащий в себе команды
    /// </summary>
    [SerializeField] TeamContainer TC;
    private HeroTeam TavernaTeam = new HeroTeam();
    private HeroTeam StockTeam = new HeroTeam();
    
    [SerializeField] Fight fight;
    [SerializeField] bool cheat;
    [SerializeField] double healingCost = 2;

    private bool checkTaverna = false;

    private void Start()
    {
        Gen = GetComponent<GenerateHero>();


        TC.Friend.AddHero(Gen.Generate());
        TC.Friend.GetHero(0).Modelname = TC.Friend.GetHero(0).Modelname + 1;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("////////////////////////");
            Debug.Log("Friend");
            Debug.Log("Name = " + TC.Friend.GetHero(0).Nickname + " ModelName = " + TC.Friend.GetHero(0).Modelname);
            Debug.Log("Name = " + TC.Friend.GetHero(1).Nickname + " ModelName = " + TC.Friend.GetHero(1).Modelname);
            Debug.Log("Name = " + TC.Friend.GetHero(2).Nickname + " ModelName = " + TC.Friend.GetHero(2).Modelname);
            Debug.Log("Name = " + TC.Friend.GetHero(3).Nickname + " ModelName = " + TC.Friend.GetHero(3).Modelname);
            Debug.Log("////////////////////////");
            Debug.Log("Evil");
            Debug.Log("Name = " + TC.Evil.GetHero(0).Nickname + " ModelName = " + TC.Evil.GetHero(0).Modelname);
            Debug.Log("Name = " + TC.Evil.GetHero(1).Nickname + " ModelName = " + TC.Evil.GetHero(1).Modelname);
            Debug.Log("Name = " + TC.Evil.GetHero(2).Nickname + " ModelName = " + TC.Evil.GetHero(2).Modelname);
            Debug.Log("Name = " + TC.Evil.GetHero(3).Nickname + " ModelName = " + TC.Evil.GetHero(3).Modelname);
            Debug.Log("////////////////////////");
        }

        if (cheat)
        {
            TC.Friend.AddHero(Gen.Generate());
            TC.Friend.GetHero(1).Modelname = TC.Friend.GetHero(1).Modelname + 1;
            cheat = false;
        }
    }

    public int HealingCost()
    {
        return (int)(TC.MissingHealth() * healingCost);
    }

    public void HospitalWork()
    {
        if (TC.Money >= HealingCost())
        {
            TC.Money -= HealingCost();
            GetComponent<InfoUi>().Refresh();
            GetComponent<ManagerUiTown>().RefreshHealingCost();
            TC.Friend.HealTeam();
        }
        GetComponent<ManagerUiTown>().RefreshHealingCost();
    }

    public bool RefreshTaverna()
    {
        if (TC.Money >= 10)
        {
            TC.Money -= 10;
            GetComponent<InfoUi>().Refresh();
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

            GetComponent<CharacterDisplay>().Display(TavernaTeam.ModelNameAll());
            checkTaverna = true;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void FreeRefreshTaverna()
    {
            //TC.Money -= 10;
            GetComponent<InfoUi>().Refresh();
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

            GetComponent<CharacterDisplay>().Display(TavernaTeam.ModelNameAll());
            checkTaverna = true;
    }

    public bool checkFreePlace()
    {
        if ((TC.Friend.Count() < 4)||( StockTeam.Count() == 6))
        {
            return true;
        }
        return false;
    }

    public bool BuyHero(int number)
    {
        if (checkFreePlace())
        {
            if (TC.Money >= 50)
            {
                TC.Money -= 50;
                GetComponent<InfoUi>().Refresh();
                TC.Friend.AddHero(TavernaTeam.GetHero(number));
                return true;
            }
            else
            {
                return false;
            }

        }
        return false;
        
    }

    public string[] FriendModelNameAll()
    {
        return TC.Friend.ModelNameAll();
    }

    public string[] EvilModelNameAll()
    {
        return TC.Evil.ModelNameAll();
    }

    public Hero GetTavernHero(int n)
    {
        return TavernaTeam.GetHero(n);
    }

    public Hero GetHero(int n)
    {
        return TC.Friend.GetHero(n);
    }

    public Hero GetStockHero(int n)
    {
        return StockTeam.GetHero(n);
    }

    public void SetHeroModelName(string name, int k)
    {
        TavernaTeam.GetHero(k).Modelname = name;
    }

    public void BattleStart()
    {
        //TC.Friend.AddHero(Gen.Generate("Человек","Волшебник"));
        //TC.Friend.GetHero(0).Modelname = TC.Friend.GetHero(0).Modelname + 1;
        //TC.Friend.GetHero(0).Health.MaxHP = 100;
        //TC.Friend.GetHero(0).Health.Hp = 100;
        //TC.Friend.GetHero(0).Equipment.Hand.diceCount = 20;
        //TC.Friend.GetHero(0).Equipment.Hand.diceValue = 20;
        //Debug.Log("dice count = " + TC.Friend.GetHero(0).Equipment.Hand.diceCount + "value = TC.Friend.GetHero(0).Equipment.Hand.diceValue");
        //TC.Friend.AddHero(Gen.Generate());
        //TC.Friend.GetHero(1).Modelname = TC.Friend.GetHero(1).Modelname + 1;
        //TC.Friend.AddHero(Gen.Generate());
        //TC.Friend.GetHero(2).Modelname = TC.Friend.GetHero(2).Modelname + 1;
        //TC.Friend.AddHero(Gen.Generate());
        //TC.Friend.GetHero(3).Modelname = TC.Friend.GetHero(3).Modelname + 1;

        TC.Evil.AddHero(Gen.Generate());
        TC.Evil.GetHero(0).Modelname = TC.Evil.GetHero(0).Modelname + 1;
        TC.Evil.AddHero(Gen.Generate());
        TC.Evil.GetHero(1).Modelname = TC.Evil.GetHero(1).Modelname + 1;
        TC.Evil.GetHero(0).Health.Hp = 1;
        TC.Evil.GetHero(1).Health.Hp = 1;
        //TC.Evil.AddHero(Gen.Generate());
        //TC.Evil.GetHero(2).Modelname = TC.Evil.GetHero(2).Modelname + 1;
        //TC.Evil.AddHero(Gen.Generate());
        //TC.Evil.GetHero(3).Modelname = TC.Evil.GetHero(3).Modelname + 1;

        fight.BattleInit();
        GetComponent<CharacterDisplayBattle>().Display();
    }
}
