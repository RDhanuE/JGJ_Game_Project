using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Movement movement;
    [SerializeField] private AutomaticMovement automaticMovement;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        animator.SetBool("IsWalking", movement.IsWalking() || automaticMovement.IsWalking());
    }
}
