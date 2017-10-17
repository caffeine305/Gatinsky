using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int enemVel;
	// Use this for initialization
	void Start () {
        enemVel = 7;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            enemVel = enemVel * (-1);
        }
    }
            // Update is called once per frame
            void FixedUpdate () {

            transform.Translate(Vector2.right * enemVel * Time.deltaTime);


        }
}
