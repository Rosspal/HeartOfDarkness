using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamContainer : MonoBehaviour
{
    public HeroTeam Evil = new HeroTeam(); // заменить
    public HeroTeam Friend = new HeroTeam();

    [SerializeField] int money = 100;
    private int score = 0;
    [SerializeField] bool cheat = false;

    private string nameUser = "User";
    public string NameUser { get => nameUser; set => nameUser = value; }

    public int Money { get => money; }
    public int Score { get => score; }

    public void AddMoney(int n)
    {
        money += n;
        GetComponent<InfoUi>().Refresh();
    }
    public void AddScore(int n)
    {
        score += n;
        GetComponent<InfoUi>().Refresh();
    }


    private void Update()
    {
        if (cheat)
        {
            for (int i = 0; i < Evil.Count(); i++)
            {
                Evil.GetHero(i).Health.Hp = 1;
            }
            cheat = false;
        }
    }

    public int AverageLevel()
    {
        int result = 1;
        for (int i = 0; i < Friend.Count(); i++)
        {
            result += Friend.GetHero(i).Level;
        }
        result /= Friend.Count();
        return result;
    }

    /// <summary>
    /// Удалить всех мёртвых в обеих командах
    /// </summary>
    public void TheFuneral()
    {
        int i = 0;
        while (Friend.Count() > i)
        {
            if (Friend.GetHero(i).Health.Hp <= 0)
            {
                Friend.DeleteHero(i);
                i--;
            }
            i++;
        }

        Evil.DeleteHeroAll();
    }

    public int MissingHealth()
    {
        int result = 0;
        for (int i = 0; i < Friend.Count(); i++)
        {
            result += Friend.GetHero(i).Health.MaxHP - Friend.GetHero(i).Health.Hp;
        }
        return result;
    }

    public void ResetCoolDown(int n)
    {
        if (n < Friend.Count())
        {
            for (int i = 0; i < Friend.GetHero(n).Spells.Count; i++)
            {
                Friend.GetHero(n).Spells[i].CoolDownTemp = 0;
            } 
        }
        else
        {
            for (int i = 0; i < Evil.GetHero(n).Spells.Count; i++)
            {
                Evil.GetHero(n).Spells[i].CoolDownTemp = 0;
            }
        }
    }

    /// <summary>
    /// Возвращает героя по его индексу
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
    /// Возвращает команду в которой находится выбранный герой
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
