using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamContainer : MonoBehaviour
{
    public HeroTeam Evil = new HeroTeam(); // заменить
    public HeroTeam Friend = new HeroTeam();

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
