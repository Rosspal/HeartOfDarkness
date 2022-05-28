using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

public class GameControler : MonoBehaviour
{
    private GenerateHero Gen;

    /// <summary>
    /// ������ ���������� � ���� �������
    /// </summary>
    [SerializeField] TeamContainer TC;
    private HeroTeam TavernaTeam = new HeroTeam();
    private HeroTeam StockTeam = new HeroTeam();
    
    [SerializeField] Fight fight;
    [SerializeField] bool cheat;
    [SerializeField] double healingCost = 2;
    private string eventName = "";

    private bool checkTaverna = false;

    public string EventName { get => eventName; set => eventName = value; }

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
            TC.AddMoney(HealingCost());
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
            TC.AddMoney(-10);
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
                TC.AddMoney(-50);
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

    public void BattleCemeteryStart()
    {
        eventName = "��������";
        TC.Evil.AddHero(Gen.Generate("������", "������", 4));
        TC.Evil.GetHero(0).Modelname = TC.Evil.GetHero(0).Modelname + 1;
        TC.Evil.AddHero(Gen.Generate("������", "�����", 4));
        TC.Evil.GetHero(1).Modelname = TC.Evil.GetHero(1).Modelname + 1;
        TC.Evil.AddHero(Gen.Generate("������", "�����", 5));
        TC.Evil.GetHero(2).Modelname = TC.Evil.GetHero(2).Modelname + 1;
        TC.Evil.AddHero(Gen.Generate("������", "������", 5));
        TC.Evil.GetHero(3).Modelname = TC.Evil.GetHero(3).Modelname + 1;

        fight.BattleInit();
        GetComponent<CharacterDisplayBattle>().Display();
    }

    public void BattleStart(string str)
    {
        eventName = str;

        switch (str)
        {
            case "�������":
                TC.Evil.AddHero(Gen.Generate("������", "����", 3));
                TC.Evil.GetHero(0).Modelname = TC.Evil.GetHero(0).Modelname + 1;
                TC.Evil.AddHero(Gen.Generate("������", "����", 2));
                TC.Evil.GetHero(1).Modelname = TC.Evil.GetHero(1).Modelname + 1;
                TC.Evil.AddHero(Gen.Generate("������", "��������", 2));
                TC.Evil.GetHero(2).Modelname = TC.Evil.GetHero(2).Modelname + 1;
                TC.Evil.AddHero(Gen.Generate("������", "��������", 3));
                TC.Evil.GetHero(3).Modelname = TC.Evil.GetHero(3).Modelname + 1;
                break;
            case "����":
                break;
            default:
                if (TC.Friend.Count() != 1)
                {
                    int rand = 0;
                    rand = Random.Range(1, TC.Friend.Count() + 1);
                    for (int i = 0; i < rand; i++)
                    {
                        TC.Evil.AddHero(Gen.Generate(TC.AverageLevel()));
                        TC.Evil.GetHero(i).Modelname = TC.Evil.GetHero(i).Modelname + 1;
                    }
                }
                else
                {
                    TC.Evil.AddHero(Gen.Generate(TC.AverageLevel()));
                    TC.Evil.GetHero(0).Modelname = TC.Evil.GetHero(0).Modelname + 1;
                }
                
                break;
        }


        fight.BattleInit();
        GetComponent<CharacterDisplayBattle>().Display();
    }
}
