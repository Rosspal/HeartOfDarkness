using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerUiTown : MonoBehaviour
{
    [SerializeField] Camera Taverna;
    [SerializeField] Canvas TavernaUi;
    [SerializeField] Canvas Town;
    [SerializeField] GameObject Main;


    //[SerializeField] GameObject Store;
    //[SerializeField] GameObject Taverna;

    void Start()
    {
        Town.enabled = false;
        Taverna.enabled = false;
        TavernaUi.enabled = false;
    }

    public void OpenTaverna()
    {
        Town.enabled = false;
        Main.GetComponent<Camera>().enabled = false;
        Taverna.enabled = true;
        TavernaUi.enabled = true;
    }

    public void CloseTaverna()
    {
        Town.enabled = true;
        Main.GetComponent<Camera>().enabled = true;
        Taverna.enabled = false;
        TavernaUi.enabled = false;
    }

    public void CloseTown()
    {
        Main.GetComponent<TileClicker>().CameraMove(true);
        Town.enabled = false;
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
