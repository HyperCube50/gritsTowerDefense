using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hueShift : MonoBehaviour
{
    [SerializeField]
    Material mat;

    [SerializeField]
    float speed = 1f;

    int[] redList;
    int[] greenList;
    int[] blueList;

    float r = 1f;
    float g = 0f;
    float b = 0f;

    float t = 0;

    // Start is called before the first frame update
    void Start()
    {
        redList = new int[] { 1, 1, 0, 0, 0, 1, 1 };
        greenList = new int[] { 0, 1, 1, 1, 0, 0, 0 };
        blueList = new int[] { 0, 0, 0, 1, 1, 1, 0 };

    }

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;

        if (t >= 6)
            t = 0;

        int floored = Mathf.FloorToInt(t);
        int ceiled = Mathf.CeilToInt(t);

        r = Mathf.Lerp(redList[floored], redList[ceiled], t - floored);
        g = Mathf.Lerp(greenList[floored], greenList[ceiled], t - floored);
        b = Mathf.Lerp(blueList[floored], blueList[ceiled], t - floored);

        mat.SetColor("_EmissionColor", new Color(r, g, b) * 1.5f);
    }
}
