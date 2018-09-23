using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Laser : MonoBehaviour {

    public float distance;
    public GameObject deathEffect;
   

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {


        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);

            if (hitInfo.collider.CompareTag("Player"))
            {
                // the laser does not work because the cube keeps patrolling
                // ignoring the attack
                // turn off other components so that its not ignored
                GetComponent<NPC_Controller>().enabled = false;
                GetComponent<NavMeshAgent>().enabled = false;
                // ^^ should be a much more efficient way
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(hitInfo.collider.gameObject);

            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.green);
        }

    }
}