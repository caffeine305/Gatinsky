using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage = 2;

    GameObject window;
    //public OpenCloseCtlr openClose;
    public bool windowTouched;

	void Awake ()
    {
     /*   
        window = GameObject.FindGameObjectWithTag("Window");

        GameObject LoadOpenClose = GameObject.FindWithTag("Window");
        if (LoadOpenClose != null)
        {
            openClose = window.GetComponent<OpenCloseCtlr>();
        }

        if (LoadOpenClose == null)
        {
            Debug.Log("No se puede encontrar el Script 'OpenCloseCtlr' ");
        }
     */ 
        windowTouched = false;
        
	}

    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Window")
        {
            this.windowTouched = true;
			Debug.Log (windowTouched);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Window")
        {
            this.windowTouched = false;
            Debug.Log(windowTouched);
        }
    }
    /*
    void Attack()
	{
        // If the player has health to lose...
        if ((this.openClose.actualHP > 0)&&(windowTouched))
        {
            // ... damage the player.
            this.openClose.TakeDamage(attackDamage);
            Debug.Log("Attacking!");
        }

	}
    

    void Update()
    {
        Attack();
    }*/
    


    
}
