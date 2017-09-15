using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {

    public int maxHP = 100;
    public int actualHP;
<<<<<<< HEAD
    public Slider wHealthSlider;
=======
    public Slider healthSlider;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
    

    public bool isDead;
    bool damaged;

    void Awake()
    {
        actualHP = maxHP;
        isDead = false;

<<<<<<< HEAD
        wHealthSlider = GameObject.FindWithTag("HUDCanvas").GetComponent<Slider>();
        wHealthSlider.value = actualHP;
=======
        healthSlider = GameObject.FindWithTag("HUDCanvas").GetComponent<Slider>();
        healthSlider.value = actualHP;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
    }

    /*
	void Update () {
            if (damaged) // set flash colour
            else //clear transition colour

<<<<<<< HEAD
                damaged = flase;
=======
    damaged = flase;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
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
<<<<<<< HEAD
        wHealthSlider.value = health;
=======
        healthSlider.value = health;
>>>>>>> eb06bc6935f3fc5d49a78c8078615a865490b61c
    }


    public void Death()
    {
        //Levantar indicador de muerte que permita generar comportamiento apropiado.
        isDead = true;

        Destroy(this.gameObject);

        }
}
