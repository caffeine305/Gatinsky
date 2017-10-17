using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Destroy : MonoBehaviour {

    public float vel;
    public double valorScore;
    public int eliminado;

    void Awake()
    {
        valorScore = 100;
        eliminado = 0;
        vel = 10.0f;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name == "Gatinsky")
        {
            this.gameObject.SetActive(false);

            //loadWave.sound();
            //loadWave.SumarScore(valorScore);
            //loadWave.UpdateEliminados(eliminado);
            //loadWave.UpdateSpeed(vel);
            Destroy(this.transform.root.gameObject, 2.0f);
        }
    }

}
