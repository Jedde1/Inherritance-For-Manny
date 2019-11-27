using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Enemy : Humanoid
{
    public enum AIState
    {
        Patrol
    }
    public Transform waypointParent;
    protected Transform[] waypoints;
    public NavMeshAgent agent;
    public GameObject self;
    public int curWaypoint;
    public AIState state;
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();
        agent = self.GetComponent<NavMeshAgent>();
        curWaypoint = 1;
        agent.speed = speed / 2;
        Patrol();
    }

    // Update is called once per frame
    public override void Update()
    {
        Patrol();
    }
    public void Patrol()
    {

        //DO NOT CONTINUE IF NO WAYPOINTS
        if (waypoints.Length == 0)
        {
            return;
        }
        state = AIState.Patrol;
        
        agent.speed = speed / 2;

        //Follow waypoints
        //Set agent to target
        agent.destination = waypoints[curWaypoint].position;
        //Are we at the waypoint
        if (self.transform.position.x.Equals(agent.destination.x))
        {
            if (curWaypoint < waypoints.Length - 1)
            {
                //If so go to next waypoin
                curWaypoint++;
            }
            else
            {
                //If at end of patrol go to start
                curWaypoint = 1;
            }
        }
        //If so go to next waypoint
    }
}
