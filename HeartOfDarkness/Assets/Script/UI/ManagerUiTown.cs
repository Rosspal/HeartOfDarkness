using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUiTown : MonoBehaviour
{
    [SerializeField] GameObject Taverna;
    //[SerializeField] GameObject Store;
    //[SerializeField] GameObject Taverna;

    public void OpenTaverna()
    {
        Taverna.SetActive(true);
    }

    public void CloseTaverna()
    {
        Taverna.SetActive(false);
    }

    //public void OpenStore()
    //{
    //    Store.SetActive(true);
    //}

    //public void CloseStore()
    //{
    //    Store.SetActive(false);
    //}


}
