using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int enemVel;
    //public int enemType; //0: terrestre, 1: Volador.


	Vector2 wPos1;
	Vector2 wPos2;
	Vector2 wPos3;


	void Start ()
    {
        //enemVel = 7;

		/*
		GameObject LoadMainScript = GameObject.FindWithTag ("GameController");
		if (LoadMainScript != null)
			mainScript = LoadMainScript.GetComponent<Main> ();
		
		if(LoadMainScript == null)
			Debug.Log ("No fue posible cargar el Script 'Main' ");
		//StartCoroutine(MoveEnemies ());
		*/
    }
				    
	void AknowledgeWindowPositons()
	{
		float height = 1.25f;
		wPos1 = new Vector2 (-4f, height);
		wPos2 = new Vector2 (0f, height);
		wPos3 = new Vector2 (4f, height);
	}

	Vector2 CalcuateNearest()
	{
		Vector2 initialPosition = transform.position;
		Vector2 finalPos = new Vector2(0f,0f);
		Vector2 eval1 = wPos1 - initialPosition;
		Vector2 eval2 = wPos2 - initialPosition;
		Vector2 eval3 = wPos3 - initialPosition;

		if (eval1.magnitude < eval2.magnitude) {
			if (eval1.magnitude < eval3.magnitude) {
				finalPos = wPos1;
			} else {
				finalPos = wPos3;
			}
		} else 
		{
			if (eval2.magnitude < eval3.magnitude) {
				finalPos = wPos2;
			} else
				finalPos = wPos3;
		}

		return finalPos;
	}

	void moveAlong()
	{
		float move = enemVel * Time.deltaTime;

		Vector2 initialPos = transform.position;
		Vector2 finalPosition = CalcuateNearest ();

		//Vector2 targetPos = initialPos + finalPosition;

		transform.position = Vector3.MoveTowards(transform.position, finalPosition, move);			
	}

	void FixedUpdate()
	{
		AknowledgeWindowPositons ();
		//CalcuateNearest ();
		moveAlong();
		//yield return new WaitForSeconds (0.2f);
	}

}
