using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomCubesGenerator : MonoBehaviour
{
    List<Vector3> positions = new List<Vector3>();
    public float delay = 3.0f;
    int objectCounter = 0;
    // obiekt do generowania
    public GameObject block;
    public int objectCount = 5; // iloœæ obiektów do wygenerowania
    public Material[] materials; //tablica materia³ów

    void Start()
    {
        // pobranie rozmiarów x, z platformy
        Bounds bounds = GetComponent<MeshFilter>().mesh.bounds;
        float platformX = bounds.size.x;
        float platformZ = bounds.size.z;
        Vector3 center = bounds.center;

        // w momecie uruchomienia generuje 10 kostek w losowych miejscach
        List<float> pozycje_x = new List<float>(Enumerable.Range(0, (int)platformX * 10).OrderBy(x => Guid.NewGuid()).Take(objectCount).Select(x => (float)x / 10 + center.x - platformX / 2));
        List<float> pozycje_z = new List<float>(Enumerable.Range(0, (int)platformZ * 10).OrderBy(z => Guid.NewGuid()).Take(objectCount).Select(z => (float)z / 10 + center.z - platformZ / 2));

        for (int i = 0; i < objectCount; i++)
        {
            this.positions.Add(new Vector3(pozycje_x[i], 5, pozycje_z[i]));
        }
        foreach (Vector3 elem in positions)
        {
            Debug.Log(elem);
        }
        // uruchamiamy coroutine
        StartCoroutine(GenerujObiekt());
    }

    void Update()
    {

    }

    IEnumerator GenerujObiekt()
    {
        Debug.Log("wywo³ano coroutine");
        foreach (Vector3 pos in positions)
        {
            GameObject newBlock = Instantiate(this.block, this.positions.ElementAt(this.objectCounter++), Quaternion.identity);
            newBlock.GetComponent<Renderer>().material = materials[UnityEngine.Random.Range(0, materials.Length)];
            yield return new WaitForSeconds(this.delay);
        }
        // zatrzymujemy coroutine
        StopCoroutine(GenerujObiekt());
    }
}