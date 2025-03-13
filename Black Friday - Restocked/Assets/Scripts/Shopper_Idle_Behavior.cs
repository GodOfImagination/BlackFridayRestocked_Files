using UnityEngine;
using UnityEngine.AI;

public class Shopper_Idle_Behavior : StateMachineBehaviour
{
    private NavMeshAgent ShopperController;
    private float ShopperIdleTime;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ShopperIdleTime = 0;

        ShopperController = animator.GetComponent<NavMeshAgent>();
        ShopperController.SetDestination(ShopperController.transform.position);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ShopperIdleTime += Time.deltaTime;

        if (ShopperIdleTime > 5) animator.SetBool("isWalking", true);
    }
}
