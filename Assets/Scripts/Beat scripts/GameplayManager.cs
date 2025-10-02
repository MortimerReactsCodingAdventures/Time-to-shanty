using TMPro;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    /*Things to add in this script
     * Match start time
     * Score management
     * checking when the song has finished
     * returning to menu
     * displaying results screen
    */

    float timer = 3.5f;
    public GameObject timerText;
    public GameObject Beatmap;

    private void Update()
    {
        TimerCheck();
    }


    public void TimerCheck()
        //This is a timer to start the game. it displays the time on the screen
    {
        if (timer > .5)
        {
            timer -= Time.deltaTime;
            timerText.GetComponent<TextMeshProUGUI>().text = Mathf.RoundToInt(timer).ToString();
            //changes number from float to int to string so the text displayed does not show decimals
        }
        //instead of showing 0 on the timer it will display Go! as it looks better
        else if (timer <= .5 && timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.GetComponent<TextMeshProUGUI>().text = "Go!";
            //im looking for a good font to put for the numbers and text
        }
        else
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        timerText.SetActive(false);
        Beatmap.SetActive(true);
        //begin music (Marks problem)
    }

    void SongComplete()
    {
        //stop scrolling on beatmap
    }
}
