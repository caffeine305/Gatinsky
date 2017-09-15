using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 2;

    GameObject window;
    HealthManager healthManager;
    bool windowTouched;
    

	void Awake ()
    {
        window = GameObject.FindGameObjectWithTag("Window");

        GameObject LoadHealthManager = GameObject.FindWithTag("Window");
        if (LoadHealthManager != null)
        {
            healthManager = window.GetComponent<HealthManager>();
        }

        if (LoadHealthManager == null)
        {
            Debug.Log("No se puede encontrar el Script 'HealthManager' ");
        }
        
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "Window")
        {
            //healthManager.TakeDamage(attackDamage);
            windowTouched = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.name == "Window")
        {
            windowTouched = false;
        }
    }

    
    void Update()
    {
        if(windowTouched)
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
