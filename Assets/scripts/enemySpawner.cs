using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, 5f);
    }

    void SpawnEnemy()
    {
        Instantiate(enemy, new Vector3(8f, 1f, 0f), Quaternion.identity);
    }
}
