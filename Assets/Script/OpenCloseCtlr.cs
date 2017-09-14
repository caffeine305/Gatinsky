using UnityEngine;
using System.Collections;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
    private bool closes;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
            animator.SetTrigger("closes");
    }
}
