using Unity.VisualScripting;
using UnityEngine;

public class beatmapMove : MonoBehaviour
{
    GameplayManager gameplayManager;

    private void Start()
    {
        gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
    }
    void Update()
    {
        transform.position = transform.position += new Vector3(0.01f, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision);
        if (collision.gameObject.tag == "KillBeat")
        {
            gameplayManager.BeatsLeft--;
            GameObject.Destroy(gameObject);
        }
    }
}
