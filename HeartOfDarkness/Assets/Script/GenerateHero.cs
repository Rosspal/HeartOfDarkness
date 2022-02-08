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
                //������ ������,�������������� �����������,��������� �������,������ ������� ���,����������.
                break;
            case 2:
                race = "�������";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                //�������� 30 �����
                //Ҹ���� ������. 
                //������ �������������. �� ��������� ������������� ����� ����.
                break;
            case 3:
                race = "�������";
                hero.Characteristic.AddAll(1);
                //�������� 30 �����
                break;
            case 4:
                race = "������";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                //�������� 30 ����� �� ����� 25
                //Ҹ���� ������,������� �����.
                break;
            case 5:
                race = "�������";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "��������";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                //�������������� ������,���������� ����������
                break;
            case 7:
                race = "����";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                //�������� ���. �� ���������� � ������������� ���������� �� ����������, � ��� ���������� ��������� �������.
                //�������� 35 �����
                //���������� �������. �� �������� ������� ��������������.
                //Ҹ���� ������.
                break;
            case 8:
                race = "��������";
                hero.Characteristic.AddCharisma(2);
                int randTemp = Random.Range(1, 7);
                while (randTemp == 5)
                {
                    randTemp = Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp,1);
                //�������� ���. �� ���������� � ������������� ���������� �� ����������, � ��� ���������� ��������� �������.
                //��������������� �������. �� ��������� �������� ����� �������� �� ��� �����.
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
                        break;
                    case 2:
                        specialization = "����";
                        break;
                }
                break;
            case 3:
                randSpec = Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        break;
                    case 2:
                        specialization = "����";
                        break;
                }
                break;
            case 4:
                randSpec = Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        break;
                    case 2:
                        specialization = "����";
                        break;
                }
                break;
            case 5:
                randSpec = Random.Range(1, 5);
                switch (randSpec)
                {
                    case 1:
                        specialization = "����";

                        //�� ����
                        hero.Characteristic.AddIntelect(1);
                        break;
                    case 2:
                        specialization = "����";
                        //�� ����
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case 3:
                        specialization = "�����";
                        //�� ����
                        hero.Characteristic.AddStrength(1);
                        break;
                    case 4:
                        specialization = "����";
                        //�� ����
                        hero.Characteristic.AddAgility(1);
                        break;
                }
                break;
            case 6:
                randSpec = Random.Range(1, 2);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        break;
                    case 2:
                        specialization = "����";
                        break;
                }
                break;
            case 7:
                randSpec = Random.Range(1, 2);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        break;
                    case 2:
                        specialization = "����";
                        break;
                }
                break;
            case 8:
                randSpec = Random.Range(1, 2);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        break;
                    case 2:
                        specialization = "����";
                        break;
                }
                break;
        }

        return hero;
    }
}
