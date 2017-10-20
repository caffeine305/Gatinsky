using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public int attackDamage;

    GameObject window;
    public bool windowTouched;

	void Awake ()
    { 
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

    
}
