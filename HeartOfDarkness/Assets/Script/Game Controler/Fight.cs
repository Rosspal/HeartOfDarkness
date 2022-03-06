using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight : MonoBehaviour
{
    private int round;

    private EnemyTeam EnemyTeam;
    private HeroTeam Team = new HeroTeam();

    private int[] Initiative;


    public int Round { get => round; set => round = value; }

    public void Battle()
    {
        BattleInit();

    }

    private void BattleInit()
    {
        round = 1;
        Initiative = new int[Team.Count()];

    }

    private void InitiativeRoll()
    {

    }

    public void NextMove()
    {

    }
}
