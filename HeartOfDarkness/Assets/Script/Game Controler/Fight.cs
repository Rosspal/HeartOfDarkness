using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    private int round;
    private int[] initiative;
    private int[] order;
    private int activHero = 0;
    private int selectHero = 0;
    private int activHeroId = 0;
    [SerializeField] TeamContainer TC;
    [SerializeField] UiFigh Ui;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("////////////////////////");
            Debug.Log("Friend");
            Debug.Log("Name = " + TC.Friend.GetHero(0).Nickname + " ModelName = " + TC.Friend.GetHero(0).Modelname);
            Debug.Log("Name = " + TC.Friend.GetHero(1).Nickname + " ModelName = " + TC.Friend.GetHero(1).Modelname);
            Debug.Log("Name = " + TC.Friend.GetHero(2).Nickname + " ModelName = " + TC.Friend.GetHero(2).Modelname);
            Debug.Log("Name = " + TC.Friend.GetHero(3).Nickname + " ModelName = " + TC.Friend.GetHero(3).Modelname);
            Debug.Log("////////////////////////");
            Debug.Log("Evil");
            Debug.Log("Name = " + TC.Evil.GetHero(0).Nickname + " ModelName = " + TC.Friend.GetHero(0).Modelname);
            Debug.Log("Name = " + TC.Evil.GetHero(1).Nickname + " ModelName = " + TC.Friend.GetHero(1).Modelname);
            Debug.Log("Name = " + TC.Evil.GetHero(2).Nickname + " ModelName = " + TC.Friend.GetHero(2).Modelname);
            Debug.Log("Name = " + TC.Evil.GetHero(3).Nickname + " ModelName = " + TC.Friend.GetHero(3).Modelname);
            Debug.Log("////////////////////////");
        }
    }


    public int Round { get => round; set => round = value; }

    public void Battle()
    {
    }

    public void BattleInit()
    {
        round = 1;
        initiative = new int[TC.Friend.Count() + TC.Evil.Count()];
        order = new int[TC.Friend.Count() + TC.Evil.Count()];
        Ui.RefreshHealtSystem();

        InitiativeRoll();
        activHero = order[0];
        activHeroId = 0;
        Ui.InitState();
        Ui.ActivHero(activHero, NextHero());
        Ui.InitInfoPanel(activHero);
    }

    public int NextHero()
    {
        if (activHeroId == (order.Length - 1))
        {
            return order[0];
        }
        else
        {
            return order[activHeroId + 1];
        } 
    }

    public void InitiativeRoll()
    {
        for (int i = 0; i < TC.Count(); i++)
        {
            int rand = Random.Range(1, 21);
            initiative[i] = TC.GetHero(i).Initiative + rand;
        }
        string str = "order = ";
        for (int i = 0; i < order.Length; i++)
        {
            int max = 0;
            int index = 0;

            for (int j = 0; j < initiative.Length; j++)
            {
                if (initiative[j] > max)
                {
                    max = initiative[j];
                    index = j;
                }
            }

            initiative[index] = 0;
            order[i] = index;
            str += order[i];
        }
        Debug.Log(str);
    }

    public void NextMove()
    {
        if (activHeroId == (order.Length - 1))
        {
            activHero = order[0];
            activHeroId = 0;
        }
        else
        {
            activHeroId++;
            activHero = order[activHeroId];
        }
        if (TC.GetHero(activHero).Health.Hp <= 0)
        {
            Debug.Log("Hp = " + TC.GetHero(activHero).Health.Hp);
            NextMove();
        }

        Ui.ActivHero(activHero,NextHero());
        Ui.InitInfoPanel(activHero);
    }

    public void SetSelected(int n)
    {
        selectHero = n;
    }

    public void SpellAction(int n)
    {
        Debug.Log("activ = " + activHero + "; select = " + selectHero);
        Ui.WriteLog(TC.GetHero(activHero).Spells[n].Action(ref TC, activHero, selectHero));

        Ui.RefreshHealt();
        NextMove();
    }
}
