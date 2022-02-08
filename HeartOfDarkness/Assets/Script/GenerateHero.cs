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
                int randTemp = Random.Range(1, 7);
                hero.Abilities.AddAbility("�������� ���", "��������������� �������");
                while (randTemp == 5)
                {
                    randTemp = Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp,1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 ��� ������
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
                randSpec = Random.Range(1, 9);
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
                        specialization = "����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 7:
                        specialization = "�����";
                        break;
                    case 8:
                        specialization = "��������";
                        break;
                }
                break;
            case 4:
                randSpec = Random.Range(1, 4);
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
                        break;
                }
                break;
            case 5:
                randSpec = Random.Range(1, 5);
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
                randSpec = Random.Range(1, 3);
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
                        break;
                }
                break;
            case 7 or 8:
                randSpec = Random.Range(1, 6);
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
                        break;
                    case 3:
                        specialization = "�����";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
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
                        break;
                }
                break;
        }

        return hero;
    }
}
