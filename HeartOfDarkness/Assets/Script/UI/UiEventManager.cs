using UnityEngine;

public class UiEventManager : MonoBehaviour
{
    [SerializeField] Canvas Town;
    [SerializeField] Canvas BattleEvent;
    [SerializeField] Camera BattleCam;
    [SerializeField] Camera MainCam;


    void Start()
    {
        Town.enabled = false;
        BattleEvent.enabled = false;
        BattleCam.enabled = false;
        MainCam.enabled = true;
    }


    public void OpenTown()
    {
        Town.enabled = true;
        GetComponent<ManagerUiTown>().RefreshHealingCost();
        //MainCam.GetComponent<TileClicker>().Activ = false;
    }

    public void CloseTown()
    {
        Town.enabled = false;
        //MainCam.GetComponent<TileClicker>().Activ = true;
    }

    public void OpenBattleEvent()
    {
        
        BattleEvent.enabled = true;
        MainCam.GetComponent<TileClicker>().Activ = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleStart();

    }

    public void CloseBattleEvent()
    {
        BattleEvent.enabled = false;
        MainCam.GetComponent<TileClicker>().Activ = true;
        BattleCam.enabled = false;

    }
}
