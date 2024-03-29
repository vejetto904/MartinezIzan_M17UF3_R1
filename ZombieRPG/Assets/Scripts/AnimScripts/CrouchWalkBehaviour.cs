using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchWalkBehaviour : StateMachineBehaviour
{
    Animator _animator;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _animator = animator;
        InputController.Caminar += Caminar;
        InputController.Crouch += Crouch;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        InputController.Caminar -= Caminar;
        InputController.Crouch -= Crouch;
    }
    public void Caminar(bool camiar)
    {
        if (!camiar)
        {
            _animator.SetBool("isCrouchMove", false);
            _animator.SetBool("isCrouch", true);
            _animator.SetBool("isWalk", false);
        }
    }
    public void Crouch()
    {
        _animator.SetBool("isCrouchMove", false);
        _animator.SetBool("isCrouch", false);
        _animator.SetBool("isWalk", true);
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
