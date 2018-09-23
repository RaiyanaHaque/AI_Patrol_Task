using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Controller : MonoBehaviour {

    //true or false the patrol waits at a node
    [SerializeField]
    bool _patrolWaiting;

    //time waited at a node
    [SerializeField]
    float _totalWaitTime = 2f;

    //probability of switing direction
    [SerializeField]
    float _switchProbability = 0.2f;

    //list of patrol nodes
    [SerializeField]
    List<Waypoint> _patrolPoints;

    //main behaviours 
    [SerializeField]
    NavMeshAgent _navMeshAgent;
    int _currentPatrolIndex;
    bool _travelling;
    bool _waiting;
    bool _patrolForward;
    float _waitTimer;

   // [SerializeField]
//public float distance;
   // public GameObject deathEffect;
    

    // Use this for initialization
    void Start () {

        _navMeshAgent = GetComponent<NavMeshAgent>();

        if(_navMeshAgent == null)
        {
            Debug.Log("The navmesh agent in not attached to the object" + gameObject.name); 
        }

        else
        {
            if (_patrolPoints != null && _patrolPoints.Count >= 2)
            {
                _currentPatrolIndex = 0;
                SetDestination();
            }

            else
            {
                Debug.Log("Needs more points");
            }
        }
	}

    public void Update()
    {
        //check if close to destination
        if (_travelling && _navMeshAgent.remainingDistance <= 1.0f)
        {
            _travelling = false; 

            //if going to wait then wait
            if (_patrolWaiting)
            {
                _waiting = true;
                _waitTimer = 0f; 
            }

            else
            {
                ChangePatrolPoint();
                SetDestination();
            }
        }

        //insted if waiting
        if(_waiting)
        {
            _waitTimer += Time.deltaTime;
            if (_waitTimer >= _totalWaitTime)
            {
                _waiting = false;

                ChangePatrolPoint();
                SetDestination();
            }

        }

       /* Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, distance))
        {
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);

            if (hitInfo.collider.CompareTag("Player"))
            {
                _navMeshAgent.enabled = !_navMeshAgent;
                //Instantiate(deathEffect, transform.position, Quaternion.identity);
                Destroy(hitInfo.collider.gameObject); 
                //not detroying player most likely it is in the state of patrolling

            }
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * distance, Color.green);
        } */

    }

    private void SetDestination()
    {
        if(_patrolPoints!= null)
        {
            Vector3 targetVector = _patrolPoints[_currentPatrolIndex].transform.position;
            _navMeshAgent.SetDestination(targetVector);
            _travelling = true;
        }
    }

    /// <summary>
    /// Select a new patrol point in the list
    /// also with a small probability allows for us to move forward or backwards
    /// </summary>
    
    private void ChangePatrolPoint()
    {
        if(UnityEngine.Random.Range(0f, 1f) <= _switchProbability)
        {
            _patrolForward = !_patrolForward;
        }

        if (_patrolForward)
        {
            /*
            _currentPatrolIndex++;
            if (_currentPatrolIndex >=_patrolPoints.Count)
            {
                _currentPatrolIndex = 0;
            }

            */

            _currentPatrolIndex = (_currentPatrolIndex + 1) % _patrolPoints.Count; //modulas command
        }

        else
        {
            if(--_currentPatrolIndex < 0) //decrement -- then check if its less than 0
            {
                _currentPatrolIndex = _patrolPoints.Count - 1;
            }
        }
    }


}
