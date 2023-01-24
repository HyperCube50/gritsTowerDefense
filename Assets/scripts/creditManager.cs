using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class creditManager : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI attackerText;

    [SerializeField]
    TextMeshProUGUI defenderText;

    public int attackerCredit = 10;
    public int defenderCredit = 10;

    public void updateUI()
    {
        attackerText.SetText(attackerCredit.ToString());
        defenderText.SetText(defenderCredit.ToString());
    }
}
