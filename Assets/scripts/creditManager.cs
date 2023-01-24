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

    private void Start()
    {
        InvokeRepeating("addCredit", 3f, 3f);
    }

    public void updateUI()
    {
        attackerText.SetText(attackerCredit.ToString());
        defenderText.SetText(defenderCredit.ToString());
    }

    void addCredit()
    {
        attackerCredit++;
        defenderCredit++;

        updateUI();
    }
}
