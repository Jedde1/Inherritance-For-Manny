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
    public Transform waypointParent;//Determine central position of the waypoints
    protected Transform[] waypoints;//Adds all waypoints into an array
    public NavMeshAgent agent;//Uses a navmesh to allow the AI to move around and avoid places that it should not go
    public GameObject self;//Allows the engine to determine what object is using the script
    public int curWaypoint;//Tells the enemy what waypoint they just went to and what waypoint is next
    public AIState state;//Uses the enums to tell what state the enemy is
    // Start is called before the first frame update
    void Start()
    {
        waypoints = waypointParent.GetComponentsInChildren<Transform>();//uses the waypoints in the waypoint parent
        agent = self.GetComponent<NavMeshAgent>();//tells the enemy to stay in the navmesh
        curWaypoint = 1;//sets default waypoint
        agent.speed = speed / 2;//tells the enemy to move at half the speed at which the humaoid and determined
        Patrol();//tells the AI to use patrol function
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
        
        agent.speed = speed / 2;//Tells enemy to move at half speed

        //Follow waypoints
        //Set agent to target
        agent.destination = waypoints[curWaypoint].position;
        //Are we at the waypoint
        if (self.transform.position.x.Equals(agent.destination.x))
        {
            if (curWaypoint < waypoints.Length - 1)
            {
                //If so go to next waypoint
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
