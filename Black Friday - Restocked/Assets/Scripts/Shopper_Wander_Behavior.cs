using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shopper_Wander_Behavior : StateMachineBehaviour
{
    private NavMeshAgent ShopperController;
    private List<Transform> ShopperWayPoints = new List<Transform>();

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform WayPointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform WayPoint in WayPointsObject) ShopperWayPoints.Add(WayPoint);

        ShopperController = animator.GetComponent<NavMeshAgent>();
        ShopperController.SetDestination(ShopperWayPoints[Random.Range(0, ShopperWayPoints.Count)].position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (ShopperController.remainingDistance <= ShopperController.stoppingDistance) animator.SetBool("isWalking", false);
    }
}
