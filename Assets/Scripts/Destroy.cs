using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float vel;
    public int valorScore;
    public int eliminado;
    public bool onPosition;
    public float positionY;

    private RandomSpawn randomSpawn;

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("Spawner");
        if (gameControllerObject != null)
        {
            randomSpawn = gameControllerObject.GetComponent<RandomSpawn>();
        }
        if (randomSpawn == null)
        {
            Debug.Log("No es posible encontrar el script 'RandomSpawn' ");

        }

        valorScore = 100;
        eliminado = 0;
        vel = 10.0f;
        onPosition = false;
        positionY = transform.position.y;
        this.gameObject.layer = 10;

    }


    public bool CheckPosition()
    {

        if (positionY > 4 || positionY < 5)
        {
            onPosition = true;
            //speed = 0.0f;
        }
        else
            onPosition = false;

        return onPosition;
    }    
    

    private void FixedUpdate()
    {
        //CheckPosition();
        onPosition = true;

        if (onPosition)
        {
            this.gameObject.layer = 8;
        }
        else
        {
            this.gameObject.layer = 10;
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.name == "Gatinsky")&&(onPosition))
        {
            this.gameObject.SetActive(false);

            //loadWave.sound();
            //loadWave.UpdateEliminados(eliminado);
            //loadWave.UpdateSpeed(vel);
            randomSpawn.AddScore(valorScore);
            Destroy(this.transform.root.gameObject, 0.5f);
        }
        if (other.gameObject.name == "Enemy")
        {
            this.gameObject.SetActive(false);

            //loadWave.sound();
            //loadWave.UpdateEliminados(eliminado);
            //loadWave.UpdateSpeed(vel);
            randomSpawn.AddScore(valorScore);
            Destroy(this.transform.root.gameObject, 0.5f);
        }
    } 


}
