using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {

	//Declarar energía máxima, energía actual,
	//Barra de energía y Script que controla el estado de la ventana
    public int maxHP = 100;
    public int actualHP;
	Vector2 openOffset = new Vector2 (-0.1651628f, 0.0240237f); //Posición Collider Ventana Abierta
    public bool isDanger; //Banderas. Permiten al programa conocer detalles sobre la ventana y así producir una acción a tono
    
    bool damaged;

    void Awake()
    {
		//Inicializar variables y objetos.
        this.actualHP = maxHP;
        this.isDanger = false;
    }
      

    public void TakeDamage(int amount)
    {
        //Poner bandera de Damage para activar comportamiento de daño.
        damaged = true;

        //Restar energía una cantidad dictada por amount
        this.actualHP -= amount;
        Debug.Log(actualHP);

        //reducir el tamaño de la barra de energía
        //UpdateHealthBar(actualHP);

        //Si la energía llega a cero, abrir la ventana
		if (this.actualHP <= 0)
        {
            Danger();
        }
    }
    
    void Danger()
    {
        //Levantar indicador de ventana abierta que permita generar comportamiento apropiado.
        Debug.Log("is Danger!");
        this.isDanger = true;
        }
}
