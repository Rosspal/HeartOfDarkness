using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GenerateHero : MonoBehaviour
{
    private Hero hero;
    private GenerateEquipment genEq;

    private void Start()
    {
        genEq = GetComponent<GenerateEquipment>();
    }

    public Hero Generate()
    {
        
        hero = new Hero();


        string specialization = "";
        string race = "";
        int randRace = UnityEngine.Random.Range(1, 9);
        switch (randRace)
        {
            case 1:
                race = "Скелет";
                hero.Modelname = "Skelet";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                hero.Abilities.AddAbility("Темное зрение", "Восстановление конечностей", "Скелетная природа", "Безмозглый","Нежить");
                break;
            case 2:
                race = "Тифлинг";
                hero.Modelname = "Tiefling";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Тёмное зрение", "Адское сопротивление");
                break;
            case 3:
                race = "Человек";
                hero.Modelname = "Human";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("Память отцов");//навык случайный
                hero.Skills.AddRandOwn();
                break;
            case 4:
                race = "Гоблин";
                hero.Modelname = "Goblin";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Тёмное зрение", "Шустрый побег");
                break;
            case 5:
                race = "Дженази";
                hero.Modelname = "Genasi";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "Калаштар";
                hero.Modelname = "Kalashtar";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("Двойственность разума", "Ментальная дисциплина");
                break;
            case 7:
                race = "Эльф";
                hero.Modelname = "Elf";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("Наследие фей", "Обострённые чувства", "Тёмное зрение");
                break;
            case 8:
                race = "Полуэльф";
                hero.Modelname = "Half-Elf";
                hero.Characteristic.AddCharisma(2);
                int randTemp = UnityEngine.Random.Range(1, 7);
                hero.Abilities.AddAbility("Наследие фей", "Универсальность навыков");
                while (randTemp == 5)
                {
                    randTemp = UnityEngine.Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp,1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 доп навыка
                break;
        }
        hero.Race = race;
        int randSpec;
        switch (randRace)
        {
            case 1:
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Природа", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Природа", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Монах";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        break;
                }
                break;
            case 2:
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Варвар";
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Природа", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Природа", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Воин";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                }
                break;
            case 3:
                randSpec = UnityEngine.Random.Range(1, 8);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Викинг";
                        hero.Modelname += "Viking";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Религия");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Запугивание", "Религия");
                        break;
                    case 2:
                        specialization = "Воин";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 3:
                        specialization = "Волшебник";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        break;
                    case 4:
                        specialization = "Монах";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        break;
                    case 5:
                        specialization = "Паладин";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        break;
                    case 6:
                        specialization = "Ронин";
                        hero.Modelname += "Ronin";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "История", "Проницательность", "Религия", "Скрытность");
                        break;
                    case 7:
                        specialization = "Следопыт";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 4:
                randSpec = UnityEngine.Random.Range(1, 4);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Плут";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 3:
                        specialization = "Следопыт";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 5:
                randSpec = UnityEngine.Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Modelname += "Fighter";
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
                        hero.Modelname += "Cleric";
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
                        hero.Modelname += "Monk";
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
                        hero.Modelname += "Rogue";
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
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Плут";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 2:
                        specialization = "Следопыт";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 7:
                randSpec = UnityEngine.Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Волшебник";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        break;
                    case 3:
                        specialization = "Паладин";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        break;
                    case 4:
                        specialization = "Следопыт";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
            case 8:
                randSpec = UnityEngine.Random.Range(1, 6);
                switch (randSpec)
                {
                    case 1:
                        specialization = "Воин";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выживание", "Запугивание", "История", "Проницательность", "Уход за животными");
                        break;
                    case 2:
                        specialization = "Волшебник";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        hero.Skills.AddRandOwn("История", "Магия", "Медицина", "Проницательность", "Расследование", "Религия");
                        break;
                    case 3:
                        specialization = "Паладин";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        hero.Skills.AddRandOwn("Атлетика", "Запугивание", "Медицина", "Проницательность", "Религия", "Убеждение");
                        break;
                    case 4:
                        specialization = "Плут";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        hero.Skills.AddRandOwn("Акробатика", "Атлетика", "Внимательность", "Выступление", "Запугивание", "Ловкость рук", "Обман", "Проницательность", "Расследование", "Скрытность", "Убеждение");
                        break;
                    case 5:
                        specialization = "Следопыт";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        hero.Skills.AddRandOwn("Атлетика", "Внимательность", "Выживание", "Природа", "Проницательность", "Расследование", "Скрытность", "Уход за животными");
                        break;
                }
                break;
        }
        hero.Specialization = specialization;

        hero.Characteristic.AddStrength(RandBestOf(4,6,3));
        hero.Characteristic.AddAgility(RandBestOf(4, 6, 3));
        hero.Characteristic.AddIntelect(RandBestOf(4, 6, 3));
        hero.Characteristic.AddWisdom(RandBestOf(4, 6, 3));
        hero.Characteristic.AddCharisma(RandBestOf(4, 6, 3));
        hero.Characteristic.AddPhysique(RandBestOf(4, 6, 3));

        hero.Initiative = hero.Characteristic.Modifier("Agility");

        short modif = hero.Characteristic.Modifier("Physique");
        hero.Health.SetHPOneLevel(modif);

        hero.RefreshSkills();

        hero.Nickname = NameGenerate(race);

        hero.Equipment = genEq.GenerateBase();

        baseAttack b = new baseAttack();
        hero.AddSpell(b);
        return hero;
    }

    public string NameGenerate(string race)
    {
        string fileName = race + ".txt";
        bool check = true;
        string result = "";

        if (!System.IO.File.Exists(fileName))
        {
            check = false;
        }

        if (check)
        {
            using (StreamReader sw = new StreamReader(fileName))
            {
                while (!sw.EndOfStream)
                {
                    string str = sw.ReadLine();
                    String[] dataFromFile = str.Split(new String[] { "," },StringSplitOptions.RemoveEmptyEntries);
                    int rand = UnityEngine.Random.Range(0,dataFromFile.Length);
                    result = dataFromFile[rand];
                }
            }
        }


        return result;
    }


    private short RandBestOf(int count, int value,int bestCount)
    {
        int[] dice = new int[count];
        int max = 0;
        int maxId = 0;
        int result = 0;

        for (int i = 0; i != dice.Length; i++)
        {
            dice[i] = UnityEngine.Random.Range(1,value + 1);
        }

        for (int j = 0; j != bestCount; j++)
        {
            for (int i = 0; i != dice.Length; i++)
            {
                if (dice[i] >= max)
                {
                    max = dice[i];
                    maxId = i;
                }
            }
            result += max;
            dice[maxId] = 0;
        }
        

        return (short)result;
    }
}
