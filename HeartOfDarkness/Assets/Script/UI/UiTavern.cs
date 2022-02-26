using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTavern : MonoBehaviour
{
    [SerializeField] GameObject InfoTab;
    private Hero hero;

    private void Start()
    {
        InfoTab.SetActive(false);
    }

    public void OpenInfoTab(int number)
    {
        InfoTab.SetActive(true);
        Hero hero = this.GetComponent<GameControler>().GetTavernHero(number);
        InfoTab.transform.Find("InfoTab").Find("NameText").GetComponent<TextMeshProUGUI>().text = hero.Nickname;
        InfoTab.transform.Find("InfoTab").Find("InfoText").GetComponent<TextMeshProUGUI>().text = "Раса " + hero.Race +"\n" + "Специализация " + hero.Specialization + "\n" +
                                                                                                   "HP " + hero.Health.Hp + "/" + hero.Health.MaxHP + "\n"
                                                                                                   + "Кость хитов " + hero.Health.CountBone() + "/" + hero.Health.BoneValue() + "\n"
                                                                                                   + "Сила " + hero.Characteristic.Strength + "\n"
                                                                                                   + "Ловкость " + hero.Characteristic.Agility + "\n"
                                                                                                   + "Интелект " + hero.Characteristic.Intelect + "\n"
                                                                                                   + "Мудрость " + hero.Characteristic.Wisdom + "\n"
                                                                                                   + "Харизма " + hero.Characteristic.Charisma + "\n"
                                                                                                   + "Телосложение " + hero.Characteristic.Physique + "\n";

        InfoTab.transform.Find("InfoTab").Find("InfoText2").GetComponent<TextMeshProUGUI>().text = "Навыки: " + hero.Abilities.Info() + "." + "\n\n" + "Способности: " + hero.Skills.Info() + ".";
    }

    public void CloseInfoTab()
    {
        InfoTab.SetActive(false);
    }
}
