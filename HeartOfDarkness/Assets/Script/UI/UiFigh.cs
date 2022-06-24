using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UiFigh : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Log;
    [SerializeField] Canvas Canvas;
    [SerializeField] TeamContainer TC;
    [SerializeField] GameObject[] ready = new GameObject[8];
    [SerializeField] GameObject[] Preparation = new GameObject[8];
    [SerializeField] GameObject[] Waiting = new GameObject[8];
    [SerializeField] Image Portret;

    private int count = 0;



    public void ActivHero(int n, int n2)
    {
        InitState();
        //ready
        if (TC.GetActivTeamName(n) == "Friend")
        {
            ready[n].SetActive(true);
            Preparation[n].SetActive(false);
            Waiting[n].SetActive(false);
            
        }
        else
        {
            if (TC.Evil.GetHero(0).Modelname == "DemonBoss")
            {
                int temp = 4 - TC.Friend.Count();
                ready[n + 1 + temp].SetActive(true);
                Preparation[n + 1 + temp].SetActive(false);
                Waiting[n + 1 + temp].SetActive(false);
            }
            else
            {
                int temp = 4 - TC.Friend.Count();
                ready[n + temp].SetActive(true);
                Preparation[n + temp].SetActive(false);
                Waiting[n + temp].SetActive(false);
            }   
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
            if (TC.Evil.GetHero(0).Modelname == "DemonBoss")
            {
                int temp = 4 - TC.Friend.Count();
                ready[n2 + 1 + temp].SetActive(false);
                Preparation[n2 + 1 + temp].SetActive(true);
                Waiting[n2 + 1 + temp].SetActive(false);
            }
            else
            {
                int temp = 4 - TC.Friend.Count();
                ready[n2 + temp].SetActive(false);
                Preparation[n2 + temp].SetActive(true);
                Waiting[n2 + temp].SetActive(false);
            }
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
        
        Portret.sprite = Resources.Load<Sprite>("SpriteHero/Portret/" + TC.GetHero(n).Modelname);

        for (int i = 0; i <= 5; i++)
        {
            if (i < TC.GetHero(n).Spells.Count)
            {
                Canvas.transform.Find("Panel").Find("SpellPanel").Find("SpellButton" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/IconSpell/"
                                                                                                                     + TC.GetHero(n).Spells[i].target);
            }
            else
            {
                Canvas.transform.Find("Panel").Find("SpellPanel").Find("SpellButton" + i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Image/IconSpell/Close");
            }
        }

    }

    public void Defeat()
    {
        Canvas.transform.Find("DeathPanel").gameObject.SetActive(true);
        Canvas.transform.Find("DeathPanel").Find("Image").Find("ScoreImage").Find("Text (TMP)").GetComponent<TextMeshProUGUI>().text = "Счёт  " + TC.Score + "\n Вы не победили финального босса, ваш счёт не будет запомнен.";
    }

    public void InitState()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            Waiting[i].SetActive(true);
            ready[i].SetActive(false);
            Preparation[i].SetActive(false);
        }
        if (TC.Evil.GetHero(0).Modelname == "DemonBoss")
        {
            Waiting[5].SetActive(true);
            ready[5].SetActive(false);
            Preparation[5].SetActive(false);
        }
        else
        {
            for (int i = 0; i < TC.Evil.Count(); i++)
            {
                Waiting[i + 4].SetActive(true);
                ready[i + 4].SetActive(false);
                Preparation[i + 4].SetActive(false);
            }
        }
        
    }

    public void ResetState()
    {
        for (int i = 0; i < 7; i++)
        {
            Waiting[i].SetActive(false);
            ready[i].SetActive(false);
            Preparation[i].SetActive(false);
        }
    }

    public void ResetHealtSystem()
    {
        for (int i = 0; i < 4; i++)
        {
            Canvas.transform.Find("SelectPanel").Find("Select" + i).gameObject.SetActive(true);
        }

        for (int i = 0; i < 4; i++)
        {
            Canvas.transform.Find("SelectPanel").Find("SelectE" + i).gameObject.SetActive(true);
        }
    }

    public void RefreshHealtSystem()
    {
        for (int i = 0; i < 4; i++)
        {
            if (TC.Friend.GetHero(i).Nickname == "Void")
            {
                Canvas.transform.Find("SelectPanel").Find("Select" + i).gameObject.SetActive(false);
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

        if (TC.Evil.GetHero(0).Modelname == "DemonBoss")
        {
            for (int i = 0; i < 4; i++)
            {
                Canvas.transform.Find("SelectPanel").Find("SelectE" + i).gameObject.SetActive(false);
            }
            Canvas.transform.Find("SelectPanel").Find("SelectE" + 1).gameObject.SetActive(true);
            Canvas.transform.Find("SelectPanel").Find("SelectE" + 1).Find("HealthSystemE" + 1).GetComponent<HealthSystem>().SetSystem(TC.Evil.GetHero(0).Health.Hp,
                                                                                                                                        TC.Evil.GetHero(0).Health.MaxHP,
                                                                                                                                        TC.Evil.GetHero(0).Health.Mp,
                                                                                                                                        TC.Evil.GetHero(0).Health.MaxMP
                                                                                                                                        );
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                if (TC.Evil.GetHero(i).Nickname == "Void")
                {
                    Canvas.transform.Find("SelectPanel").Find("SelectE" + i).gameObject.SetActive(false);
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
    }

    public void RefreshHealt()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).GetComponent<HealthSystem>().SetSystem(TC.Friend.GetHero(i).Health.Hp,
                                                                                                                                    TC.Friend.GetHero(i).Health.MaxHP,
                                                                                                                                    TC.Friend.GetHero(i).Health.Mp,
                                                                                                                                    TC.Friend.GetHero(i).Health.MaxMP
                                                                                                                                    );
        }
        if (TC.Evil.GetHero(0).Modelname == "DemonBoss")
        {
            Canvas.transform.Find("SelectPanel").Find("SelectE" + 1).Find("HealthSystemE" + 1).GetComponent<HealthSystem>().SetSystem(TC.Evil.GetHero(0).Health.Hp,
                                                                                                                                        TC.Evil.GetHero(0).Health.MaxHP,
                                                                                                                                        TC.Evil.GetHero(0).Health.Mp,
                                                                                                                                        TC.Evil.GetHero(0).Health.MaxMP
                                                                                                                                        );
        }
        else
        {
            for (int i = 0; i < TC.Evil.Count(); i++)
            {
                Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).GetComponent<HealthSystem>().SetSystem(TC.Evil.GetHero(i).Health.Hp,
                                                                                                                                        TC.Evil.GetHero(i).Health.MaxHP,
                                                                                                                                        TC.Evil.GetHero(i).Health.Mp,
                                                                                                                                        TC.Evil.GetHero(i).Health.MaxMP
                                                                                                                                        );
            }
        } 
    }

    public void NoButtom()
    {
        //for (int i = 0; i < TC.Friend.Count(); i++)
        //{
        //    Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).GetComponent<Button>().interactable = false;
        //}

        //for (int i = 0; i < TC.Evil.Count(); i++)
        //{
        //    Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).GetComponent<Button>().interactable = false;
        //}


        Canvas.transform.Find("Panel").Find("Block").gameObject.SetActive(true);

    }

    public void YesButtom()
    {
        //for (int i = 0; i < TC.Friend.Count(); i++)
        //{
        //    Canvas.transform.Find("SelectPanel").Find("Select" + i).Find("HealthSystem" + i).GetComponent<Button>().interactable = true;
        //}

        //for (int i = 0; i < TC.Evil.Count(); i++)
        //{
        //    Canvas.transform.Find("SelectPanel").Find("SelectE" + i).Find("HealthSystemE" + i).GetComponent<Button>().interactable = true;
        //}

        
        Canvas.transform.Find("Panel").Find("Block").gameObject.SetActive(false);
        
    }

    public void InitHealthSystem()
    {

    }

    public void RefreshHealtSystem(int n)
    {

    }

    public void WriteLog(string str)
    {
        if (count < 4)
        {
            Log.text += str + "\n";
            count++;
        }
        else
        {
            ResetLog();
            Log.text += str + "\n";
            count = 1;
        }
       
    }

    public void WriteLineLog(string str)
    {
        Log.text +="\n" + str;
    }

    public void ResetLog()
    {
        Log.text = "";
    }
}
