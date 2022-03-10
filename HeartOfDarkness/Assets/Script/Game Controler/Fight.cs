using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    private int round;
    private int[] initiative;


    public int Round { get => round; set => round = value; }

    public void Battle()
    {
    }

    public void BattleInit(int e, int t)
    {
        round = 1;
        initiative = new int[e + t];
        InitiativeRoll();
    }

    public void InitiativeRoll()
    {
        for (int i = 0; i < 8; i++)
        {
            initiative[i] = i;
        }
    }

    public void NextMove()
    {

    }
}
