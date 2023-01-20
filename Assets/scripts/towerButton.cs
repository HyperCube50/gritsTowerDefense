using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerButton : MonoBehaviour
{
    [SerializeField]
    selectorManager manager;

    [SerializeField]
    selectorManager.TowerType type;

    public void onClick()
    {
        manager.currentType = type;
        manager.updateHighlights();
    }
}
