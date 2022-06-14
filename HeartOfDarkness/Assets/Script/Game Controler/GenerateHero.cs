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
        
    }

    public Hero Generate()
    {
        
        hero = new Hero();
        genEq = GetComponent<GenerateEquipment>();


        string specialization = "";
        string race = "";
        int randRace = UnityEngine.Random.Range(1, 9);
        switch (randRace)
        {
            case 1:
                race = "������";
                hero.Modelname = "Skelet";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                hero.Abilities.AddAbility("������ ������", "�������������� �����������", "��������� �������", "����������","������");
                break;
            case 2:
                race = "�������";
                hero.Modelname = "Tiefling";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������ �������������");
                break;
            case 3:
                race = "�������";
                hero.Modelname = "Human";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("������ �����");//����� ���������
                hero.Skills.AddRandOwn();
                break;
            case 4:
                race = "������";
                hero.Modelname = "Goblin";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������� �����");
                break;
            case 5:
                race = "�������";
                hero.Modelname = "Genasi";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "��������";
                hero.Modelname = "Kalashtar";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("�������������� ������", "���������� ����������");
                break;
            case 7:
                race = "����";
                hero.Modelname = "Elf";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("�������� ���", "���������� �������", "Ҹ���� ������");
                break;
            case 8:
                race = "��������";
                hero.Modelname = "Half-Elf";
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
        baseAttack b = new baseAttack();
        hero.AddSpell(b);
        switch (randRace)
        {
            case 1:
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "�����";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
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
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Modelname += "Fighter";
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
                        hero.Modelname += "Viking";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 3:
                        specialization = "���������";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case 4:
                        specialization = "�����";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 5:
                        specialization = "�������";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 6:
                        specialization = "�����";
                        hero.Modelname += "Ronin";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                    case 7:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 3:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
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
                        hero.Modelname += "Cleric";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        //�� ����
                        hero.Abilities.AddAbility("������������� �������");
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case 3:
                        specialization = "�����";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        //�� ����
                        hero.Abilities.AddAbility("��������� � ����������");
                        hero.Characteristic.AddStrength(1);
                        break;
                    case 4:
                        specialization = "����";
                        hero.Modelname += "Rogue";
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
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 2:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "���������";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 3:
                        specialization = "�������";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 4:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "���������";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case 3:
                        specialization = "�������";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case 4:
                        specialization = "����";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 5:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
        }
        hero.Specialization = specialization;

        switch (hero.Specialization)
        {
            case "������":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(12);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(15);

                Rage rage = new Rage();
                hero.AddSpell(rage);
                break;
            case "�����":
                hero.Characteristic.AddStrength(10);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(11);

                Heal heal = new Heal();
                hero.AddSpell(heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);

                Heal Heal = new Heal();
                hero.AddSpell(Heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                CleavingStrike Strike = new CleavingStrike();
                hero.AddSpell(Strike);
                break;
            case "����":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(10);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);

                Backstab stab = new Backstab();
                hero.AddSpell(stab);
                break;
            case "������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(8);
                hero.Characteristic.AddPhysique(14);
                AStrongBeat Beat = new AStrongBeat();
                hero.AddSpell(Beat);
                break;
            case "���������":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);
                SplashAttack splash = new SplashAttack();
                hero.AddSpell(splash);
                break;
            case "��������":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);
                AccurateShot shot = new AccurateShot();
                hero.AddSpell(shot);
                break;
            case "�����":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(11);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(12);
                AccurateHit hit = new AccurateHit();
                hero.AddSpell(hit);
                break;
            case "�������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                ShieldBash shield = new ShieldBash();
                hero.AddSpell(shield);
                break;
        }

        hero.Initiative = hero.Characteristic.Modifier("Agility");

        short modif = hero.Characteristic.Modifier("Physique");
        hero.RefreshStats();

        hero.RefreshSkills();

        hero.Nickname = NameGenerate(race);

        hero.Equipment = genEq.GenerateBase();
        
        return hero;
    }

    public Hero Generate(int level)
    {

        hero = new Hero();
        genEq = GetComponent<GenerateEquipment>();


        string specialization = "";
        string race = "";
        int randRace = UnityEngine.Random.Range(1, 9);
        switch (randRace)
        {
            case 1:
                race = "������";
                hero.Modelname = "Skelet";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                hero.Abilities.AddAbility("������ ������", "�������������� �����������", "��������� �������", "����������", "������");
                break;
            case 2:
                race = "�������";
                hero.Modelname = "Tiefling";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������ �������������");
                break;
            case 3:
                race = "�������";
                hero.Modelname = "Human";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("������ �����");//����� ���������
                hero.Skills.AddRandOwn();
                break;
            case 4:
                race = "������";
                hero.Modelname = "Goblin";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������� �����");
                break;
            case 5:
                race = "�������";
                hero.Modelname = "Genasi";
                hero.Characteristic.AddPhysique(2);
                break;
            case 6:
                race = "��������";
                hero.Modelname = "Kalashtar";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("�������������� ������", "���������� ����������");
                break;
            case 7:
                race = "����";
                hero.Modelname = "Elf";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("�������� ���", "���������� �������", "Ҹ���� ������");
                break;
            case 8:
                race = "��������";
                hero.Modelname = "Half-Elf";
                hero.Characteristic.AddCharisma(2);
                int randTemp = UnityEngine.Random.Range(1, 7);
                hero.Abilities.AddAbility("�������� ���", "��������������� �������");
                while (randTemp == 5)
                {
                    randTemp = UnityEngine.Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp, 1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 ��� ������
                break;
        }
        hero.Race = race;
        int randSpec;
        baseAttack b = new baseAttack();
        hero.AddSpell(b);
        switch (randRace)
        {
            case 1:
                randSpec = UnityEngine.Random.Range(1, 3);
                switch (randSpec)
                {
                    case 1:
                        specialization = "������";
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "�����";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
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
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Modelname += "Fighter";
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
                        hero.Modelname += "Viking";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 3:
                        specialization = "���������";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case 4:
                        specialization = "�����";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 5:
                        specialization = "�������";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 6:
                        specialization = "�����";
                        hero.Modelname += "Ronin";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                    case 7:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "����";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 3:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
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
                        hero.Modelname += "Cleric";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        //�� ����
                        hero.Abilities.AddAbility("������������� �������");
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case 3:
                        specialization = "�����";
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        //�� ����
                        hero.Abilities.AddAbility("��������� � ����������");
                        hero.Characteristic.AddStrength(1);
                        break;
                    case 4:
                        specialization = "����";
                        hero.Modelname += "Rogue";
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
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 2:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "���������";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 3:
                        specialization = "�������";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case 4:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
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
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case 2:
                        specialization = "���������";
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case 3:
                        specialization = "�������";
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case 4:
                        specialization = "����";
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case 5:
                        specialization = "��������";
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
        }
        hero.Specialization = specialization;

        switch (hero.Specialization)
        {
            case "������":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(12);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(15);

                Rage rage = new Rage();
                hero.AddSpell(rage);
                break;
            case "�����":
                hero.Characteristic.AddStrength(10);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(11);

                Heal heal = new Heal();
                hero.AddSpell(heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);

                Heal Heal = new Heal();
                hero.AddSpell(Heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                CleavingStrike Strike = new CleavingStrike();
                hero.AddSpell(Strike);
                break;
            case "����":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(10);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);

                Backstab stab = new Backstab();
                hero.AddSpell(stab);
                break;
            case "������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(8);
                hero.Characteristic.AddPhysique(14);
                AStrongBeat Beat = new AStrongBeat();
                hero.AddSpell(Beat);
                break;
            case "���������":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);
                SplashAttack splash = new SplashAttack();
                hero.AddSpell(splash);
                break;
            case "��������":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);
                AccurateShot shot = new AccurateShot();
                hero.AddSpell(shot);
                break;
            case "�����":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(11);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(12);
                AccurateHit hit = new AccurateHit();
                hero.AddSpell(hit);
                break;
            case "�������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                ShieldBash shield = new ShieldBash();
                hero.AddSpell(shield);
                break;
        }

        hero.Initiative = hero.Characteristic.Modifier("Agility");

        hero.SkillPoint = 2 * (level - 1);

        for (int i = level; i > 1; i--)
        {
            hero.LevelUp();
        }

        while (hero.SkillPoint < 0)
        {
            short rand = (short)UnityEngine.Random.Range(1, 7);
            hero.Characteristic.AddByNumber(rand, 1);
        }

        hero.RefreshStats();

        hero.RefreshSkills();

        hero.Nickname = NameGenerate(race);

        hero.Equipment = genEq.GenerateBase();


        int temp = level;
        while (temp > 1)
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                hero.Attack++;
            }
            else
            {
                hero.Armor++;
            }
            temp--;
        }


        return hero;
    }

    public Hero Generate(string race, string specialization)
    {

        hero = new Hero();
        genEq = GetComponent<GenerateEquipment>();


        switch (race)
        {
            case "������":
                hero.Modelname = "Skelet";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                hero.Abilities.AddAbility("������ ������", "�������������� �����������", "��������� �������", "����������", "������");
                break;
            case "�������":
                hero.Modelname = "Tiefling";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������ �������������");
                break;
            case "�������":
                hero.Modelname = "Human";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("������ �����");//����� ���������
                hero.Skills.AddRandOwn();
                break;
            case "������":
                hero.Modelname = "Goblin";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������� �����");
                break;
            case "�������":
                hero.Modelname = "Genasi";
                hero.Characteristic.AddPhysique(2);
                break;
            case "��������":
                hero.Modelname = "Kalashtar";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("�������������� ������", "���������� ����������");
                break;
            case "����":
                hero.Modelname = "Elf";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("�������� ���", "���������� �������", "Ҹ���� ������");
                break;
            case "��������":
                hero.Modelname = "Half-Elf";
                hero.Characteristic.AddCharisma(2);
                int randTemp = UnityEngine.Random.Range(1, 7);
                hero.Abilities.AddAbility("�������� ���", "��������������� �������");
                while (randTemp == 5)
                {
                    randTemp = UnityEngine.Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp, 1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 ��� ������
                break;
        }
        hero.Race = race;

        baseAttack b = new baseAttack();
        hero.AddSpell(b);
        switch (race)
        {
            case "������":
                switch (specialization)
                {
                    case "������":
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case "�����":
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                }
                break;
            case "�������":
                switch (specialization)
                {
                    case "������":
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                }
                break;
            case "�������":
                switch (specialization)
                {
                    case "������":
                        hero.Modelname += "Viking";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        break;
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "���������":
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case "�����":
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "�������":
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "�����":
                        hero.Modelname += "Ronin";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "������":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "����":
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "�������":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        //�� ����
                        hero.Abilities.AddAbility("Ҹ���� ������", "������������� ����");
                        hero.Characteristic.AddIntelect(1);
                        break;
                    case "����":
                        hero.Modelname += "Cleric";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        //�� ����
                        hero.Abilities.AddAbility("������������� �������");
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case "�����":
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        //�� ����
                        hero.Abilities.AddAbility("��������� � ����������");
                        hero.Characteristic.AddStrength(1);
                        break;
                    case "����":
                        hero.Modelname += "Rogue";
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
            case "��������":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "����":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "���������":
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "�������":
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "Half-Elf":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "���������":
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case "�������":
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case "����":
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
        }
        hero.Specialization = specialization;

        switch (hero.Specialization)
        {
            case "������":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(12);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(15);

                Rage rage = new Rage();
                hero.AddSpell(rage);
                break;
            case "�����":
                hero.Characteristic.AddStrength(10);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(11);

                Heal heal = new Heal();
                hero.AddSpell(heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);

                Heal Heal = new Heal();
                hero.AddSpell(Heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                CleavingStrike Strike = new CleavingStrike();
                hero.AddSpell(Strike);
                break;
            case "����":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(10);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);

                Backstab stab = new Backstab();
                hero.AddSpell(stab);
                break;
            case "������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(8);
                hero.Characteristic.AddPhysique(14);
                AStrongBeat Beat = new AStrongBeat();
                hero.AddSpell(Beat);
                break;
            case "���������":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);
                SplashAttack splash = new SplashAttack();
                hero.AddSpell(splash);
                break;
            case "��������":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);
                AccurateShot shot = new AccurateShot();
                hero.AddSpell(shot);
                break;
            case "�����":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(11);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(12);
                AccurateHit hit = new AccurateHit();
                hero.AddSpell(hit);
                break;
            case "�������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                ShieldBash shield = new ShieldBash();
                hero.AddSpell(shield);
                break;
        }

        

        hero.Initiative = hero.Characteristic.Modifier("Agility");

        short modif = hero.Characteristic.Modifier("Physique");
        hero.RefreshStats();

        hero.RefreshSkills();

        hero.Nickname = NameGenerate(race);

        hero.Equipment = genEq.GenerateBase();

        

        return hero;
    }

    public Hero Generate(string race, string specialization, int level)
    {

        hero = new Hero();
        genEq = GetComponent<GenerateEquipment>();


        switch (race)
        {
            case "������":
                hero.Modelname = "Skelet";
                hero.Characteristic.AddAgility(1);
                hero.Characteristic.AddPhysique(1);
                hero.Characteristic.AddStrength(1);
                hero.Abilities.AddAbility("������ ������", "�������������� �����������", "��������� �������", "����������", "������");
                break;
            case "�������":
                hero.Modelname = "Tiefling";
                hero.Characteristic.AddCharisma(2);
                hero.Characteristic.AddIntelect(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������ �������������");
                break;
            case "�������":
                hero.Modelname = "Human";
                hero.Characteristic.AddAll(1);
                hero.Abilities.AddAbility("������ �����");//����� ���������
                hero.Skills.AddRandOwn();
                break;
            case "������":
                hero.Modelname = "Goblin";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddPhysique(1);
                hero.Abilities.AddAbility("Ҹ���� ������", "������� �����");
                break;
            case "�������":
                hero.Modelname = "Genasi";
                hero.Characteristic.AddPhysique(2);
                break;
            case "��������":
                hero.Modelname = "Kalashtar";
                hero.Characteristic.AddCharisma(1);
                hero.Characteristic.AddWisdom(2);
                hero.Abilities.AddAbility("�������������� ������", "���������� ����������");
                break;
            case "����":
                hero.Modelname = "Elf";
                hero.Characteristic.AddAgility(2);
                hero.Characteristic.AddWisdom(1);
                hero.Abilities.AddAbility("�������� ���", "���������� �������", "Ҹ���� ������");
                break;
            case "��������":
                hero.Modelname = "Half-Elf";
                hero.Characteristic.AddCharisma(2);
                int randTemp = UnityEngine.Random.Range(1, 7);
                hero.Abilities.AddAbility("�������� ���", "��������������� �������");
                while (randTemp == 5)
                {
                    randTemp = UnityEngine.Random.Range(1, 7);
                }
                hero.Characteristic.AddByNumber((short)randTemp, 1);
                hero.Skills.AddRandOwn(); hero.Skills.AddRandOwn(); // 2 ��� ������
                break;
        }
        hero.Race = race;

        baseAttack b = new baseAttack();
        hero.AddSpell(b);
        switch (race)
        {
            case "������":
                switch (specialization)
                {
                    case "������":
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case "�����":
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                }
                break;
            case "�������":
                switch (specialization)
                {
                    case "������":
                        hero.Modelname += "Barbarian";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������", "���� �� ���������");
                        break;
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                }
                break;
            case "�������":
                switch (specialization)
                {
                    case "������":
                        hero.Modelname += "Viking";
                        hero.Health.SetBone(1, 12);
                        hero.Health.HpForLevel = 7;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�����������", "�������");
                        break;
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "���������":
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case "�����":
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "�������":
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "�����":
                        hero.Modelname += "Ronin";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "������":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "����":
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "�������":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        //�� ����
                        hero.Abilities.AddAbility("Ҹ���� ������", "������������� ����");
                        hero.Characteristic.AddIntelect(1);
                        break;
                    case "����":
                        hero.Modelname += "Cleric";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("�������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        //�� ����
                        hero.Abilities.AddAbility("������������� �������");
                        hero.Characteristic.AddWisdom(1);
                        break;
                    case "�����":
                        hero.Modelname += "Monk";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Skills.AddRandOwn("����������", "��������", "�������", "����������������", "�������", "����������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        //�� ����
                        hero.Abilities.AddAbility("��������� � ����������");
                        hero.Characteristic.AddStrength(1);
                        break;
                    case "����":
                        hero.Modelname += "Rogue";
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
            case "��������":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "����":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "���������":
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "�������":
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Health.MaxMP = 10;
                        hero.Health.Mp = 10;
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
            case "Half-Elf":
                switch (specialization)
                {
                    case "����":
                        hero.Modelname += "Fighter";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "���������", "�����������", "�������", "����������������", "���� �� ���������");
                        break;
                    case "���������":
                        hero.Modelname += "Wizard";
                        hero.Health.SetBone(1, 6);
                        hero.Health.HpForLevel = 4;
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Skills.AddRandOwn("�������", "�����", "��������", "����������������", "�������������", "�������");
                        hero.Health.MaxMP = 12;
                        hero.Health.Mp = 12;
                        break;
                    case "�������":
                        hero.Modelname += "Paladin";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        hero.Skills.AddRandOwn("��������", "�����������", "��������", "����������������", "�������", "���������");
                        break;
                    case "����":
                        hero.Modelname += "Rogue";
                        hero.Health.SetBone(1, 8);
                        hero.Health.HpForLevel = 5;
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        hero.Skills.AddRandOwn("����������", "��������", "��������������", "�����������", "�����������", "�������� ���", "�����", "����������������", "�������������", "����������", "���������");
                        break;
                    case "��������":
                        hero.Modelname += "Ranger";
                        hero.Health.SetBone(1, 10);
                        hero.Health.HpForLevel = 6;
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        hero.Skills.AddRandOwn("��������", "��������������", "���������", "�������", "����������������", "�������������", "����������", "���� �� ���������");
                        break;
                }
                break;
        }
        hero.Specialization = specialization;

        switch (hero.Specialization)
        {
            case "������":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(12);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(15);

                Rage rage = new Rage();
                hero.AddSpell(rage);
                break;
            case "�����":
                hero.Characteristic.AddStrength(10);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(11);

                Heal heal = new Heal();
                hero.AddSpell(heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);

                Heal Heal = new Heal();
                hero.AddSpell(Heal);
                break;
            case "����":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                CleavingStrike Strike = new CleavingStrike();
                hero.AddSpell(Strike);
                break;
            case "����":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(10);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);

                Backstab stab = new Backstab();
                hero.AddSpell(stab);
                break;
            case "������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(13);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(8);
                hero.Characteristic.AddPhysique(14);
                AStrongBeat Beat = new AStrongBeat();
                hero.AddSpell(Beat);
                break;
            case "���������":
                hero.Characteristic.AddStrength(8);
                hero.Characteristic.AddAgility(8);
                hero.Characteristic.AddIntelect(15);
                hero.Characteristic.AddWisdom(14);
                hero.Characteristic.AddCharisma(13);
                hero.Characteristic.AddPhysique(10);
                SplashAttack splash = new SplashAttack();
                hero.AddSpell(splash);
                break;
            case "��������":
                hero.Characteristic.AddStrength(13);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(10);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(14);
                hero.Characteristic.AddPhysique(12);
                AccurateShot shot = new AccurateShot();
                hero.AddSpell(shot);
                break;
            case "�����":
                hero.Characteristic.AddStrength(14);
                hero.Characteristic.AddAgility(15);
                hero.Characteristic.AddIntelect(11);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(10);
                hero.Characteristic.AddPhysique(12);
                AccurateHit hit = new AccurateHit();
                hero.AddSpell(hit);
                break;
            case "�������":
                hero.Characteristic.AddStrength(15);
                hero.Characteristic.AddAgility(14);
                hero.Characteristic.AddIntelect(8);
                hero.Characteristic.AddWisdom(8);
                hero.Characteristic.AddCharisma(12);
                hero.Characteristic.AddPhysique(13);
                ShieldBash shield = new ShieldBash();
                hero.AddSpell(shield);
                break;
        }



        hero.Initiative = hero.Characteristic.Modifier("Agility");

        hero.SkillPoint = 2 * (level - 1);
        hero.Level = (short)level;
        while (hero.SkillPoint < 0)
        {
            short rand = (short)UnityEngine.Random.Range(1, 7);
            hero.Characteristic.AddByNumber(rand, 1);
        }

        hero.RefreshStats();

        hero.RefreshSkills();

        hero.Nickname = NameGenerate(race);

        hero.Equipment = genEq.GenerateBase();  

        int temp = level;
        while (temp > 1)
        {
            if (UnityEngine.Random.Range(0, 2) == 1)
            {
                hero.Attack++;
            }
            else
            {
                hero.Armor++;
            }
            temp--;
        }

        return hero;
    }

    public Hero GenerateBoss()
    {
        hero = new Hero();
        genEq = GetComponent<GenerateEquipment>();

        hero.Race = "Demon";
        hero.Specialization = "Boss";
        hero.Modelname = "DemonBoss";

        baseAttack b = new baseAttack();
        hero.AddSpell(b);

        hero.Health.SetBone(1, 220);
        hero.Health.HpForLevel = 25;

        hero.Characteristic.AddStrength(25);
        hero.Characteristic.AddAgility(25);
        hero.Characteristic.AddIntelect(25);
        hero.Characteristic.AddWisdom(25);
        hero.Characteristic.AddCharisma(25);
        hero.Characteristic.AddPhysique(25);
        hero.Initiative = hero.Characteristic.Modifier("Agility");

        hero.RefreshStats();
        hero.RefreshSkills();

        hero.Nickname = "���������";

        hero.Equipment = genEq.GenerateBase();

        hero.Attack = 12;
        hero.Armor = 5;

        return hero;
    }

    public string NameGenerate(string race)
    {
        string fileName ="Assets/Resources/Name/" + race + ".txt";
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
               
                    string str = sw.ReadLine();
                    String[] dataFromFile = str.Split(new String[] { "," },StringSplitOptions.RemoveEmptyEntries);
                    int rand = UnityEngine.Random.Range(0,dataFromFile.Length);
                    result = dataFromFile[rand];
                
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
