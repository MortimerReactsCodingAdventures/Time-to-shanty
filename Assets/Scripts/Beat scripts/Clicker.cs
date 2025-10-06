using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class clicker : MonoBehaviour
{
    public GameObject clicked;
    public BoxCollider2D myCollision;
    public int testScore;
    public TextMeshProUGUI scoreText;
    public GameplayManager gameplayManager;
    public TextMeshProUGUI hitText;


    public int beatsHit = 0;
    public int beatsMissed = 0;


    void Start()
    {
        myCollision = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print("Space hit");
        }

        //this works well. when the object labeled as "clicked" is colliding with the "clicker" a message will be printed to console saying "hit". if they are not colliding it will say "miss"
        if (clicked != null)
        {
            if (myCollision.bounds.Intersects(clicked.GetComponent<BoxCollider2D>().bounds) && Input.GetKeyDown(KeyCode.Space))
            {
                print("hit");
                //test score code
                testScore++;
                scoreText.text = "Score " + testScore;
                clicked.GetComponent<SpriteRenderer>().enabled = false;
                clicked.GetComponent<BoxCollider2D>().enabled = false;
                gameplayManager.BeatsLeft--;
                beatsHit++;
                hitText.text = (beatsHit.ToString() + "/" + beatsMissed.ToString());
            }
            else if(Input.GetKeyDown(KeyCode.Space))
            {
                //test score code
                testScore--;
                beatsMissed++;
                scoreText.text = "Score " + testScore;
                hitText.text = (beatsHit.ToString() + "/" + beatsMissed.ToString());
                print("Miss");
            }

            //if the tag of the collided object is "Hold" give points for holding down by checking for if the key is released after pressing down
            //if you release early the entire note should disappear
            //give bonus points at the end of a long note on release
            Input.GetKeyUp(KeyCode.Space);


        }
    }

    //I hate collision checks
    //I need to set "clicked" to the object that is currently aligned with the clicker to enable a valid click
    //A trigger needs to be used as when the sprites are moving they would otherwise collide with eachother

    private void OnTriggerEnter2D(Collider2D collision)
    {
        clicked = collision.gameObject;
    }

}
