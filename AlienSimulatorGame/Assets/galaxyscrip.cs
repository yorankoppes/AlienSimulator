using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class galaxyscrip : MonoBehaviour
{
    public int size;
    public float scale;
    public GameObject ster;

    // Start is called before the first frame update
    void Start()
    {
       for (int i = 0; i < size; i++)
       {
            float richtin = Random.Range(0, (Mathf.Pow(2.01f, 3)));
            Vector2 Positie = new Vector2(scale * Mathf.Sin(richtin) * richtin, scale * Mathf.Cos(richtin) * richtin);
            Positie += new Vector2(scale * 0.256f * Random.Range(-3, 3.01f) * Random.Range(-3, 3.01f) * Random.Range(-Mathf.Sqrt(richtin), Mathf.Sqrt(richtin)), scale * 0.256f * Random.Range(-3, 3.01f) * Random.Range(-3, 3.01f) * Random.Range(-Mathf.Sqrt(richtin), Mathf.Sqrt(richtin)));
            Instantiate(ster, new Vector3(Positie.x, Positie.y, 0), Quaternion.identity);
       }
    }
}