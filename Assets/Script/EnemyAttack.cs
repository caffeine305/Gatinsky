using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 2;

    GameObject window;
    HealthManager healthManager;
    public bool windowTouched;

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

        windowTouched = false;
        
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name == "Window(Clone)")
        {
            //healthManager.TakeDamage(attackDamage);
            windowTouched = true;
			Debug.Log (windowTouched);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Window(Clone)")
        {
            //healthManager.TakeDamage(attackDamage);
            windowTouched = false;
            Debug.Log(windowTouched);
        }
    }

    void Attack()
	{
        // If the player has health to lose...
        if ((this.healthManager.actualHP > 0)&&(windowTouched))
        {
            // ... damage the player.
            healthManager.TakeDamage(attackDamage);
            Debug.Log("Attacking!");
        }
        else {
            //Open the window
            window.GetComponent<OpenCloseCtlr>().isOpen = true;
        }   

	}

    void Update()
    {
        Attack();
    }
    


    
}
