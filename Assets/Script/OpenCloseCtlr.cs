using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
    private bool closes;
    public bool isOpen;
    public Animator animator; //Declarar Animator para tener acceo a el
    public Collider2D collider; //Declarar Collider para poder modificarlo también
    public HealthManager healthMan; //Declarar Script para poder accesarlo y saber en que momento se termina la energía de la ventana. 
    Vector2 openOffset = new Vector2(-0.1651628f, 0.0240237f); //Posición Collider Ventana Abierta
    Vector2 closedOffset = new Vector2(0.12f, 0.0240237f); //Posición Collider Ventana Cerrada


    private void Awake()
    {
        //Inicializar Animator y Collider al arrancar el programa
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();
        healthMan = GetComponentInChildren<HealthManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.name == "Gatinsky_Big") && (isOpen)) {
            this.animator.SetTrigger("closes"); //Manda a llamar animación de ventana cerrada
            this.collider.offset = closedOffset; //Mueve el collider de acuerdo a la posición "física" de la puerta.
            this.isOpen = false; //Bandera: Ventana cerrada
            this.healthMan.isDanger = false; //No hay riesgo de que entren bichos
            this.healthMan.actualHP = healthMan.maxHP; //se regenera la energía de la puerta.
        }
        else if ((other.gameObject.name == "Invader") && (!isOpen)) {
            Debug.Log("Inside Valid State");
            if (healthMan.actualHP <= 0)
            {
                this.animator.SetTrigger("opens"); //Manda a llamar animación de ventana cerrada
                this.collider.offset = openOffset; //Mueve el collider de acuerdo a la posición "física" de la puerta.
            }
        }
    }

    private void FixedUpdate()
    {
        if (healthMan.isDanger)
        {
            isOpen = true;
        }     
    }

}
