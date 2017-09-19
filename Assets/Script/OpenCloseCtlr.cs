using UnityEngine;
using System.Collections;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
	private bool closes;
	public bool isOpen;
    public Animator animator; //Declarar Animator para tener acceo a el
    public Collider2D collider; //Declarar Collider para poder modificarlo también
    Vector2 openOffset = new Vector2 (-0.1651628f, 0.0240237f); //Posición Collider Ventana Abierta
    Vector2 closedOffset = new Vector2 (0.12f, 0.0240237f); //Posición Collider Ventana Cerrada


    private void Awake()
    {
		//Inicializar Animator y Collider al arrancar el programa
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.name == "Gatinsky_Big") {
			animator.SetTrigger ("closes"); //Manda a llamar animación de puerta cerrada
			collider.offset = closedOffset; //Mueve el collider de acuerdo a la posición "física" de la puerta.
			isOpen = false;
		}

		if (other.gameObject.name == "Invader") {
			animator.SetTrigger ("opens"); //Manda a llamar animación de puerta cerrada
			collider.offset = openOffset; //Mueve el collider de acuerdo a la posición "física" de la puerta.
			isOpen = true;
		}
	}



}
