using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 2;

<<<<<<< HEAD
    GameObject window;
    HealthManager healthManager;
    bool windowTouched;
=======
    GameObject player;
    HealthManager healthManager;
    bool playerTouched;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
    

	void Awake ()
    {
<<<<<<< HEAD
        window = GameObject.FindGameObjectWithTag("Window");

        GameObject LoadHealthManager = GameObject.FindWithTag("Window");
        if (LoadHealthManager != null)
        {
            healthManager = window.GetComponent<HealthManager>();
=======
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject LoadHealthManager = GameObject.FindWithTag("Player");
        if (LoadHealthManager != null)
        {
            healthManager = player.GetComponent<HealthManager>();
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
        }

        if (LoadHealthManager == null)
        {
            Debug.Log("No se puede encontrar el Script 'HealthManager' ");
        }
        
<<<<<<< HEAD
=======
        //healthManager = player.GetComponent<HealthManager>(); //Esta línea fue sustituida por el script de arriba

        //análogo a la línea de arriba para enemyHealth llamando instancia del Manager
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
	}

    void OnCollisionEnter2D(Collision2D other)
    {
<<<<<<< HEAD
        if(other.gameObject.name == "Window")
        {
            //healthManager.TakeDamage(attackDamage);
            windowTouched = true;
=======
        if(other.gameObject.tag == "Player")
        {
            //healthManager.TakeDamage(attackDamage);
            playerTouched = true;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
<<<<<<< HEAD
        if (other.gameObject.name == "Window")
        {
            windowTouched = false;
=======
        if (other.gameObject.tag == "Player")
        {
            playerTouched = false;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
        }
    }

    
    void Update()
    {
<<<<<<< HEAD
        if(windowTouched)
=======
        if(playerTouched)
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
        {
            Attack();
        }
    }
    

    void Attack()
    {
        // If the player has health to lose...
        if (healthManager.actualHP > 0)
        {
            // ... damage the player.
            healthManager.TakeDamage(attackDamage);
            Debug.Log("Attacking!");
        }   
    }
    
}
