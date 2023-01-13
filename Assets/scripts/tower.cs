using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    GameObject closestEnemy = null;

    bool shooting = false;

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
            if (!shooting)
                StartCoroutine(damagePerSecond(closestEnemy, 1f));
        }
    }

    IEnumerator damagePerSecond(GameObject e, float dps)
    {
        shooting = true;

        enemy enemyComponent = e.GetComponent<enemy>();

        while (enemyComponent.hitPoint > 0)
        {
            yield return new WaitForSeconds(1f);
            enemyComponent.hitPoint -= dps;

            Debug.Log(enemyComponent.hitPoint);
        }

        shooting = false;
    }
}
