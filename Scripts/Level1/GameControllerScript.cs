using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instance = null;
    [SerializeField]
    GameObject restartBtn;
    [SerializeField]
    GameObject menuBtn;

    [SerializeField]
    Text highScoreTxt;
    [SerializeField]
    Text yourScoreTxt;

    [SerializeField]
    GameObject[] enemies;
    [SerializeField]
    GameObject dandelion;

    // Punkt z którego pojawiają się przeciwnicy
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Transform checkLevelPoint;      // Punkt, w którym pojawia się Dmuchawiec

    // Szybkość ich pojawiania
    [SerializeField]
    float spawnRate = 2f;
    float nextSpawn;

    //Przyspieszanie
    [SerializeField]
    float timeToSpeed = 5;
    float nextSpeed;

    int highScore = 0, yourScore = 0;
    public static bool gameStop;
    float nextScoreInc = 0f;
    bool dandelionGrabbed = false;

    void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if( instance!=this)
        {
            Destroy(gameObject);
        }

        restartBtn.SetActive(false);
        menuBtn.SetActive(false);
        yourScore = 0;
        gameStop = false;
        Time.timeScale = 1f;
        highScore = PlayerPrefs.GetInt("highScorelvl1");
        nextSpawn = Time.time + spawnRate;
        nextSpeed = Time.unscaledTime + timeToSpeed;
    }

    void Update()
    {
        if (yourScore==12 && !PlayerPrefs.HasKey("dandelionLvlName1") && dandelionGrabbed==false)   // Pojawianie się Dmuchawca
        {
            ShowDandelion();
            dandelionGrabbed = true;
        }

        //gameStop to funkcja która zatrzymuje gre gdy umrzemy
        if(!gameStop)
        {
            IncreaseScore();

            highScoreTxt.text = highScore.ToString();
            yourScoreTxt.text = "" + yourScore;

            if (Time.time>nextSpawn)
            {
                SpawnEnemies();
            }
            if(Time.unscaledTime> nextSpeed && !gameStop)
            {
                SpeedUp();
            }
        }
    }

    public void MouHit()
    {
        if(yourScore>highScore)
        {
            PlayerPrefs.SetInt("highScorelvl1", yourScore);
        }
        Time.timeScale = 0;
        gameStop = true;
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
    }

    void SpawnEnemies()
    {
        
        if (Time.timeScale >= 5.0f) //gdy plansza osiągnie max szybkość, zaczyna zmieniać się szybkość pojawiania się przeciwników
        {
            spawnRate = Random.Range(1.8f, 2.2f);
        }
        nextSpawn = Time.time + spawnRate;
        int randomEnemies = Random.Range(0, enemies.Length);
        Instantiate(enemies[randomEnemies], spawnPoint.position, Quaternion.identity);
    }

    void ShowDandelion()    //pojawia się dmuchawiec
    {
        Instantiate(dandelion, checkLevelPoint.position, Quaternion.identity);
    }

    //przyspieszenie poruszania się z czasem 
    void SpeedUp()
    {
        nextSpeed = Time.unscaledTime + timeToSpeed;
        if(Time.timeScale<5.0f){
            Time.timeScale += 0.15f;
        } 
    }

    //doliczanie punktów
    void IncreaseScore()
    {
        if(Time.unscaledTime > nextScoreInc)
        {
            yourScore += 1;
            nextScoreInc = Time.unscaledTime + 1;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
