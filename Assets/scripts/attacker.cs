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

    private int index = 0;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            index = 0;
            txt.SetText((index + 1).ToString());
        } else if (Input.GetKeyDown("2"))
        {
            index = 1;
            txt.SetText((index + 1).ToString());
        } else if (Input.GetKeyDown("3"))
        {
            index = 2;
            txt.SetText((index + 1).ToString());
        } else if (Input.GetKeyDown("w"))
        {
            Instantiate(enemies[index], new Vector3(0f, 2f, 9f), Quaternion.identity);
        } else if (Input.GetKeyDown("s"))
        {
            Instantiate(enemies[index], new Vector3(0f, 2f, -9f), Quaternion.identity);
        } else if (Input.GetKeyDown("a"))
        {
            Instantiate(enemies[index], new Vector3(-9f, 2f, 0f), Quaternion.identity);
        } else if (Input.GetKeyDown("d"))
        {
            Instantiate(enemies[index], new Vector3(9f, 2f, 0f), Quaternion.identity);
        }
    }
}
