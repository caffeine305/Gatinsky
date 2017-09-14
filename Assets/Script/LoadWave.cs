using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class LoadWave : MonoBehaviour {

    //public GameObject Zombi2;
    public GameObject roundBanner;
    public GameObject gameOverBanner;
    public GameObject endLevelBanner;
    public GameObject Tower;
    public GameObject Zombi;
    public GameObject scoreText;
    public Slider healthSlider;

    private AudioClip pedo;
    static AudioSource culo;

    public float velocidad;
    public float spawnTime;
    public float fixedTime;
    public bool isDead;

    private int score;
    private int level;
    private int eliminated;
    
    Vector3 zombiPos;

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

        pedo = Resources.Load<AudioClip>("pedo");
        culo = GetComponent<AudioSource>();

        StartCoroutine(RePositionWithDelay());
    }

    IEnumerator RePositionWithDelay()
    {
        //Crear letrero de inicio de Round


        Vector3 bannerPos = new Vector3(-1.0f, 0.0f, -3.0f);

        //Crear Torre
        Instantiate(Tower, Vector3.zero, transform.rotation);

        //crear zombis. En esta parte también deben ir Items y la madre seca.
        while (healthSlider.value > 0)  // Este While vuelve al juego en modo endless hasta que te coman.
        {
                SetRandomPosition();
                Instantiate(Zombi, transform.position, transform.rotation);

                yield return new WaitForSeconds(spawnTime * Random.Range(0.0f, 0.7f));
                Debug.Log(eliminated);

        }


            Instantiate(gameOverBanner, bannerPos, transform.rotation);
            yield return new WaitForSeconds(fixedTime); // Se debe cambiar por un WaitUntil(GetComponent<TecladoException>);
        SceneManager.LoadScene("Title");

        //Llamar a jefe del nivel.

        //Cuentas de final del round

    }

    public void Pedo()
    {
        culo.Play();
    }

    public void SumarScore(int sumarValorScore)
    {
        score += sumarValorScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.GetComponent<TextMesh>().text = "Score:" + score;
    }

    public void UpdateEliminados(int sumarNumEliminados)
    {
        eliminated += sumarNumEliminados;
    }

    public void UpdateHealthBar(int health)
    {
        healthSlider.value = health;
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

    public bool Death()
    {
        if (healthSlider.value <= 0)
        {
            isDead = true;
        }
        else {
            isDead = false;
        }

        return isDead;
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
   
}