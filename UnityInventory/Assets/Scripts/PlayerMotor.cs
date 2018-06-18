using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]   //Unity will automatically add a NavMeshAgent whenever we call this component
public class PlayerMotor : MonoBehaviour
{
    Transform target;   //Creates a target reference
    NavMeshAgent agent; //Creates a NavMeshAgent reference

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
	}

    void Update()
    {
        if (target != null)
        {
            //Sets the Players destination to the targets position
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);    //Moves our agent to the point
    }

    public void FollowTarget(Interactable newTarget)
    {
        //Makes sure we stop inside the targets radius
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;


        //Sets our target to the interactable
        target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
    }

    void FaceTarget()
    {
        //Direction towards the target
        Vector3 direction = (target.position - transform.position).normalized;
        //Quanternion is the objects rotation
        //Rotates the player to look in the direction of the target
        Quaternion lookRotaion = Quaternion.LookRotation(new Vector3(direction.x, 0.0f, direction.z));

        //Quanternion slerp interpulates between two points
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotaion, Time.deltaTime * 5.0f);
    }
}
