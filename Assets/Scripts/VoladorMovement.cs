using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoladorMovement : MonoBehaviour {

    public int enemVel;
    //public int enemType; //0: terrestre, 1: Volador.

	void Start ()
    {
        enemVel = 7;

		/*
		GameObject LoadMainScript = GameObject.FindWithTag ("GameController");
		if (LoadMainScript != null)
			mainScript = LoadMainScript.GetComponent<Main> ();
		
		if(LoadMainScript == null)
			Debug.Log ("No fue posible cargar el Script 'Main' ");
		//StartCoroutine(MoveEnemies ());
		*/
    }

    void moveAlong()
    {
            float move = enemVel * Time.deltaTime;

            Vector2 initialPos = transform.position;
            Vector2 finalPos = new Vector2(0.0f, 1.4f);
            initialPos.y = 0.0f;
        
        if ((initialPos.x > -8.0f) && (initialPos.x < 0.0f) )
        {
            initialPos.x = initialPos.x + 4.0f;
        }

        if ((initialPos.x > 0.0f) && (initialPos.x < 7.0f))
        {
            initialPos.x = initialPos.x - 4.0f;
        }

        Vector2 targetPos = initialPos + finalPos;

            //transform.position = Vector3.MoveTowards(transform.position, targetPos, move);			
		transform.position = initialPos + new Vector2(move,Mathf.Sin(move));
    }

	void FixedUpdate()
    {
		moveAlong();
		//yield return new WaitForSeconds (0.2f);
    }
    

}
