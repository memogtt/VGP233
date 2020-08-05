using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField]
    private float alertRadius = 3.0f;

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Transform[] patrolNodes;

    [SerializeField]
    private float startingTime = 3.0f;
    private float stoppingTime;

    private int currentPatrolNodeIndex = 0;

    [SerializeField]
    private float distanceFromPatrolNode = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        stoppingTime = startingTime;
        UpdatePatrolNodeIndex();
    }

    // Update is called once per frame
    void Update()
    {
        if (!target.GetComponent<PlayerMovement>().IsGameOver())
        {
            if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= Math.Pow(alertRadius, 2.0))
            //if(Vector3.Distance(target.transform.position,transform.position)<= alertRadius) 
            {
                agent.SetDestination(target.transform.position);
                if (agent.remainingDistance < 1.3f)
                {
                    target.GetComponent<PlayerMovement>().health--;
                    GameObject.FindObjectOfType<UI>().health.text = target.GetComponent<PlayerMovement>().health.ToString();
                }
            }
            else
            {
                //if (Vector3.Distance(this.transform.position,patrolNodes[currentPatrolNodeIndex].position) <= distanceFromPatrolNode)
                if (!agent.pathPending && agent.remainingDistance < distanceFromPatrolNode)
                {

                    //Patrol Update
                    if (stoppingTime > 0.0)
                    {
                        stoppingTime -= Time.deltaTime;
                    }
                    else
                    {
                        UpdatePatrolNodeIndex();
                        stoppingTime = startingTime;

                    }
                }
            }
        } else
        {
            agent.isStopped = true;
        }
        //PersuePlayer();

    }

    private void UpdatePatrolNodeIndex()
    {
        if (patrolNodes.Length > 0)
        {
            currentPatrolNodeIndex = (currentPatrolNodeIndex + 1) % patrolNodes.Length;
            agent.SetDestination(patrolNodes[currentPatrolNodeIndex].position);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, alertRadius);
    }

    private void PersuePlayer()
    {
        if (Vector3.SqrMagnitude(target.transform.position - transform.position) <= Math.Pow(alertRadius, 2.0))
        //if(Vector3.Distance(target.transform.position,transform.position)<= alertRadius) 
        {
            agent.SetDestination(target.transform.position);
            agent.updatePosition = false;

        }
    }

    public float getPatrolDistance()
    {
        return distanceFromPatrolNode;
    }

}
