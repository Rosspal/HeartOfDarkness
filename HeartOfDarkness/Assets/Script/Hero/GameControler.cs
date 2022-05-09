using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    private bool checkTaverna = false;

    private void Start()
    {
        Gen = GetComponent<GenerateHero>();
        RefreshTaverna(); // ������ ���������� �������� ����������, �������� ������� ��� �� ������� upd: ��� ���
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("�������������");
            TC.Evil = TC.Friend;
            fight.BattleInit();
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("����������" + TC.Evil.GetHero(1).Health.Hp);
        }
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
            TC.Friend.AddHero(TavernaTeam.GetHero(number));
            return true;
        }
        return false;
        
    }

    public string[] FriendModelNameAll()
    {
        return TC.Friend.ModelNameAll();
    }

    public string[] EvilModelNameAll()
    {
        return TC.Friend.ModelNameAll();
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
        TC.Evil = TC.Friend;
        fight.BattleInit();
        GetComponent<CharacterDisplayBattle>().Display();
    }
}
