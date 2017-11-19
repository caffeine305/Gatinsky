using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int enemVel;
    public int enemType; //0: terrestre, 1: Volador.
	private Main mainScript;

	void Start ()
    {
        enemVel = 7;
		GameObject LoadMainScript = GameObject.FindWithTag ("GameController");
		if (LoadMainScript != null)
			mainScript = LoadMainScript.GetComponent<Main> ();
		
		if(LoadMainScript == null)
			Debug.Log ("No fue posible cargar el Script 'Main' ");
		//StartCoroutine(MoveEnemies ());
    }

    void moveAcord()
    {
        if (enemType == 0)
        {
            float step = enemVel * Time.deltaTime;

            Vector2 initialPos = transform.position;
            Vector2 finalPos = new Vector2(0.0f, 1.4f);
            initialPos.y = 0.0f;

            Vector2 targetPos = initialPos + finalPos;

            transform.position = Vector3.MoveTowards(transform.position, targetPos, step);
        }

        if (enemType == 1)
        {
            float step = enemVel * Time.deltaTime;

			Vector2 initialPos = transform.position;
            Vector2 finalPos = new Vector2(0.0f, 1.4f);
            //finalPos.x = ChooseARandomWindow();
			finalPos = mainScript.finalPos;
            transform.position = Vector3.MoveTowards(initialPos , finalPos, step);

        }

    }

	void FixedUpdate()
    {
		moveAcord ();
		//yield return new WaitForSeconds (0.2f);
    }
    

}
