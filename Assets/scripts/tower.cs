using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower : MonoBehaviour
{
    [SerializeField]
    public float spawnHeight;

    [SerializeField]
    public float laserHeight;

    [SerializeField]
    public Vector3 startingRotation;

    [SerializeField] public float dps;

    GameObject closestEnemy = null;

    bool shooting = false;

    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
    }

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
                StartCoroutine(damagePerSecond(closestEnemy, dps));
        }
    }

    IEnumerator damagePerSecond(GameObject e, float dps)
    {
        shooting = true;

        enemy enemyComponent = e.GetComponent<enemy>();

        while (enemyComponent.currentHitPoint > 0)
        {
            yield return new WaitForSeconds(0.1f);
            enemyComponent.currentHitPoint -= dps / 10f;

            lineRenderer.SetPosition(0, transform.position + new Vector3(0f, laserHeight, 0f));

            if (e != null)
                lineRenderer.SetPosition(1, e.transform.position);

            lineRenderer.enabled = true;
        }

        lineRenderer.enabled = false;
        shooting = false;
    }
}
