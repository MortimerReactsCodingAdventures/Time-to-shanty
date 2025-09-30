using UnityEngine;

public class beatmapMove : MonoBehaviour
{

    void Update()
    {
        transform.position = transform.position += new Vector3(0.01f, 0, 0);
    }
}
