using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public GameObject deathEffect;

    public GameObject _deathPanel;
    


	// Use this for initialization
	void Start () {

        _deathPanel.SetActive(false);
        moveSpeed = 3.5f;
    
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(moveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical") * Time.deltaTime);

        if (this.gameObject == null)
        {
            Time.timeScale = 0;
            _deathPanel.SetActive(true);
        }
        
	}
}
