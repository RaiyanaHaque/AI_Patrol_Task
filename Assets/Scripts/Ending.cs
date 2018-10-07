using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{

    public GameObject _taskPanel;

    // Use this for initialization
    void Start()
    {

        _taskPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(2);
        }
    }

}