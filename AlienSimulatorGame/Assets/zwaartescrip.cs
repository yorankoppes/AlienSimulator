using UnityEngine;

public class zwaartescrip : MonoBehaviour
{
    public float sterMassa;
    public bool speler;
    public Vector2 snelheid;
    public float Motorkracht;
    public float Rotator;
    public GameObject explosion;
    public GameObject gas;
    bool isErGas = false;
    GameObject ditGas;

    public float zwaartekrachtConstante = -0.02f;

    void FixedUpdate()
    {
        float afstan = Mathf.Sqrt (Mathf.Pow(transform.position.x, 2) + Mathf.Pow(transform.position.y, 2));
        Vector2 richtin = new Vector2(transform.position.x / afstan, transform.position.y / afstan);
        float gravityStrength = sterMassa * (zwaartekrachtConstante / Mathf.Pow(afstan , 2) - 0.0001f);
        snelheid += richtin * gravityStrength;
        if (speler)
        {
            if (Input.GetKey(KeyCode.W))
            {
                snelheid += new Vector2(transform.up.x * Motorkracht, transform.up.y * Motorkracht);
                    
                if (!isErGas)
                {
                    ditGas = Instantiate(gas, transform.position, transform.rotation, transform);
                    ditGas.transform.Rotate(new Vector3(90, 90, 0));
                    isErGas = true;
                } 
            }

            else if (isErGas)
            {
                Destroy(ditGas);
                isErGas = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(0 , 0, Rotator);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0 , 0, -Rotator);
            }
        }

        transform.position += new Vector3(snelheid.x, snelheid.y, 0);
    }

    void OnCollisionEnter2D()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(ditGas);
        Destroy(gameObject);
    }
}
