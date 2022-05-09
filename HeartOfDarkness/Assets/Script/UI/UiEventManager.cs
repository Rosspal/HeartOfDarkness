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
    }

    public void CloseTown()
    {
        Town.enabled = false;
    }

    public void OpenBattleEvent()
    {
        
        BattleEvent.enabled = true;
        //MainCam.enabled = false;
        BattleCam.enabled = true;
        GetComponent<GameControler>().BattleStart();

    }

    public void CloseBattleEvent()
    {
        BattleEvent.enabled = false;
        //MainCam.enabled = true;
        BattleCam.enabled = false;

    }
}
