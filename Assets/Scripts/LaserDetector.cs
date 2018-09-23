using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserDetector : MonoBehaviour
{

    public float rotationSpeed;
    public float distance;
    public GameObject deathEffect;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);

            if(hitInfo.collider.CompareTag("Player"))
            {
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
