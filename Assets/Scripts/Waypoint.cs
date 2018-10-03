using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour {

    [SerializeField]
    private float debugDrawRadius = 0.24f; //The size 

    private void OnDrawGizmos() //drawGizmos method
    {
        Gizmos.color = Color.green; //sets the color
        Gizmos.DrawWireSphere(transform.position, debugDrawRadius); //creates a sphere wire where the point is placed + previous size
    }
}
