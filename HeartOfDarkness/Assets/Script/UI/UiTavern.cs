using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTavern : MonoBehaviour
{
    [SerializeField] GameObject InfoTab;
    private Hero hero;
    private int check;
    private double time = 0;

    private void Start()
    {
        InfoTab.SetActive(false);
    }

    public void OpenInfoTab(int number)
    {
        check = number;
        double tempTime = Time.realtimeSinceStartupAsDouble;
        if ((tempTime - time) < 0.18)
        {
            InfoTab.SetActive(true);
            Hero hero = this.GetComponent<GameControler>().GetTavernHero(number);
            InfoTab.transform.Find("InfoTab").Find("NameText").GetComponent<TextMeshProUGUI>().text = hero.Nickname;
            InfoTab.transform.Find("InfoTab").Find("InfoText").GetComponent<TextMeshProUGUI>().text = "���� " + hero.Race + "\n" + "������������� " + hero.Specialization + "\n" +
                                                                                                       "HP " + hero.Health.Hp + "/" + hero.Health.MaxHP + "\n"
                                                                                                       + "����� ����� " + hero.Health.CountBone() + "/" + hero.Health.BoneValue() + "\n"
                                                                                                       + "���� " + hero.Characteristic.Strength + "\n"
                                                                                                       + "�������� " + hero.Characteristic.Agility + "\n"
                                                                                                       + "�������� " + hero.Characteristic.Intelect + "\n"
                                                                                                       + "�������� " + hero.Characteristic.Wisdom + "\n"
                                                                                                       + "������� " + hero.Characteristic.Charisma + "\n"
                                                                                                       + "������������ " + hero.Characteristic.Physique + "\n";

            InfoTab.transform.Find("InfoTab").Find("InfoText2").GetComponent<TextMeshProUGUI>().text = "������: " + hero.Abilities.Info() + "." + "\n\n" + "�����������: " + hero.Skills.Info() + ".";
        }
        else
        {
            time = Time.realtimeSinceStartupAsDouble;
        }



    }

    public void BuyHero()
    {
        GetComponent<SoundBox>().PlaySound("ItemBuy");
        if (GetComponent<GameControler>().BuyHero(check))
        {
            GetComponent<CharacterDisplay>().ClearDisplay(check);
        }
        else
        {
            Warning("�� ���������� �����");
        }
    }

    public void RefreshTaverna()
    {
        GetComponent<SoundBox>().PlaySound("ItemBuy");
        //GetComponent<GameControler>().FreeRefreshTaverna();
        if (!GetComponent<GameControler>().RefreshTaverna())
        {
            Warning("�� ���������� �����");
        }

    }

    public void Warning(string text)
    {

    }

    public void CloseInfoTab()
    {
        GetComponent<UiEventManager>().Click();
        InfoTab.SetActive(false);
    }
}
