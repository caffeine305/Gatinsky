using UnityEngine;
using System.Collections;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
    private bool closes;
    private Animator animator;
    private Collider2D collider;
    Vector2 openOffset = new Vector2 (-0.1651628f, 0.0240237f);
    Vector2 closedOffset = new Vector2 (0.12f, 0.0240237f);


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetTrigger("closes");
        collider.offset = closedOffset;
    }
}
