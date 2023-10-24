using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_5 : MonoBehaviour
{
    public GameObject cubePref;
    private List<Vector3> reservedPositions = new List<Vector3>();

    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            float cubeX = Random.Range(-5.0f, 5.0f);
            float cubeZ = Random.Range(-5.0f, 5.0f);

            Vector3 position = new Vector3(cubeX, 0.5f, cubeZ);

            if (!reservedPositions.Contains(position))
            {
                Instantiate(cubePref, position, Quaternion.identity);
                reservedPositions.Add(position);
            }
            else
            {
                i--;
            }
        }   
    }
}
