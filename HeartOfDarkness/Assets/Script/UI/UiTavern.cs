using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTavern : MonoBehaviour
{
    [SerializeField] GameObject InfoTab;
    private Hero hero;
    private int check;

    private void Start()
    {
        InfoTab.SetActive(false);
    }

    public void OpenInfoTab(int number)
    {
        check = number;
        InfoTab.SetActive(true);
        Hero hero = this.GetComponent<GameControler>().GetTavernHero(number);
        InfoTab.transform.Find("InfoTab").Find("NameText").GetComponent<TextMeshProUGUI>().text = hero.Nickname;
        InfoTab.transform.Find("InfoTab").Find("InfoText").GetComponent<TextMeshProUGUI>().text = "���� " + hero.Race +"\n" + "������������� " + hero.Specialization + "\n" +
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

    public void BuyHero()
    {
        if (GetComponent<GameControler>().BuyHero(check))
        {
            GetComponent<CharacterDisplay>().ClearDisplay(check);
        }
        else
        {
            Debug.LogWarning("������ �������");
        }
    }

    public void CloseInfoTab()
    {
        InfoTab.SetActive(false);
    }
}
