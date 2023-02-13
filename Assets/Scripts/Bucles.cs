using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucles : MonoBehaviour
{
    public int value = 9;
    private int i = 1;

    public string[] names;

    public Vector3[] positions;
    public GameObject prefab;

    void Start()
    {
        for (int i = 1; i <= 10; i++)
        {
            Debug.Log($"{value} * {i} = {value * i}");
        }

        for (int i = 0; i < name.Length; i++)
        {
            //Debug.Log(names[i]);
        }

        /*for (int i = 0; i < positions.Length; i++)
        {
            Instantiate(prefab, positions[i], Quaternion.identity);
        }*/

        foreach (Vector3 p in positions)
        {
            Instantiate(prefab, p,Quaternion.identity);
        }

        while (i <= 9)
        {
            Debug.Log($"{value} * {i} = {value * i}");
            i++;
        }
    }
}
