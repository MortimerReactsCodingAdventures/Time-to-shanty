using Unity.VisualScripting;
using UnityEngine;

public class beatmapMove : MonoBehaviour
{
    GameplayManager gameplayManager;
    clicker clicker;

    private void Start()
    {
        gameplayManager = GameObject.FindGameObjectWithTag("GameplayManager").GetComponent<GameplayManager>();
        clicker = GameObject.FindGameObjectWithTag("CLicker").GetComponent<clicker>();
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
            clicker.beatsMissed++;
            gameplayManager.BeatsLeft--;
            clicker.hitText.text = (clicker.beatsHit.ToString() + "/" + clicker.beatsMissed.ToString());
            GameObject.Destroy(gameObject);
        }
    }
}
