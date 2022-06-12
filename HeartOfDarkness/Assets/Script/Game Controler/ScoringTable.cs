using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Run 
{
    public string name;
    public int scoring;
}

public struct Table
{
    public Run[] list;

    public void SetValue(int i, string str, int scor)
    {
        list[i].scoring = scor;
        list[i].name = str;
        Sort();
    }

    public Run GetRun(int i)
    {
        return list[i];
    }

    public void Sort()
    {
        for (int i = 0; i < list.Length; i++)
            for (int j = 0; j < list.Length - 1; j++)
                if (list[j].scoring < list[j + 1].scoring)
                {
                    Run t = list[j + 1];
                    list[j + 1] = list[j];
                    list[j] = t;
                }
    }
}

public class ScoringTable : MonoBehaviour
{
    private Table table;
    internal Table Table { get => table; set => table = value; }

    private void Start()
    {
        Run[] temp = new Run[5];

        temp[0].name = "Артур";
        temp[0].scoring = 2450;

        temp[1].name = "Варвар";
        temp[1].scoring = 450;

        temp[2].name = "Конан";
        temp[2].scoring = 820;

        temp[3].name = "Моргана";
        temp[3].scoring = 1320;

        temp[4].name = "Мерлин";
        temp[4].scoring = 1980;

        table.list = temp;

        table.Sort();
    }

    public string RunToString(int i)
    {
        int n = i + 1;
        string res = " " + n + ") " + table.list[i].name + " " + table.list[i].scoring;
        return res;
    }

    public void AddValue(string name, int scor)
    {
        for (int i = 0; i < 5; i++)
        {
            if (scor >= table.list[i].scoring)
            {
                table.SetValue(table.list.Length - 1, name, scor);
            }
        }
    }

}
