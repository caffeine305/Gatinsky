using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour {

    public GameObject camera;
    public GameObject scenario;
    public GameObject gatinsky;
    public GameObject window;

    public GameObject enemy;
    public GameObject[] paloma;

    public GameObject hud;
    //public Slider healthSlider;

    //private AudioClip audio;
    //static AudioSource source;

    private int score;
    private int level;
    private int eliminated;
    private float spawnTime;
    private float fixedTime;
    private float velocidad;

    Vector2 enemyPos;
	public Vector2 finalPos;
    
    int maxEnemies;

    void Start()
    {
        level = 2;
        score = 0;
        eliminated = 0;
        velocidad = 0.2f;
        UpdateScore();
        spawnTime = 2f;
        fixedTime = 2.3f;
        maxEnemies = 6+level;   //(int)(30 + (Mathf.Pow(2, level)/3) );

        //audio = Resources.Load<AudioClip>("audio");
        //source = GetComponent<AudioSource>();
        //hud = GetComponent<HUD>();

        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        //Vector3 bannerPos = new Vector3(-1.0f, 0.0f, -3.0f);

        //Crear cámara
        Vector3 cameraPos = new Vector3(-0.0f, 1.0f, -2.0f);
        Instantiate(camera,cameraPos, transform.rotation);

        //Crear escenario
        Vector3 scenarioPos = new Vector3(-12.0f, 0.0f, 0.0f);
        Instantiate(scenario, scenarioPos, transform.rotation);

        //Crear Jugador
        Vector2 playerPos = new Vector2(-7.0f, -3.25f);
        Instantiate(gatinsky, playerPos, transform.rotation);

        //crear Ventanas
        Vector2 winPos = new Vector2(-9.0f, 1.4f);
        Vector2 offsetPos = new Vector2(4.0f, 0.0f);

        Instantiate(window, winPos, transform.rotation);
        Instantiate(window, winPos + offsetPos, transform.rotation);
        Instantiate(window, winPos + offsetPos * 2, transform.rotation);
        Instantiate(window, winPos + offsetPos * 3, transform.rotation);
        Instantiate(window, winPos + offsetPos * 4, transform.rotation);

        //crear Enemigos
        while (true) //Mientras el jugador tenga vidas
        {
            //while(enemigos > 0)

            SetRandomPosition();
            SetTargetPosition();
            Vector2 offsetY = new Vector2(0.0f, 7.75f);
            Instantiate(enemy, enemyPos, transform.rotation);
            yield return new WaitForSeconds(2.0f);

            int index = Random.Range(0, paloma.Length);
            Instantiate(paloma[index], SimplePos(), transform.rotation);
            yield return new WaitForSeconds(2.0f);

            //countPoints();
            //loadNextStage();
        }

        //if(vidas == 0)
        //gameOver();
        //titleScreen();

    }

    Vector2 SimplePos()
    {
        //Usar este vector si se arranca con el código.
        //Vector2 posicion = new Vector2(-8.8f,6.2f);
        //Usar est evector y permitir que el Spline determine el punto donde nace la paloma
        Vector2 posicion = new Vector2(0f, 9f);
        return posicion;
    }

    public void SumarScore(int sumarValorScore)
    {
        score += sumarValorScore;
        UpdateScore();
    }
    
    void UpdateScore()
    {
        hud.GetComponentInChildren<TextMesh>().text = "Score:" + score;
    }
    
    public void UpdateEliminados(int sumarNumEliminados)
    {
        eliminated += sumarNumEliminados;
    }

    public void UpdateSpeed(float sumarVelocidad)
    {
        velocidad += sumarVelocidad * 0.02f;
        Debug.Log(velocidad);

        float testVel = velocidad * 100;
        testVel = testVel % 20;
       if (testVel == 1)
        {
            spawnTime = spawnTime - 0.5f;
        }

     }

    public void SetRandomPosition()
    {
        float x = Random.Range(-10.0f, 8.0f);

        if (x < -5.0f)
            x = -9.0f;

        if (x >= -5.0f && x < -1.0f)
            x = -5.0f;

        if (x >= -1.0f && x < 3.0f)
            x = -1.0f;

        if (x >= 3.0f && x < 7.0f)
            x = 3.0f;

        if (x > 7.0f)
            x = 7.0f;


        float y = -3.25f;

        enemyPos = new Vector2(x, y);
        transform.position = enemyPos;
    }
		
	float ChooseARandomWindow()
		{
			int chooseRandomWindow;
			float aux;
			chooseRandomWindow = Random.Range(1, 6);
			Debug.Log ("Random Window is" + chooseRandomWindow);

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

	public void SetTargetPosition()
	{
		finalPos.y = 1.4f;
		finalPos.x = ChooseARandomWindow ();
	}

    void SetPalomaPosition()
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
            }

        float x = aux;
        float y = 6.4f;

        enemyPos = new Vector2(x, y);
        transform.position = enemyPos;
    }
    /*
      
    public void Audio()
    {
        source.Play();
    }
    public void UpdateHealthBar(int health)
    {
        healthSlider.value = health;
    }

    public bool GameOver()
    {
        bool isGameOver;

        if (healthSlider.value <= 0)
        {
            isGameOver = true;
        }
        else {
            isGameOver = false;
        }

        return isGameOver;
    }
   */

}