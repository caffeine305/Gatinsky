using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float vel;
    public double valorScore;
    public int eliminado;
    public bool onPosition;

    void Awake()
    {
        valorScore = 100;
        eliminado = 0;
        vel = 10.0f;
        onPosition = false;
    }

    private void FixedUpdate()
    {
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
            //loadWave.SumarScore(valorScore);
            //loadWave.UpdateEliminados(eliminado);
            //loadWave.UpdateSpeed(vel);
            Destroy(this.transform.root.gameObject, 1.0f);
        }
    }


}
