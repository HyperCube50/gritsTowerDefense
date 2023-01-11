using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    NavMeshAgent agent;

    bool patrol = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        ScanAndMove();
    }

    void ScanAndMove()
    {
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower");

        if (towers.Length != 0)
        {
            patrol = false;

            float closestDist = Mathf.Infinity;
            Vector3 closestTowerPos = new Vector3();

            foreach (GameObject tower in towers)
            {
                float dist = Vector3.SqrMagnitude(transform.position - tower.transform.position);

                if (closestDist > dist)
                {
                    closestDist = dist;
                    closestTowerPos = tower.transform.position;
                }
            }

            agent.SetDestination(closestTowerPos);
        } else
        {
            patrol = true;
        }
    }

    private void Update()
    {
        if (patrol)
        {
            ScanAndMove();

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                Patrol();
        }

        if (!patrol && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            ScanAndMove();
        }
    }

    void Patrol()
    {
        agent.SetDestination(new Vector3(Random.Range(-8f, 8f), 1f, Random.Range(-8f, 8f)));
    }
}
