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
                hero.Abilities.AddAbility("Темное зрение", "Восстановление конечностей", "Скелетная природа", "Безмозглый","Нежить");
                break;
            case 2:
                race = "Тифлинг";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Тёмное зрение", "Адское сопротивление");
                break;
            case 3:
                race = "Человек";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("Память отцов");//навык случайный
                hero.Skills.AddRandOwn();
                break;
            case 4:
                race = "Гоблин";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Тёмное зрение", "Шустрый побег");
                break;
            case 5:
                race = "Дженази";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "Калаштар";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("Двойственность разума", "Ментальная дисциплина");
                break;
            case 7:
                race = "Эльф";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("Наследие фей", "Обострённые чувства", "Тёмное зрение");
                break;
            case 8:
                race = "Полуэльф";
                hero.Characteristic.AddCharisma(2);
                int randTemp = Random.Range(1, 7);
                hero.Abilities.AddAbility("Наследие фей", "Универсальность навыков");
                while (randTemp == 5)
                {
                    randTemp = Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp,1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 доп навыка
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
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Природа", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Природа", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Воин";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                }
                break;
            case 3:
                randSpec = Random.Range(1, 9);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Викинг";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Религия");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Религия");
                        break;
                    case 2:
                        specialization = "Воин";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 3:
                        specialization = "Волшебник";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        break;
                    case 4:
                        specialization = "Монах";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        break;
                    case 5:
                        specialization = "Паладин";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        break;
                    case 6:
                        specialization = "Плут";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 7:
                        specialization = "Ронин";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        break;
                    case 8:
                        specialization = "Следопыт";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 4:
                randSpec = Random.Range(1, 4);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Плут";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 3:
                        specialization = "Следопыт";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 5:
                randSpec = Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        //от расы
                        hero.Abilities.AddAbility("Тёмное зрение", "Сопротивление огню");
                        hero.Characteristic.AddIntelect(1);
                        break;
                    case 2:
                        specialization = "Жрец";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("История", "Медицина", "Проницательность", "Религия", "Убеждение");
                        hero.Skills.AddRandOwn("История", "Медицина", "Проницательность", "Религия", "Убеждение");
                        //от расы
                        hero.Abilities.AddAbility("Сопротивление кислоте");
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case 3:
                        specialization = "Монах";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        //от расы
                        hero.Abilities.AddAbility("Иммунитет к окаменению");
                        hero.Characteristic.AddStrength(1);
                        break;
                    case 4:
                        specialization = "Плут";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        //от расы
                        hero.Abilities.AddAbility("Бесконечное дыхание");
                        hero.Characteristic.AddAgility(1);
                        break;
                }
                break;
            case 6:
                randSpec = Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Плут";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 2:
                        specialization = "Следопыт";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 7 or 8:
                randSpec = Random.Range(1, 6);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Волшебник";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        break;
                    case 3:
                        specialization = "Монах";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        break;
                    case 4:
                        specialization = "Плут";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 5:
                        specialization = "Следопыт";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
        }

        return hero;
    }
}
