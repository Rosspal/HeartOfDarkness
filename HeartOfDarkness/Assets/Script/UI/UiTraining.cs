using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiTraining : MonoBehaviour
{
    [SerializeField] TeamContainer TC;
    [SerializeField] Canvas Canvas;
    [SerializeField] int cost = 35;

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

    public void SkillUp(string str)
    {
        int number = int.Parse(str[0].ToString());
        int skill = int.Parse(str[1].ToString());
        TC.Friend.GetHero(number).SkillPoint -= 1;

        switch (skill)
        {
            case 1:
                TC.Friend.GetHero(number).Characteristic.Strength += 1;
                break;
            case 2:
                TC.Friend.GetHero(number).Characteristic.Agility += 1;
                break;
            case 3:
                TC.Friend.GetHero(number).Characteristic.Intelect += 1;
                break;
            case 4:
                TC.Friend.GetHero(number).Characteristic.Wisdom += 1;
                break;
            case 5:
                TC.Friend.GetHero(number).Characteristic.Charisma += 1;
                break;
            case 6:
                TC.Friend.GetHero(number).Characteristic.Physique += 1;
                break;
        }
        TC.Friend.GetHero(number).RefreshStats();
        Init();
    }

    public void ArmorUp(int number)
    {
        TC.AddMoney(-cost);
        TC.Friend.GetHero(number).Armor += 1;
        Init();
    }

    public void WeaponUp(int number)
    {
        TC.AddMoney(-cost);
        TC.Friend.GetHero(number).Attack += 1;
        Init();
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

            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtWeapon").Find("Text0").GetComponent<TextMeshProUGUI>().text = "" + cost;
            Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtWeapon").Find("Text1").GetComponent<TextMeshProUGUI>().text = "" + cost;


            if (TC.Friend.GetHero(i).SkillPoint != 0)
            {
                Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtUp").gameObject.SetActive(true);
            }
            else
            {
                Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtUp").gameObject.SetActive(false);
            }


            if (TC.Money >= cost)
            {
                Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtWeapon").Find("Button0").gameObject.SetActive(true);
                Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtWeapon").Find("Button1").gameObject.SetActive(true);
            }
            else
            {
                Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtWeapon").Find("Button0").gameObject.SetActive(false);
                Canvas.transform.Find("Upgrade").Find("Panel" + i).Find("ButtWeapon").Find("Button1").gameObject.SetActive(false);
            }
        }


        
    }
}
