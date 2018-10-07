using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LaserDetector : MonoBehaviour
{

    public float rotationSpeed;
    public float distance;
    public GameObject deathEffect;

    public LineRenderer lineOfSight;
    public Gradient redColour;
    public Gradient greenColour;

    public Countdown countdownScript;

    // Use this for initialization
    void Start()
    {
        countdownScript = GameObject.Find("TimeController").GetComponent<Countdown>();
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
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColour;

            if (hitInfo.collider.CompareTag("Player"))
            {
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(hitInfo.collider.gameObject);
                countdownScript.PlayerDeath();

            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.green);
            lineOfSight.SetPosition(1, ray.origin + ray.direction * distance);
            lineOfSight.colorGradient = greenColour;
        }

        lineOfSight.SetPosition(0, transform.position);
    }
}
