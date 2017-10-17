using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour {

    public GameObject camera;
    public GameObject scenario;
    public GameObject gatinsky;
    public GameObject window1;
    public GameObject window2;
    public GameObject window3;
    public GameObject window4;
    public GameObject window5;
    public GameObject winArray;
    public GameObject enemy;

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
        //windows = new GameObject[5];

        //audio = Resources.Load<AudioClip>("audio");
        //source = GetComponent<AudioSource>();
        //hud = GetComponent<HUD>();

        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        //Vector3 bannerPos = new Vector3(-1.0f, 0.0f, -3.0f);

        //Crear cámara
        Vector3 cameraPos = new Vector3(-0.0f, 0.0f, -2.0f);
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
        Vector2 winArrayPos = new Vector2(-2.0f, 1.0f);
        //Instantiate(winArray, winArrayPos, transform.rotation);

        Instantiate(window1, winPos, transform.rotation);
        Instantiate(window2, winPos + offsetPos, transform.rotation);
        Instantiate(window3, winPos + offsetPos * 2, transform.rotation);
        Instantiate(window4, winPos + offsetPos * 3, transform.rotation);
        Instantiate(window5, winPos + offsetPos * 4, transform.rotation);

        //crear Enemigos
        Vector2 enemyPos = new Vector2(-8.38f, 1.0f);
        Vector2 offsetY = new Vector2(0.0f,1.0f);
        Instantiate(enemy, enemyPos, transform.rotation);
        Instantiate(enemy, enemyPos+offsetY, transform.rotation);
        yield return new WaitForSeconds(spawnTime * Random.Range(0.0f, 0.7f));

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
   
    void SetRandomPosition()
    {
        float x = Random.Range(-10.0f, 10.0f);
        float y = Random.Range(-10.0f, 10.0f);
        //Debug.Log("X,Z:" + x.ToString("F2") + " , " + y.ToString("F2"));

        if (x > 0) {
            x = x+2;
        }
        else
        {
            x = x-2;
        }

        if (y > 0)
        {
            y = y + 2;
        }
        else
        {
            y = y - 2;
        }

        zombiPos = new Vector3(x, y, 0.0f);
        transform.position = zombiPos;
    }
    */

}