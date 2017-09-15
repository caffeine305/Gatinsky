using UnityEngine;
using System.Collections;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
    private bool closes;
    private Animator animator;
<<<<<<< HEAD
    private Collider2D collider;
    Vector2 openOffset = new Vector2 (-0.1651628f, 0.0240237f);
    Vector2 closedOffset = new Vector2 (0.12f, 0.0240237f);

=======
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
<<<<<<< HEAD
        collider = GetComponentInChildren<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("closes");
        collider.offset = closedOffset;
=======
    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
            animator.SetTrigger("closes");
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
    }
}
