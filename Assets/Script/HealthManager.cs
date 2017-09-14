using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int maxHP = 100;
    public int actualHP;
    public Slider healthSlider;
    

    public bool isDead;
    bool damaged;

    void Awake()
    {
        actualHP = maxHP;
        isDead = false;

        healthSlider = GameObject.FindWithTag("HUDCanvas").GetComponent<Slider>();
        healthSlider.value = actualHP;
    }

    /*
	void Update () {
            if (damaged) // set flash colour
            else //clear transition colour

    damaged = flase;
    }
    */
      

    public void TakeDamage(int amount)
    {
        //Poner bandera de Damage para activar comportamiento de daño.
        damaged = true;

        //Restar energía una cantidad dictada por amount
        actualHP -= amount;
        Debug.Log(actualHP);

        //reducir el tamaño de la barra de energía
        UpdateHealthBar(actualHP);

        //Si la energía llega a cero, Destruir personaje
        if (actualHP <= 0 && !isDead)
        {
            Death();
        }
        else { }

    }

    public void UpdateHealthBar(int health)
    {
        healthSlider.value = health;
    }


    public void Death()
    {
        //Levantar indicador de muerte que permita generar comportamiento apropiado.
        isDead = true;

        Destroy(this.gameObject);

        }
}
