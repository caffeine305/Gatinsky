using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public int enemVel;
    public int enemType; //0: terrestre, 1: Volador.

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
            finalPos.x = ChooseARandomWindow();
            transform.position = Vector3.MoveTowards(initialPos , finalPos, step);

        }

    }

    float ChooseARandomWindow()
    {
        int chooseRandomWindow;
        float aux;
        chooseRandomWindow = Random.Range(1, 5);

        switch (chooseRandomWindow)
        {
            case 1:
                aux = -9.0f;
                break;

            case 2:
                aux = -5.0f;
                break;

            case 3:
                aux = -1.0f;
                break;

            case 4:
                aux = 3.0f;
                break;

            case 5:
                aux = 7.0f;
                break;

            default:
                aux = -1.0f;
                break;
        }return aux;
    }

    void FixedUpdate ()
    {
        moveAcord();
    }

}
