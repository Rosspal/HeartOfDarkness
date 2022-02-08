using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHero : MonoBehaviour
{
    private Hero hero;

    public Hero Generate()
    {
        string specialization;
        string race;
        int randRace = Random.Range(1, 9);
        switch (randRace)
        {
            case 1:
                race = "Скелет";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                //Темное зрение,Восстановление конечностей,Скелетная природа,Ложный внешний вид,Безмозглый.
                break;
            case 2:
                race = "Тифлинг";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                //скорость 30 футов
                //Тёмное зрение. 
                //Адское сопротивление. Вы получаете сопротивление урону огнём.
                break;
            case 3:
                race = "Человек";
                hero.Characteristic.AddAll(1);
                //скорость 30 футов
                break;
            case 4:
                race = "Гоблин";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                //скорость 30 футов но думаю 25
                //Тёмное зрение,Шустрый побег.
                break;
            case 5:
                race = "Дженази";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "Калаштар";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                //Двойственность разума,Ментальная дисциплина
                break;
            case 7:
                race = "Эльф";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                //Наследие фей. Вы совершаете с преимуществом спасброски от очарования, и вас невозможно магически усыпить.
                //скорость 35 футов
                //Обострённые чувства. Вы владеете навыком Внимательность.
                //Тёмное зрение.
                break;
            case 8:
                race = "Полуэльф";
                hero.Characteristic.AddCharisma(2);
                int randTemp = Random.Range(1, 7);
                while (randTemp == 5)
                {
                    randTemp = Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp,1);
                //Наследие фей. Вы совершаете с преимуществом спасброски от очарования, и вас невозможно магически усыпить.
                //Универсальность навыков. Вы получаете владение двумя навыками на ваш выбор.
                break;
        }

        int randSpec;
        switch (randRace)
        {
            case 1 or 2:
                randSpec = Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        break;
                    case 2:
                        specialization = "Воин";
                        break;
                }
                break;
            case 3:
                randSpec = Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        break;
                    case 2:
                        specialization = "Воин";
                        break;
                }
                break;
            case 4:
                randSpec = Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        break;
                    case 2:
                        specialization = "Воин";
                        break;
                }
                break;
            case 5:
                randSpec = Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";

                        //от расы
                        hero.Characteristic.AddIntelect(1);
                        break;
                    case 2:
                        specialization = "Жрец";
                        //от расы
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case 3:
                        specialization = "Монах";
                        //от расы
                        hero.Characteristic.AddStrength(1);
                        break;
                    case 4:
                        specialization = "Плут";
                        //от расы
                        hero.Characteristic.AddAgility(1);
                        break;
                }
                break;
            case 6:
                randSpec = Random.Range(1, 2);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        break;
                    case 2:
                        specialization = "Воин";
                        break;
                }
                break;
            case 7:
                randSpec = Random.Range(1, 2);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        break;
                    case 2:
                        specialization = "Воин";
                        break;
                }
                break;
            case 8:
                randSpec = Random.Range(1, 2);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        break;
                    case 2:
                        specialization = "Воин";
                        break;
                }
                break;
        }

        return hero;
    }
}
