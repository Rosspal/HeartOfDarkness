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
        GetComponent<UiEventManager>().Click();
        Menu.transform.Find("BackgroundInfoExit").gameObject.SetActive(true);
    }

    public void ContinueGame()
    {
        GetComponent<UiEventManager>().Click();
        GetComponent<UiEventManager>().CloseMenu();
    }

    public void CloseExit()
    {
        GetComponent<UiEventManager>().Click();
        Menu.transform.Find("BackgroundInfoExit").gameObject.SetActive(false);
    }

    public void ExitMainMenu()
    {
        GetComponent<UiEventManager>().Click();
        GetComponent<SceneControler>().ExitMainMenu();
    }
}
