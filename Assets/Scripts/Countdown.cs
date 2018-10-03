using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{

    [SerializeField] private Text _uiText;
    [SerializeField] private float _mainTimer;

    private float _timer;
    private bool _canCount = true;
    private bool _doOnce = false;

    public GameObject _taskPanel;


    private void Start()
    {
        _taskPanel.SetActive(false);
        _timer = _mainTimer;
    }


    private void Update()
    {
        if (_timer >= 0.0f && _canCount)
        {
            _timer -= Time.deltaTime;
            _uiText.text = _timer.ToString("F"); //converting the timer into a string
        }

        else if (_timer <= 0.0f && !_doOnce) //when the time is zero and do_Once is true
        {
            _canCount = false;
            _doOnce = true;
            _uiText.text = "0.00";
            _timer = 0.0f;
            GameOver();
        }
    }

    public void ResetBtn()
    {
        Time.timeScale = 1;
        _timer = _mainTimer;
        _canCount = true;
        _doOnce = false;
        SceneManager.LoadScene(0);

    }

    public void ExitBtn()
    {
       
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void PlayGameBtn()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        Pause();
        _taskPanel.SetActive(true);
    }
}
