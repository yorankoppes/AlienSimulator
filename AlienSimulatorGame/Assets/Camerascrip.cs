using UnityEngine;

public class Camerascrip : MonoBehaviour
{
    public Transform raket;
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(raket.position.x, raket.position.y, -10);
    }
}
