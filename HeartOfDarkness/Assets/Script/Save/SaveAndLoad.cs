using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DataSave
{
    public float music;
    public float sound;
}

public class SaveAndLoad : MonoBehaviour
{
    private int numberResolution;
    public Resolution[] resolutions;
    public int NumberResolution { get => numberResolution; set => numberResolution = value; }

    private void Start()
    {
        Resolution[] resolutions = Screen.resolutions;
        string test = "";
        // Print the resolutions
        foreach (var res in resolutions)
        {
            test += res.width + "x" + res.height + " : " + res.refreshRate;
        }
        Debug.Log(Screen.currentResolution);
    }

    public void SaveTable(Table table)
    {
        for (int i = 0; i < table.list.Length; i++)
        {
            PlayerPrefs.SetString("name" + i, table.list[i].name);
            PlayerPrefs.SetInt("score" + i, table.list[i].scoring);
            PlayerPrefs.Save();
        }
    }

    public void CreateTable()
    {
        SaveTable(GetComponent<ScoringTable>().Table);
    }

    public Table LoadTable()
    {
        

        Table table = new Table();
        if (PlayerPrefs.HasKey("name0"))
        {
            for (int i = 0; i < table.list.Length; i++)
            {
                table.list[i].name = PlayerPrefs.GetString("name" + i);
                table.list[i].scoring = PlayerPrefs.GetInt("name" + i);
            }
        }
        else
        {
            CreateTable();
        }
        return table;
    }

    public void Save(DataSave ds)
    {
        PlayerPrefs.SetFloat("musicValue", ds.music);
        PlayerPrefs.SetFloat("soundValue", ds.sound);
        //PlayerPrefs.SetInt("",);
        PlayerPrefs.Save();
    }

    public DataSave Load()
    {
        DataSave res = new DataSave();
        if (PlayerPrefs.HasKey("musicValue"))
        {
            res.music = PlayerPrefs.GetFloat("musicValue");
            res.sound = PlayerPrefs.GetFloat("soundValue");
        }
        else
        {
            Save(res);//defoult value
            Load();
        }
        return res;
    }
}
