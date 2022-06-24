using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem : MonoBehaviour
{
    [SerializeField] List<Item> bag = new List<Item>();
    private float weightLimit;



    private void Start()
    {

    }
}
