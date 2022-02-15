using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class AllCharacter : MonoBehaviour
{
    public GameObject[] model;

    void Start()
    {
        model = Resources.LoadAll("Prefab/Character/", typeof(GameObject)).Cast<GameObject>().ToArray();
    }
}
