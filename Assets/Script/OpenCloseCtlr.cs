using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
    private bool closes;
    public bool isOpen;

    int maxHP = 100;
    public int actualHP;
    public bool isDanger; //Banderas. Permiten al programa conocer detalles sobre la ventana y así producir una acción a tono
    public bool isTouched;

    public Animator animator; //Declarar Animator para tener acceo a el
    public Collider2D collider; //Declarar Collider para poder modificarlo también
    public GameObject enemy;
    EnemyAttack enemyAttack;

    Vector2 openOffset = new Vector2(-0.1651628f, 0.0240237f); //Posición Collider Ventana Abierta
    Vector2 closedOffset = new Vector2(0.12f, 0.0240237f); //Posición Collider Ventana Cerrada

    void Start()
    {
        //Inicializar Animator y Collider al arrancar el programa
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        if (!enemyAttack)
            enemyAttack = enemy.GetComponentInChildren<EnemyAttack>();
        else
            Debug.Log("No se encuentra el script 'EnemyAttack' Por favor agréguelo");



        //Inicializar variables y banderas.
        this.actualHP = maxHP;
        this.isDanger = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.name == "Gatinsky_Big")&&(this.isOpen))
        {
            closeFunction();
            isTouched = true;
        }

        if (other.gameObject.name == "Invader")
        {
            if((this.isDanger)&&(!this.isOpen))
            openFunction();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Gatinsky_Big")
        {
            isTouched = false;
        }

    }

    void openFunction()
    {
        this.isOpen = true; // Bandera: Ventana Abierta
        this.animator.SetTrigger("opens"); //Manda a llamar animación de ventana abierta
        this.collider.offset = openOffset; //Mueve el collider de acuerdo a la posición "física" de la    
    }

    void closeFunction()
    {
        this.isOpen = false;
        this.actualHP = this.maxHP;

        this.animator.SetTrigger("closes"); //Manda a llamar animación de ventana cerrada
        this.collider.offset = closedOffset; //Mueve el collider de acuerdo a la posición "física" de la ventana.
        this.isDanger = false;
    }

    public void TakeDamage(int amount)
    {
        //Restar energía una cantidad dictada por amount
        this.actualHP -= amount;
        Debug.Log(actualHP);

        //reducir el tamaño de la barra de energía
        //UpdateHealthBar(actualHP);

        //Si la energía llega a cero, abrir la ventana
        if (this.actualHP <= 0)
        {
            this.Danger();
        }
    }

    void Danger()
    {
        //Levantar indicador de ventana abierta que permita generar comportamiento apropiado.
        Debug.Log("is Danger!");
        this.isDanger = true;
    }

    void FixedUpdate()
    {
        if ((enemyAttack.windowTouched)&&(this.actualHP>0))
            TakeDamage(enemyAttack.attackDamage);

        if (isDanger)
            openFunction();

        if (isTouched)
            closeFunction();

    }

}
