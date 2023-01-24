using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    [SerializeField]
    GameObject highLighter;

    [SerializeField]
    public GameObject[] towers;

    [HideInInspector]
    public GameObject tower;

    [HideInInspector]
    public tower towerComponent;

    [SerializeField] 
    creditManager creditm;

    GameObject[,] board;

    private void Start()
    {
        board = new GameObject[16, 16];

        tower = towers[0];

        towerComponent = tower.GetComponent<tower>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 20;

        RaycastHit hit;

        if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out hit))
        {
            Vector3 hitPoint = hit.point;
            hitPoint.x = Mathf.Floor(hitPoint.x) + 0.5f;
            hitPoint.z = Mathf.Floor(hitPoint.z) + 0.5f;


            if (hitPoint.x < 8 && hitPoint.x > -8 && hitPoint.z < 8 && hitPoint.z > -8) {
                highLighter.transform.position = hitPoint;

                hitPoint.y = towerComponent.spawnHeight;

                if (Input.GetMouseButtonDown(0))
                {
                    if (board[(int)(hitPoint.x + 7.5f), (int)(hitPoint.z + 7.5f)] == null)
                        if (creditm.defenderCredit - towerComponent.cost >= 0)
                        {
                            board[(int) (hitPoint.x + 7.5f), (int) (hitPoint.z + 7.5f)] = Instantiate(tower, hitPoint, Quaternion.Euler(towerComponent.startingRotation));
                            creditm.defenderCredit -= towerComponent.cost;
                            creditm.updateUI();
                        }
                } else if (Input.GetMouseButtonDown(1))
                {
                    Destroy(board[(int)(hitPoint.x + 7.5f), (int)(hitPoint.z + 7.5f)]);
                    board[(int)(hitPoint.x + 7.5f), (int)(hitPoint.z + 7.5f)] = null;

                }

                
            }
        }
    }
}
