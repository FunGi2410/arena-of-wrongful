using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float speedChase = 3.5f;
    float speedPatroll = 0.5f;

    float disToAttack = 2.5f;
    float disToIdle = 15f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent.speed = speedChase;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);

        // set attack and dont chasing
        float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance < disToAttack) animator.SetBool("isAttacking", true);
        if (distance > disToIdle)
        {
            animator.SetBool("isChasing", false);
            agent.speed = speedPatroll;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }
}
