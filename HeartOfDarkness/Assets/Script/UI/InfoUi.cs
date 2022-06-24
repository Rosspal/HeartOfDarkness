using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoUi : MonoBehaviour
{
    [SerializeField] TeamContainer TC;
    [SerializeField] Canvas info;

    public void Refresh()
    {
        info.transform.Find("Panel").Find("Text").GetComponent<TextMeshProUGUI>().text = "Золото: " + TC.Money + "     Очки: " + TC.Score;
    }
}
