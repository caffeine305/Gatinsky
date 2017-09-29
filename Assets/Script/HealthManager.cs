using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthManager : MonoBehaviour {

	//Declarar energía máxima, energía actual,
	//Barra de energía y Script que controla el estado de la ventana
    public int maxHP = 100;
    public int actualHP;
    GameObject health; 
	GameObject window;
	public Slider winHealthSlider;
	OpenCloseCtlr openClose;
	Vector2 openOffset = new Vector2 (-0.1651628f, 0.0240237f); //Posición Collider Ventana Abierta
    public bool isDanger; //Banderas. Permiten al programa conocer detalles sobre la ventana y así producir una acción a tono
    
    bool damaged;

    void Awake()
    {
		//Inicializar variables y objetos.
        actualHP = maxHP;
        isDanger = false;
		health = GameObject.FindGameObjectWithTag("HealthBar");

		GameObject loadHealthSlider = GameObject.FindWithTag("HealthBar");
		if (loadHealthSlider)
		{
			winHealthSlider = health.GetComponent<Slider>();
		}

		window = GameObject.FindGameObjectWithTag("Window");

		GameObject LoadOpenCloseCtlr = GameObject.FindWithTag("Window");
		if (LoadOpenCloseCtlr) {
			openClose = window.GetComponent<OpenCloseCtlr> ();
		} else {
			Debug.Log ("No fue posible cargar el Slider 'HealthSlider' ");
		}
    }
      

    public void TakeDamage(int amount)
    {
        //Poner bandera de Damage para activar comportamiento de daño.
        damaged = true;

        //Restar energía una cantidad dictada por amount
        actualHP -= amount;
        Debug.Log(actualHP);

        //reducir el tamaño de la barra de energía
        UpdateHealthBar(actualHP);


        //Si la energía llega a cero, abrir la ventana
		if (actualHP <= 0 && !openClose.isOpen)
        {
            Danger();
        }
    }

    public void UpdateHealthBar(int health)
    {
        winHealthSlider.value = health;
    }


    void Danger()
    {
        //Levantar indicador de ventana abierta que permita generar comportamiento apropiado.
        Debug.Log("is Danger!");
        isDanger = true;
        }
}
