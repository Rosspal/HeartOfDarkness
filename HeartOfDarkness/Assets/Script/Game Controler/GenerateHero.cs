using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class GenerateHero
{
    private Hero hero;

    public Hero Generate()
    {
        hero = new Hero();
        string specialization = "";
        string race = "";
        int randRace = UnityEngine.Random.Range(1, 9);
        switch (randRace)
        {
            case 1:
                race = "������";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                hero.Abilities.AddAbility("������ ������", "�������������� �����������", "��������� �������", "����������","������");
                break;
            case 2:
                race = "�������";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������ �������������");
                break;
            case 3:
                race = "�������";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("������ �����");//����� ���������
                hero.Skills.AddRandOwn();
                break;
            case 4:
                race = "������";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������� �����");
                break;
            case 5:
                race = "�������";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "��������";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("�������������� ������", "���������� ����������");
                break;
            case 7:
                race = "����";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("�������� ���", "���������� �������", "Ҹ���� ������");
                break;
            case 8:
                race = "��������";
                hero.Characteristic.AddCharisma(2);
                int randTemp = UnityEngine.Random.Range(1, 7);
                hero.Abilities.AddAbility("�������� ���", "��������������� �������");
                while (randTemp == 5)
                {
                    randTemp = UnityEngine.Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp,1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 ��� ������
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
                        specialization = "������";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "�����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                }
                break;
            case 2:
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                }
                break;
            case 3:
                randSpec = UnityEngine.Random.Range(1, 8);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 3:
                        specialization = "���������";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        break;
                    case 4:
                        specialization = "�����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                    case 5:
                        specialization = "�������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case 6:
                        specialization = "�����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                    case 7:
                        specialization = "��������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case 4:
                randSpec = UnityEngine.Random.Range(1, 4);
                switch (randSpec)
                {
                    case 1:
                        specialization = "����";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 3:
                        specialization = "��������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case 5:
                randSpec = UnityEngine.Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "����";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        //�� ����
                        hero.Abilities.AddAbility("Ҹ���� ������", "������������� ����");
                        hero.Characteristic.AddIntelect(1);
                        break;
                    case 2:
                        specialization = "����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        //�� ����
                        hero.Abilities.AddAbility("������������� �������");
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case 3:
                        specialization = "�����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        //�� ����
                        hero.Abilities.AddAbility("��������� � ����������");
                        hero.Characteristic.AddStrength(1);
                        break;
                    case 4:
                        specialization = "����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        //�� ����
                        hero.Abilities.AddAbility("����������� �������");
                        hero.Characteristic.AddAgility(1);
                        break;
                }
                break;
            case 6:
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 2:
                        specialization = "��������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case 7:
                randSpec = UnityEngine.Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "����";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "���������";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        break;
                    case 3:
                        specialization = "�������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case 4:
                        specialization = "��������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case 8:
                randSpec = UnityEngine.Random.Range(1, 6);
                switch (randSpec)
                {
                    case 1:
                        specialization = "����";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "���������";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        break;
                    case 3:
                        specialization = "�������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case 4:
                        specialization = "����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 5:
                        specialization = "��������";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
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

        short modif = hero.Characteristic.Modifier("Physique");
        hero.Health.SetHPOneLevel(modif);

        hero.RefreshSkills();

        hero.Nickname = NameGenerate(race);


        hero.Race = "Elf";

        int temp = UnityEngine.Random.Range(1, 4);
        switch (temp)
        {
            case 1:
                hero.Specialization = "Fighter";
                break;
            case 2:
                hero.Specialization = "Paladin";
                break;
            case 3:
                hero.Specialization = "Ranger";
                break;
        }



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
