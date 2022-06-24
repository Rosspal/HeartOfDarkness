using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiCamp : MonoBehaviour
{
    [SerializeField] Canvas Canvas;
    [SerializeField] TeamContainer TC;

    private void Start()
    {
        Clear();
    }

    public void Clear()
    {
        for (int i = 0; i < 4; i++)
        {
            Canvas.transform.Find("Upgrade").Find("Panel" + i).gameObject.SetActive(false);
            Canvas.transform.Find("Name").Find("Text" + i).gameObject.SetActive(false);
            Canvas.transform.Find("Level").Find("Text" + i).gameObject.SetActive(false);
        }
    }

    public void Init()
    {
        for (int i = 0; i < TC.Friend.Count(); i++)
        {
            Canvas.transform.Find("Upgrade").Find("Panel" + i).gameObject.SetActive(true);
            Canvas.transform.Find("Name").Find("Text" + i).gameObject.SetActive(true);
            Canvas.transform.Find("Level").Find("Text" + i).gameObject.SetActive(true);

            Canvas.transform.Find("Name").Find("Text" + i).GetComponent<TextMeshProUGUI>().text = TC.Friend.GetHero(i).Nickname;
            Canvas.transform.Find("Level").Find("Text" + i).GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Level;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text0").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Characteristic.Strength;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text1").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Characteristic.Agility;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text2").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Characteristic.Intelect;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text3").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Characteristic.Wisdom;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text4").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Characteristic.Charisma;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text5").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Characteristic.Physique;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("Value").Find("Text").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).SkillPoint;

            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("WeaponValue").Find("Text0").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Attack;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("WeaponValue").Find("Text1").GetComponent<TextMeshProUGUI>().text = "" + TC.Friend.GetHero(i).Armor;
        }



    }


}
