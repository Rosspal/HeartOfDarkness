using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagItem : MonoBehaviour
{
    public List<Item> bag = new List<Item>();
    public Weapon blade = new Weapon("������ ������ ������","���", 5, 4,"�������",1,2);
    public Armor tors = new Armor("������� � �����", "�������", 5, 4, "������", 4);
    public Weapon blade1 = new Weapon();



    private void Start()
    {
        bag.Add(blade);
        bag.Add(tors);
        Debug.Log("0 - " + bag[0].info());
        Debug.Log("1 - " + bag[1].info());
        blade1.Copy(bag[0].Data());
        Debug.Log("blade - " + blade1.info());
    }
}
