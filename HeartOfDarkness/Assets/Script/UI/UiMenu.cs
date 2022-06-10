using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMenu : MonoBehaviour
{
    [SerializeField] Canvas Menu;
    public void Awake()
    {
        Menu.transform.Find("BackgroundInfoExit").gameObject.SetActive(false);
    }

    public void OpenExit()
    {
        Menu.transform.Find("BackgroundInfoExit").gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        GetComponent<UiEventManager>().CloseMenu();
    }

    public void CloseExit()
    {
        Menu.transform.Find("BackgroundInfoExit").gameObject.SetActive(false);
    }

    public void ExitMainMenu()
    {
        GetComponent<SceneControler>().ExitMainMenu();
    }
}
