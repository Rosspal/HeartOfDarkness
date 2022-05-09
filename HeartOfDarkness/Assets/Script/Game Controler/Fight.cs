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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Начало боя");
            Debug.Log("Количество " + TC.Friend.Count());
            Debug.Log("1) HP = " + TC.Friend.GetHero(0).Health.Hp + "; attack = " + TC.Friend.GetHero(0).Equipment.Hand.diceValue);
            Debug.Log("2) HP = " + TC.Evil.GetHero(1).Health.Hp + "; attack = " + TC.Evil.GetHero(1).Equipment.Hand.diceValue);
            activHero = 0;
            selectHero = 1;
            SpellAction(0);
            Debug.Log("new 1) HP = " + TC.Friend.GetHero(0).Health.Hp + "; ");
            Debug.Log("new 2) HP = " + TC.Evil.GetHero(1).Health.Hp + ";");
            
        }
    }


    public int Round { get => round; set => round = value; }

    public void Battle()
    {
    }

    public void BattleInit()
    {
        round = 1;
        initiative = order = new int[TC.Friend.Count() + TC.Evil.Count()];

        InitiativeRoll();
    }

    public void InitiativeRoll()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            initiative[i] = TC.Friend.GetHero(i).Initiative + Random.Range(1,21);
        }

        for (int i = TC.Friend.Count() - 1; i < initiative.Length; i++)
        {
            initiative[i] = TC.Friend.GetHero(i).Initiative + Random.Range(1, 21);
        }

        string str = "";
        for (int i = 0; i < initiative.Length; i++)
        {
            str += "initiative[" + i + "] = " + initiative[i] + "; ";
        }
        Debug.Log(str);
        Debug.Log("/////////////////////////////////////////");
        Debug.Log("");

        for (int i = 0; i < order.Length; i++)
        {
            int max = 0;
            int index = 0;
            for (int j = 0; j < initiative.Length; j++)
            {
                if (max < initiative[j])
                {
                    max = initiative[j];
                    index = j;
                }
            }
            initiative[index] = 0;
            order[i] = index;

            str = "";
            for (int l = 0; l < initiative.Length; l++)
            {
                str += i + ") " + "initiative[" + l + "] = " + initiative[l] + "; ";
            }
            Debug.Log(str);
        }
        Debug.Log("/////////////////////////////////////////");
        Debug.Log("");

        str = "";
        for (int i = 0; i < initiative.Length; i++)
        {
            str += "order[" + i + "] = " + order[i] + "; ";
        }
        Debug.Log(str);
    }

    public void NextMove()
    {

    }

    public void SpellAction(int n)
    {
        if (activHero < 4)
        {
            TC.Friend.GetHero(activHero).Spells[n].Action(ref TC.Friend, ref TC.Evil, activHero, selectHero);
        }
        else
        {
            int tempActivHero = activHero - 4;
            TC.Evil.GetHero(activHero).Spells[n].Action(ref TC.Evil, ref TC.Friend, activHero, selectHero);
        }
    }
}
