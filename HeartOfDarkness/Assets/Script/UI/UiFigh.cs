using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiFigh : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Log;
    [SerializeField] Canvas Canvas;
    [SerializeField] TeamContainer TC;

    public void RefreshHealtSystem()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).GetComponent<HealthSystem>().SetSystem(TC.Friend.GetHero(i).Health.Hp, 
                                                                                                                                    TC.Friend.GetHero(i).Health.MaxHP,
                                                                                                                                    TC.Friend.GetHero(i).Health.Mp,
                                                                                                                                    TC.Friend.GetHero(i).Health.MaxMP
                                                                                                                                    );
            if (TC.Friend.GetHero(i).Health.Hp == 0)
            {
                Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).gameObject.SetActive(false);
            }
        }

        for (int i = 0; i < TC.Evil.Count(); i++)
        {
            Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).GetComponent<HealthSystem>().SetSystem(TC.Evil.GetHero(i).Health.Hp,
                                                                                                                                    TC.Evil.GetHero(i).Health.MaxHP,
                                                                                                                                    TC.Evil.GetHero(i).Health.Mp,
                                                                                                                                    TC.Evil.GetHero(i).Health.MaxMP
                                                                                                                                    );
            if (TC.Evil.GetHero(i).Health.Hp == 0)
            {
                Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).gameObject.SetActive(false);
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
