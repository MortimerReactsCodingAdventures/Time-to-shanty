using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public GameObject results;


    public int BeatsLeft;
    public bool gameStarted;

    public bool playMusic = false;

    private void Update()
    {
        TimerCheck();
        FinishCheck();
    }

    void FinishCheck()
    {
        if (gameStarted && BeatsLeft <= 0)
        {
            results.SetActive(true);
            //Show Results screen

            /*results screen will need:
            #Beats hit
            #Beats missed
            #hit Percentage
            #different text based on hit percentage
            #return to menu button
            */

        }
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
        else if(gameStarted == false)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        gameStarted = true;
        timerText.SetActive(false);
        Beatmap.SetActive(true);
        FindAllBeats();
        playMusic = true;
    }

    //finds the total amount of beats so I can show the results when all beats have been hit
    public void FindAllBeats()
    {
        GameObject[] beats = GameObject.FindGameObjectsWithTag("Clickable");
        foreach (GameObject beat in beats)
        {
            BeatsLeft++;
        }
    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void SongComplete()
    {
        //stop scrolling on beatmap
    }
}
