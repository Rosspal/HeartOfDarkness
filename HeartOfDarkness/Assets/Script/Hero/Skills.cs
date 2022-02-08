using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct skill{
    public string title;
    public short mod;
    public bool own;
}

public class Skills
{
    private skill[] skill = new skill[18];



    public Skills()
    {
        for (int i=0; i != skill.Length;i++)
        {
            skill[i].mod = 0;
            skill[i].own = false;
        }

        skill[0].title = "����������";
        skill[1].title = "������";
        skill[2].title = "��������";
        skill[3].title = "��������������";
        skill[4].title = "���������";
        skill[5].title = "�����������";
        skill[6].title = "�����������";
        skill[7].title = "�������";
        skill[8].title = "�������� ���";
        skill[9].title = "�����";
        skill[10].title = "��������";
        skill[11].title = "�����";
        skill[12].title = "�������";
        skill[13].title = "����������������";
        skill[14].title = "�������";
        skill[15].title = "����������";
        skill[16].title = "���������";
        skill[17].title = "���� �� ���������";
    }


    public short Acrobatics { get => skill[0].mod; set => skill[0].mod = value; }
    public bool AcrobaticsOwn { get => skill[0].own; set => skill[0].own = value; }

    public short Analysis { get => skill[1].mod; set => skill[1].mod = value; }
    public bool AnalysisOwn { get => skill[1].own; set => skill[1].own = value; }

    public short Athletics { get => skill[2].mod; set => skill[2].mod = value; }
    public bool AthleticsOwn { get => skill[2].own; set => skill[2].own = value; }

    public short Perception { get => skill[3].mod; set => skill[3].mod = value; }
    public bool PerceptionOwn { get => skill[3].own; set => skill[3].own = value; }

    public short Survival { get => skill[4].mod; set => skill[4].mod = value; }
    public bool SurvivalOwn { get => skill[4].own; set => skill[4].own = value; }

    public short Performance { get => skill[5].mod; set => skill[5].mod = value; }
    public bool PerformanceOwn { get => skill[5].own; set => skill[5].own = value; }

    public short Intimidation { get => skill[6].mod; set => skill[6].mod = value; }
    public bool IntimidationOwn { get => skill[6].own; set => skill[6].own = value; }

    public short History { get => skill[7].mod; set => skill[7].mod = value; }
    public bool HistoryOwn { get => skill[7].own; set => skill[7].own = value; }

    public short SleightOfHand { get => skill[8].mod; set => skill[8].mod = value; }
    public bool SleightOfHandOwn { get => skill[8].own; set => skill[8].own = value; }

    public short Magic { get => skill[9].mod; set => skill[9].mod = value; }
    public bool MagicOwn { get => skill[9].own; set => skill[9].own = value; }

    public short Medicine { get => skill[10].mod; set => skill[10].mod = value; }
    public bool MedicineOwn { get => skill[10].own; set => skill[10].own = value; }

    public short Deception { get => skill[11].mod; set => skill[11].mod = value; }
    public bool DeceptionOwn { get => skill[11].own; set => skill[11].own = value; }

    public short Nature { get => skill[12].mod; set => skill[12].mod = value; }
    public bool NatureOwn { get => skill[12].own; set => skill[12].own = value; }

    public short Insight { get => skill[13].mod; set => skill[13].mod = value; }
    public bool InsightOwn { get => skill[13].own; set => skill[13].own = value; }

    public short Religion { get => skill[14].mod; set => skill[14].mod = value; }
    public bool ReligionOwn { get => skill[14].own; set => skill[14].own = value; }

    public short Stealth { get => skill[15].mod; set => skill[15].mod = value; }
    public bool StealthOwn { get => skill[15].own; set => skill[15].own = value; }

    public short Belief { get => skill[16].mod; set => skill[16].mod = value; }
    public bool BeliefOwn { get => skill[16].own; set => skill[16].own = value; }

    public short Animal�are { get => skill[17].mod; set => skill[17].mod = value; }
    public bool Animal�areOwn { get => skill[17].own; set => skill[17].own = value; }
   

    public void refreshValue(short str, short agi, short intel, short wis, short charis, short bonus)
    {


        Athletics = str;

        Acrobatics = agi;
        SleightOfHand = agi;
        Stealth = agi;

        Analysis = intel;
        History = intel;
        Magic = intel;
        Nature = intel;
        Religion = intel;

        Perception = wis;
        Survival = wis;
        Medicine = wis;
        Insight = wis;
        Animal�are = wis;

        Performance = charis;
        Intimidation = charis;
        Deception = charis;
        Belief = charis;

        for (int i = 0; i != skill.Length; i++)
        {
            if (skill[i].own)
            {
                skill[i].mod += bonus; // ��������� ����� ����������
            }
        }
    }


    public void AddRandOwn()
    {
        int rand = Random.Range(0, 18);
        bool check = true;
        while (check)
        {
            if (!skill[rand].own)
            {
                skill[rand].own = true;
                check = false;
            }
            rand = Random.Range(0, 18);
        }
    }


    public void AddRandOwn(params string[] title)
    {
        int k = Random.Range(0, title.Length);
        int temp = 0;

        bool check = true;
        while (check)
        {
            for (int i = 0; i != skill.Length; i++)
            {
                if (skill[i].title == title[k])
                {
                    temp = i;
                    break;
                }
            }

            title[k] = "";

            if (!skill[temp].own)
            {
                skill[temp].own = true;
                check = false;
                break;
            }
        }
    }

    public string Info()
    {
        string text = "";
        for (int i = 0; i != skill.Length; i++)
        {
            if (skill[i].own)
            {
                text += skill[i].title + "/"; 
            }
        }
        return text;
    }
}
