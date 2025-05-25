using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeScript : MonoBehaviour
{
    public void ToUIScene()
    {
        SceneManager.LoadScene("CityScene", LoadSceneMode.Single);
    }

    public void ToSecondUIScene()
    {
        SceneManager.LoadScene("CityScene2", LoadSceneMode.Single);
    }

    public void ToMainMenue()
    {
        SceneManager.LoadScene("Menue", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }

}

