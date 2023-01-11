using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    [SerializeField]
    Material hostileMat;

    [SerializeField]
    Material patrolMat;

    Renderer _renderer;
    ParticleSystemRenderer pRenderer;

    NavMeshAgent agent;
    GameObject targetTower;

    bool patrol = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        pRenderer = GetComponent<ParticleSystemRenderer>();

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
                    targetTower = tower;
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
            _renderer.material = patrolMat;
            pRenderer.material = patrolMat;

            ScanAndMove();

            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                Patrol();
        }

        if (!patrol) {
            _renderer.material = hostileMat;
            pRenderer.material = hostileMat;

            if (!agent.pathPending && agent.remainingDistance < 0.5f || targetTower == null)
                ScanAndMove();
        }
    }

    void Patrol()
    {
        agent.SetDestination(new Vector3(Random.Range(-8f, 8f), 1f, Random.Range(-8f, 8f)));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tower"))
        {
            Destroy(other.gameObject);
        }
    }
}
