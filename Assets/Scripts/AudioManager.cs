using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    //gameplay stuff
    GameplayManager gameplayManager;


    //Audio sources
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioSource playSource;

    //Audio thats being used will be inputed in to these
    public AudioClip menu;
    public AudioClip game;
    public AudioClip game1;
    public AudioClip game2;
    public AudioClip Button;

    public static AudioManager instance;

    bool musicPlaying;

    public bool gameT = false;
    public bool gameT1 = false;
    public bool gameT2 = false;

    //This checks to see if there is multiple of the audio manager
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        //plays the menu music
        musicSource.clip = menu;

        musicSource.Play();
    }


    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        //This plays the audio for the menu
        if (currentScene.name == "MainMenu" && musicPlaying == false)
        {
            musicSource.clip = menu;
            musicSource.Play();
            musicPlaying = true;
        }

        //This plays audio for the game
        if (currentScene.name == "Gameplay development" && musicPlaying)
        {
            musicSource.Stop();

            gameplayManager = GameObject.FindAnyObjectByType<GameplayManager>();

            //checks against my gameplay manager script to see if the countdown is finished

            if (gameplayManager != null)
            {
                if (gameplayManager.playMusic == true)
                {
                    gameMusic();
                    Debug.Log("work");
                    musicSource.Play();
                    musicPlaying = false;
                }
            }

        }

    }
    public void gameMusic()
    {
        if (gameT == true)
        {
            musicSource.clip = game;
            
        }
        else if (gameT1 == true)
        {
            musicSource.clip = game1;
            
        }
        else if (gameT2 == true)
        {
            musicSource.clip = game2;
            
        }
    }
    public void Song()
    {
        gameT = true;
        gameT1 = false;
        gameT2 = false;
    }
    public void Song1()
    {
        gameT1 = true;
        gameT2 = false;
        gameT = false;
    }
    public void Song2()
    {
        gameT2 = true;
        gameT1 = false;
        gameT = false;
    }

    //This can be used to play the audio from outside the script
    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
    public void Playplay(AudioClip clip)
    {
        playSource.PlayOneShot(clip);
    }
}
