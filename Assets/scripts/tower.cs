using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{/*
    GameObject closestEnemy = null;

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float closestDist = Mathf.Infinity;

        if (closestEnemy == null)
        {
            foreach (GameObject e in enemies)
            {
                float dist = Vector3.SqrMagnitude(transform.position - e.transform.position);

                if (closestDist > dist)
                {
                    closestDist = dist;
                    closestEnemy = e;
                }
            }
        } else
        {
            StartCoroutine(damagePerSecond(closestEnemy, 1f));
        }
    }

    IEnumerator damagePerSecond(GameObject e, float dps)
    {
        while (e.GetComponent)

        e.GetComponent<enemy>().hitPoint -= dps;

        Debug.Log(e.GetComponent<enemy>().hitPoint);

        yield return new WaitForSeconds(1f);
    }*/
}
