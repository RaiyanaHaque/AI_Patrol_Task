using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {


    public void ResetBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);

    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void PlayGameBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
}
