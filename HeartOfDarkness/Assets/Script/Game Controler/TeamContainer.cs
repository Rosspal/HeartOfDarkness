using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamContainer : MonoBehaviour
{
    public HeroTeam Evil = new HeroTeam(); // заменить
    public HeroTeam Friend = new HeroTeam();

    private int money = 100;

    public int Money { get => money; set => money = value; }

    /// <summary>
    /// ¬озвращает геро€ по его индексу
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public Hero GetHero(int n)
    {
        if (n >= Friend.Count())
        {
            return Evil.GetHero(n - Friend.Count());
        }
        else
        {
            return Friend.GetHero(n);
        }
    }

    /// <summary>
    /// hero count teams
    /// </summary>
    /// <returns></returns>
    public int Count()
    {
        return Evil.Count() + Friend.Count();
    }

    public bool CheckDeathFriend()
    {
        for (int i = 0; i < Friend.Count(); i++)
        {
            if (Friend.GetHero(i).Health.Hp > 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool CheckDeathEvil()
    {
        for (int i = 0; i < Evil.Count(); i++)
        {
            if (Evil.GetHero(i).Health.Hp > 0)
            {
                return false;
            }
        }
        return true;
    }

    public Hero GetHeroSelected(int n)
    {
        if (n >= Friend.Count())
        {
            return Evil.GetHero(n - 4);
        }
        else
        {
            return Friend.GetHero(n);
        }
    }

    /// <summary>
    /// ¬озвращает команду в которой находитс€ выбранный герой
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public HeroTeam GetActivTeam(int n)
    {
        if (n > Friend.Count())
        {
            return Evil;
        }
        else
        {
            return Friend;
        }
    }

    public string GetActivTeamName(int n)
    {
        if (n >= Friend.Count())
        {
            return "Evil";
        }
        else
        {
            return "Friend";
        }
    }
}
