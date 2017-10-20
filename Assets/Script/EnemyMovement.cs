using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int enemVel;

	void Start ()
    {
        enemVel = 7;
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            enemVel = enemVel * (-1);
        }
    }

    void FixedUpdate ()
    {
        transform.Translate(Vector2.right * enemVel * Time.deltaTime);
    }

}
