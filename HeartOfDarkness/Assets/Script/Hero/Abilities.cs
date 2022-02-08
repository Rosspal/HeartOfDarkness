using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities
{
    private List<string> ability = new List<string>();

    public Abilities()
    {

    }

    public bool Search(string title)
    {
        return ability.Contains(title);
    }


    public void AddAbility(params string[] title)
    {
        foreach (var n in title)
        {
            if (!ability.Contains(n))
            {
                ability.Add(n);
            }
        }
    }


    public void Remove(string title)
    {
        ability.Remove(title);
    }


    public string Info()
    {
        string info = "";

        foreach (var text in ability)
        {
            info += text + "/";
        }

        return info;
    }
}
