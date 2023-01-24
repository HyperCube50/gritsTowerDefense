using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class attacker : MonoBehaviour
{
    [SerializeField]
    GameObject[] enemies;

    [SerializeField]
    TextMeshProUGUI txt;

    [SerializeField]
    creditManager creditm;

    private int index = 0;
    private int cost = 1;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            index = 0;
            cost = calculateCost();
            txt.SetText((index + 1).ToString());
        } else if (Input.GetKeyDown("2"))
        {
            index = 1;
            cost = calculateCost();
            txt.SetText((index + 1).ToString());
        } else if (Input.GetKeyDown("3"))
        {
            index = 2;
            cost = calculateCost();
            txt.SetText((index + 1).ToString());
        }


        if (creditm.attackerCredit - cost >= 0)
        {
            if (Input.GetKeyDown("w"))
            {
                Instantiate(enemies[index], new Vector3(0f, 2f, 9f), Quaternion.identity);
                creditm.attackerCredit -= cost;
                creditm.updateUI();
            }
            else if (Input.GetKeyDown("s"))
            {
                Instantiate(enemies[index], new Vector3(0f, 2f, -9f), Quaternion.identity);
                creditm.attackerCredit -= cost;
                creditm.updateUI();
            }
            else if (Input.GetKeyDown("a"))
            {
                Instantiate(enemies[index], new Vector3(-9f, 2f, 0f), Quaternion.identity);
                creditm.attackerCredit -= cost;
                creditm.updateUI();
            }
            else if (Input.GetKeyDown("d"))
            {
                Instantiate(enemies[index], new Vector3(9f, 2f, 0f), Quaternion.identity);
                creditm.attackerCredit -= cost;
                creditm.updateUI();
            }
        }
    }

    int calculateCost()
    {
        switch (index)
        {
            case 0:
                return 1;
            case 1:
                return 5;
            case 2:
                return 10;
        }

        return -1;
    }
}
