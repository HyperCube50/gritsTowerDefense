using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class selectorManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] buttons;

    public enum TowerType
    {
        OVERHEAT,
        MONKE
    }

    public TowerType currentType = TowerType.OVERHEAT;

    public void updateHighlights()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<Outline>().enabled = false;
        }

        buttons[(int)currentType].GetComponent<Outline>().enabled = true;
    }
}
