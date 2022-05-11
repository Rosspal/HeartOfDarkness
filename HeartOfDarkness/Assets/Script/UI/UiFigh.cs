using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiFigh : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Log;

    public void WriteLog(string str)
    {
       Log.text = str;
    }

    public void WriteLineLog(string str)
    {
        Log.text +="\n" + str;
    }
}
