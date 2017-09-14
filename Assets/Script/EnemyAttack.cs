using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 2;

    GameObject player;
    HealthManager healthManager;
    bool playerTouched;
    

	void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        GameObject LoadHealthManager = GameObject.FindWithTag("Player");
        if (LoadHealthManager != null)
        {
            healthManager = player.GetComponent<HealthManager>();
        }

        if (LoadHealthManager == null)
        {
            Debug.Log("No se puede encontrar el Script 'HealthManager' ");
        }
        
        //healthManager = player.GetComponent<HealthManager>(); //Esta línea fue sustituida por el script de arriba

        //análogo a la línea de arriba para enemyHealth llamando instancia del Manager
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            //healthManager.TakeDamage(attackDamage);
            playerTouched = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerTouched = false;
        }
    }

    
    void Update()
    {
        if(playerTouched)
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
