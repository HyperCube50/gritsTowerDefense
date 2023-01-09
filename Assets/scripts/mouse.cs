using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouse : MonoBehaviour
{
    [SerializeField]
    GameObject highLighter;

    [SerializeField]
    GameObject tower;

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

                if (Input.GetMouseButtonDown(0))
                {
                    hitPoint.y = 1;
                    Instantiate(tower, hitPoint, Quaternion.identity);
                }
            }
        }
    }
}
