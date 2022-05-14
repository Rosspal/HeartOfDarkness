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

        //InitiativeRoll();

    }

    public void InitiativeRoll()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            int temp = Random.Range(1, 21);
            initiative[i] = TC.Friend.GetHero(i).Initiative + temp;
        }

        for (int i = TC.Evil.Count(); i < initiative.Length; i++)
        {
            int temp = Random.Range(1, 21);
            initiative[i] = TC.Evil.GetHero(i - 4).Initiative + temp;
        }


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
        }
    }

    public void NextMove()
    {

    }

    public void SetSelected(int n)
    {
        selectHero = n;
    }

    public void SpellAction(int n)
    {
        if (activHero < 4)
        {
            Ui.WriteLog(TC.Friend.GetHero(activHero).Spells[n].Action(ref TC, activHero, selectHero));
        }
        else
        {
            int tempActivHero = activHero - 4;
            Ui.WriteLog(TC.Evil.GetHero(activHero).Spells[n].Action(ref TC, activHero, selectHero));
        }

        Ui.RefreshHealt();
    }
}
