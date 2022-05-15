using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiFigh : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Log;
    [SerializeField] Canvas Canvas;
    [SerializeField] TeamContainer TC;
    [SerializeField] GameObject[] ready = new GameObject[8];
    [SerializeField] GameObject[] Preparation = new GameObject[8];
    [SerializeField] GameObject[] Waiting = new GameObject[8];


    public void ActivHero(int n, int n2)
    {
        InitState();
        //ready
        if (TC.GetActivTeamName(n) == "Friend")
        {
            Debug.Log("friend n = " + n);
            ready[n].SetActive(true);
            Preparation[n].SetActive(false);
            Waiting[n].SetActive(false);
            
        }
        else
        {
            int temp = 4 - TC.Friend.Count();
            ready[n + temp].SetActive(true);
            Preparation[n + temp].SetActive(false);
            Waiting[n + temp].SetActive(false);
        }

        //prep
        if (TC.GetActivTeamName(n2) == "Friend")
        {
            ready[n2].SetActive(false);
            Preparation[n2].SetActive(true);
            Waiting[n2].SetActive(false);

        }
        else
        {
            int temp = 4 - TC.Friend.Count();
            ready[n2 + temp].SetActive(false);
            Preparation[n2 + temp].SetActive(true);
            Waiting[n2 + temp].SetActive(false);
        }
    }

    public void InitInfoPanel(int n)
    {
        Canvas.transform.Find("Panel").Find("InfoPanel").Find("Text").GetComponent<TextMeshProUGUI>().text = "Сила " + TC.GetHero(n).Characteristic.Strength + "\n"
                                                                                                             + "Ловкость " + TC.GetHero(n).Characteristic.Agility + "\n"
                                                                                                             + "Интелект " + TC.GetHero(n).Characteristic.Intelect + "\n"
                                                                                                             + "Мудрость " + TC.GetHero(n).Characteristic.Wisdom + "\n"
                                                                                                             + "Выносливость " + TC.GetHero(n).Characteristic.Physique + "\n"
                                                                                                             + "Харизма " + TC.GetHero(n).Characteristic.Charisma;
    }

    public void InitState()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            Waiting[i].SetActive(true);
            ready[i].SetActive(false);
            Preparation[i].SetActive(false);
        }

        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            Waiting[i + 4].SetActive(true);
            ready[i + 4].SetActive(false);
            Preparation[i + 4].SetActive(false);
        }
    }

    public void RefreshHealtSystem()
    {
        for (int i = 0; i < 4; i++)
        {
            if (TC.Friend.GetHero(i).Nickname == "Void")
            {
                Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).Find("Bar").gameObject.SetActive(false);
            }
            else
            {
                Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).GetComponent<HealthSystem>().SetSystem(TC.Friend.GetHero(i).Health.Hp,
                                                                                                                                    TC.Friend.GetHero(i).Health.MaxHP,
                                                                                                                                    TC.Friend.GetHero(i).Health.Mp,
                                                                                                                                    TC.Friend.GetHero(i).Health.MaxMP
                                                                                                                                    );
            }
        }

        for (int i = 0; i < 4; i++)
        {
            if (TC.Evil.GetHero(i).Nickname == "Void")
            {
                Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).Find("Bar").gameObject.SetActive(false);
            }
            else
            {
                Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).GetComponent<HealthSystem>().SetSystem(TC.Evil.GetHero(i).Health.Hp,
                                                                                                                                    TC.Evil.GetHero(i).Health.MaxHP,
                                                                                                                                    TC.Evil.GetHero(i).Health.Mp,
                                                                                                                                    TC.Evil.GetHero(i).Health.MaxMP
                                                                                                                                    );
            }
        }
    }

    public void RefreshHealt()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).GetComponent<HealthSystem>().SetHpMp(TC.Friend.GetHero(i).Health.Hp,
                                                                                                                                  TC.Friend.GetHero(i).Health.MaxMP
                                                                                                                                  );
        }

        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).GetComponent<HealthSystem>().SetHpMp(TC.Evil.GetHero(i).Health.Hp,
                                                                                                                                    TC.Evil.GetHero(i).Health.MaxMP
                                                                                                                                  );
        }
    }

    public void InitHealthSystem()
    {

    }

    public void RefreshHealtSystem(int n)
    {

    }

    public void WriteLog(string str)
    {
       Log.text = str;
    }

    public void WriteLineLog(string str)
    {
        Log.text +="\n" + str;
    }
}
