using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.GridLayoutGroup;

public class RunBehaviour : StateMachineBehaviour
{
    Animator _animator;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        InputController.Correr += Correr;
        InputController.Caminar += Caminar;
        InputController.Jump += Jump;

    }
    public void Correr()
    {
        _animator.SetBool("isRun", false);
    }
    public void Caminar(bool caminar)
    {
        if (!caminar) 
        { 
        _animator.SetBool("isWalk", false);
        _animator.SetBool("isRun", false);
        }
    }
    public void Jump()
    {
        _animator.SetBool("RuningJump", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputController.Correr -= Correr;
        InputController.Caminar -= Caminar;
        InputController.Jump -= Jump;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
