using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class OpenCloseCtlr : MonoBehaviour {

    private bool opens;
    private bool closes;
    public bool isOpen;

    private int maxHP = 1000;
    public int actualHP;
    float healthBarPercnt;
    public GameObject healthBar;

    public bool isDanger; //Banderas. Permiten al programa conocer detalles sobre la ventana y así producir una acción a tono
    public bool isTouched;
    public bool isTouchedByEnemy;

    public Animator animator; //Declarar Animator para tener acceo a el
    public Collider2D collider; //Declarar Collider para poder modificarlo también
    //Elimine que se busque el enemyAttack al iniciar el juego, debido a que no es necesario y se arregla en el fixedupdate con la lista
    public List<GameObject> enemys; //Lista de enemigos que tocan la ventana

    Vector2 openOffset = new Vector2(-0.1651628f, 0.0240237f); //Posición Collider Ventana Abierta
    Vector2 closedOffset = new Vector2(0.12f, 0.0240237f); //Posición Collider Ventana Cerrada

    void Start()
    {
        //Inicializar Animator y Collider al arrancar el programa
        animator = GetComponentInChildren<Animator>();
        collider = GetComponentInChildren<Collider2D>();
        healthBar = GameObject.FindWithTag("HealthBar");

        //Inicializar variables y banderas.
        this.actualHP = maxHP;
        healthBarPercnt = this.actualHP / maxHP;
        this.isDanger = false;
        closeFunction();
        //Inicializando la lista de enemigos que tocan la ventana;
        enemys = new List<GameObject> ();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Gatinsky")
        {
            isTouched = true;
        }

        if (other.gameObject.tag == "Enemy")
        {
            isTouchedByEnemy = true;
            enemys.Add(other.gameObject); //Agregamos el nuevo enemigo a la lista

            //if ((this.isDanger)&&(!this.isOpen))
            //openFunction();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Gatinsky")
        {
            isTouched = false;
        }
		if (other.gameObject.tag == "Enemy") {
			enemys.Remove(other.gameObject); // Eliminamos el enemigo que sale de la lista
            isTouchedByEnemy = false;
        }
    }

    void openFunction()
    {
        this.isOpen = true; // Bandera: Ventana Abierta
        
        //Manda a llamar animación de ventana abierta
        this.animator.SetBool("opens",true);
        this.animator.SetBool("closes", false);
        this.collider.offset = openOffset; //Mueve el collider de acuerdo a la posición "física" de la    
    }

    void closeFunction()
    {
        this.isOpen = false;
        this.actualHP = this.maxHP;

        //Manda a llamar animación de ventana cerrada
        this.animator.SetBool("opens", false);
        this.animator.SetBool("closes", true);
        this.collider.offset = closedOffset; //Mueve el collider de acuerdo a la posición "física" de la ventana.
        this.isDanger = false;
    }

    public void TakeDamage(int amount)
    {
        //Restar energía una cantidad dictada por amount
        if ((isTouchedByEnemy)&&(!isOpen))
        {
            this.actualHP -= amount;

            if (this.actualHP < 0)
                this.actualHP = 0;

            //reducir el tamaño de la barra de energía
            healthBarPercnt = this.actualHP / maxHP;
            //Debug.Log(actualHP);
        }

        Debug.Log(healthBarPercnt);

        SetHealthBarSize(healthBarPercnt);
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

    void SetHealthBarSize(float percentage)
    {
        healthBar.transform.localScale = new Vector3(percentage * healthBar.transform.localScale.x, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    void FixedUpdate()
    {
    	//Si la lista no esta vacia, revisamos y hacemos el daño de cada enemigo
		if (enemys.Count != 0) {
			for (int i = 0; i < enemys.Count; i++) {
				if (this.actualHP>0)
            	TakeDamage(enemys[i].GetComponent<EnemyAttack>().attackDamage);
			}
		}

        if (isDanger)
            openFunction();

        if ((isTouched)&&(isOpen))
            closeFunction();

    }

}
