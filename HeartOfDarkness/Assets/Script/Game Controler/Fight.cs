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
        if (activHero >= TC.Friend.Count())
        {
            EnemyTurn();
        }
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

        int randId = Random.Range(0, TC.Friend.Count());
        initiative[randId] += 40;

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
    }

    /// <summary>
    /// уменьшает все кд на 1
    /// </summary>
    public void CoolDown()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            for (int j = 0; j < TC.Friend.GetHero(i).Spells.Count; j++)
            {
                if (TC.Friend.GetHero(i).Spells[j].CoolDownTemp == 0)
                {

                }
                else
                {
                    TC.Friend.GetHero(i).Spells[j].CoolDownTemp -= 1;
                }
                
            }
        }

        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            for (int j = 0; j < TC.Evil.GetHero(i).Spells.Count; j++)
            {
                if (TC.Evil.GetHero(i).Spells[j].CoolDownTemp == 0)
                {

                }
                else
                {
                    TC.Evil.GetHero(i).Spells[j].CoolDownTemp -= 1;
                }

            }
        }
    }

    public void ScopeBattle()
    {
        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            if (TC.Evil.GetHero(i).Health.Hp <= 0)
            {
                TC.Score += 25;
            }
        }
    }

    public void Win()
    {
        int tempRand = Random.Range(10, 25);
        TC.Money += tempRand * TC.Evil.Count();
        ScopeBattle();
        TC.Score += TC.Evil.Count() * 45;
        GetComponent<InfoUi>().Refresh();
        ResetBattle();
        GetComponent<UiEventManager>().CloseBattleEvent();
    }

    public void NextMove()
    {
        if (TC.CheckDeathFriend())
        {
            ScopeBattle();
            GetComponent<InfoUi>().Refresh();
            Ui.Defeat();
        }
        else
        {
            if (TC.CheckDeathEvil())
            {
                Win();
            }
            else
            {
                if (activHeroId == (order.Length - 1))
                {
                    CoolDown();
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
                    NextMove();
                }
                else
                {
                    Ui.ActivHero(activHero, NextHero());
                    Ui.InitInfoPanel(activHero);
                    if (activHero >= TC.Friend.Count())
                    {
                        EnemyTurn();
                    }
                }
                
                
            }
        }  
    }

    public void EnemyTurn()
    {
        int target = 0;
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            if (TC.Friend.GetHero(i).Health.Hp > 0)
            {
                target = i;
            }
        }
        selectHero = target;
        SpellAction(0);

            //selectHero = target;
            //if (TC.Evil.GetHero(activHero).Spells[1].target != "Heal")
            //{
            //    if (TC.Evil.GetHero(activHero).Spells[1].coolDownTemp == 0)
            //    {
            //        SpellAction(1);
            //    }
            //    else
            //    {
            //        SpellAction(0);
            //    }
            //}
            //else
            //{
            //    if (TC.Evil.GetHero(activHero).Health.Hp == TC.Evil.GetHero(activHero).Health.MaxHP)
            //    {
            //        SpellAction(0);
            //    }
            //    else
            //    {
            //        SpellAction(1);
            //    }
            //}
    }

    public void SetSelected(int n)
    {
        selectHero = n;
    }

    public void ResetBattle()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            TC.ResetCoolDown(i);
        }
        GetComponent<CharacterDisplayBattle>().ClearDisplay();
        Ui.ResetLog();
        Ui.ResetState();
        Ui.ResetHealtSystem();
        TC.TheFuneral();
        
    }

    public void CheckDeath()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            if (TC.Friend.GetHero(i).Health.Hp <= 0)
            {
                GetComponent<CharacterDisplayBattle>().DeadHero(i);
            }
        }

        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            if (TC.Evil.GetHero(i).Health.Hp <= 0)
            {
                GetComponent<CharacterDisplayBattle>().DeadHero(i + 4);
            }
        }
    }

    public void SpellAction(int n)
    {
        if (TC.GetHeroSelected(selectHero).Health.Hp > 0)
        {
            if (n < TC.GetHero(activHero).Spells.Count)
            {
                if (TC.GetHero(activHero).Spells[n].coolDownTemp == 0)
                {
                    int temp = 0;
                    if (activHero >= TC.Friend.Count())
                    {
                        temp = 4 - TC.Friend.Count();
                    }
                    GetComponent<CharacterDisplayBattle>().AttackHero(activHero + temp);

                    Ui.WriteLog(TC.GetHero(activHero).Spells[n].Action(ref TC, activHero, selectHero));
                    Ui.RefreshHealt();
                    CheckDeath();
                    StartCoroutine(ExampleCoroutine());
                }
                else
                {
                    Ui.WriteLog("Способность на перезарядке ещё " + TC.GetHero(activHero).Spells[n].coolDownTemp + " ход(а)");
                }
            }
            else
            {
                Ui.WriteLog("Способность закрыта");
            }
        }
        else
        {
            Ui.WriteLog("Цель уже мертва");
            Debug.Log("hp = " + TC.GetHero(selectHero).Health.Hp + "; modelname = " + TC.GetHero(selectHero).Modelname + "; selectHero = " + selectHero);
        }
        
        
        
    }

    IEnumerator ExampleCoroutine()
    {
        Ui.NoButtom();
        yield return new WaitForSeconds(1.5f);
        Ui.YesButtom();
        NextMove();
        
    }
}


