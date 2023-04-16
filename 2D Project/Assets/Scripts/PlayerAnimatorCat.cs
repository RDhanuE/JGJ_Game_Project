using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorCat : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private CatMovement catMovement;

    private void Awake() {
        animator = GetComponent<Animator>();
    }
    private void Update() {
        animator.SetBool("IsWalking", catMovement.IsWalking());
    }
}
