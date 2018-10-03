using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    public GameObject deathEffect; 

    


	// Use this for initialization
	void Start () {

        moveSpeed = 3.5f;
    
	}
	
	// Update is called once per frame
	void Update () {

        transform.Translate(moveSpeed*Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed*Input.GetAxis("Vertical") * Time.deltaTime);

        
	}
}
