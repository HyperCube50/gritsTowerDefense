using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    [SerializeField]
    Material hostileMat;

    [SerializeField]
    Material patrolMat;
    
    creditManager creditm;

    Renderer _renderer;
    ParticleSystemRenderer pRenderer;

    NavMeshAgent agent;
    GameObject targetTower;

    bool patrol = false;

    public float maxHitPoint = 10f;
    public float currentHitPoint;

    public Slider healthSlider;
    public Gradient gradient;
    public Image fill;

    // Start is called before the first frame update
    void Start()
    {
        currentHitPoint = maxHitPoint;
        healthSlider.maxValue = maxHitPoint;
        healthSlider.value = currentHitPoint;
        fill.color = gradient.Evaluate(1f);
        agent = GetComponent<NavMeshAgent>();
        _renderer = GetComponent<Renderer>();
        pRenderer = GetComponent<ParticleSystemRenderer>();

        creditm = GameObject.FindGameObjectWithTag("Manager").GetComponent<creditManager>();

        ScanAndMove();
    }

    void ScanAndMove()
    {
        List<GameObject> towers = GameObject.FindGameObjectsWithTag("Tower").ToList();

        GameObject townhall = GameObject.FindGameObjectWithTag("Townhall");

        if (townhall != null)
        {
            towers.Add(townhall);
        }

        if (towers.Count != 0)
        {
            patrol = false;

            float closestDist = Mathf.Infinity;
            Vector3 closestTowerPos = new Vector3();

            foreach (GameObject t in towers)
            {
                float dist = Vector3.SqrMagnitude(transform.position - t.transform.position);

                if (closestDist > dist)
                {
                    closestDist = dist;
                    closestTowerPos = t.transform.position;
                    targetTower = t;
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
        //Health bar
        healthSlider.value = currentHitPoint;
        fill.color = gradient.Evaluate(healthSlider.normalizedValue);
      

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

        if (currentHitPoint <= 0)
        {
            creditm.defenderCredit += 1;
            creditm.updateUI();
            Destroy(gameObject);
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
            creditm.attackerCredit += 2;
            creditm.updateUI();

            Destroy(other.gameObject);
        } else if (other.gameObject.CompareTag("Townhall"))
        {
            creditm.defenderCredit = 0;
            creditm.updateUI();

            Destroy(other.gameObject);
        }
    }
}
