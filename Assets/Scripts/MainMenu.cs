using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public bool map = false;
    public bool map1 = false;
    public bool map2 = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        //changes to the game scene when the method play gets called
        SceneChange();

    }

    public void SceneChange()
    {
        if (map == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
        else if (map1 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

        }
        else if (map2 == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

        }
    }

    public void scene()
    {
        map = true;
        map1 = false;
        map2 = false;
    }
    public void scene1()
    {
        map1 = true;
        map2 = false;
        map = false;
    }
    public void scene2()
    {
        map2 = true;
        map1 = false;
        map = false;
    }

}
