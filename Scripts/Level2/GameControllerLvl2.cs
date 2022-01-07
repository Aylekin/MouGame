using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerLvl2 : MonoBehaviour
{
    public static GameControllerLvl2 instance = null;
    [SerializeField]
    GameObject restartBtn;
    [SerializeField]
    GameObject menuBtn;
    [SerializeField]
    public AudioSource zrodloDzwieku;
    [SerializeField]
    public AudioClip soundDandelion;
    [SerializeField]
    public AudioClip soundBubble;
    [SerializeField]
    public AudioClip soundToxin;
    [SerializeField]
    public AudioClip soundSnail;

    [SerializeField]
    Text highScoreTxt;
    [SerializeField]
    Text yourScoreTxt;
    [SerializeField]
    Image Mou1;
    [SerializeField]
    Image Mou2;
    [SerializeField]
    Image Mou3;
    [SerializeField]
    GameObject[] bubbles;
    [SerializeField]
    GameObject dandelion;
    [SerializeField]
    GameObject snail;
    [SerializeField]
    GameObject superbubble;

    // Punkt z którego pojawiają się przeciwnicy
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    Transform dandelionspawnPoint;      // Punkt, w którym pojawia się Dmuchawiec

    // Szybkość ich pojawiania
    [SerializeField]
    float spawnRate = 2f;
    float nextSpawn;

    //Przyspieszanie
    [SerializeField]
    public float speed;
    int highScore = 0;
    public int yourScore = 0;
    public static bool gameStop;
    float nextScoreInc = 0f;
    bool dandelionGrabbed = false;
    public bool superGrabbed = false;
    public bool snailGrabbed = false;
    //public string dandelionName;

    //Losowy obszar bąbelków
    [SerializeField]
    public float xMin;
    [SerializeField]
    public float xMax;

    public float Lives = 3;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        restartBtn.SetActive(false);
        menuBtn.SetActive(false);
        yourScore = 0;
        gameStop = false;
        speed = Time.timeScale=1.5f;
        highScore = PlayerPrefs.GetInt("highScorelvl2");
        nextSpawn = Time.time + spawnRate;
    }

    void Update()
    {
        if (yourScore == 7 && !PlayerPrefs.HasKey("dandelionLvlName2") && dandelionGrabbed == false)   // Pojawianie się Dmuchawca
        {
            ShowDandelion();
            dandelionGrabbed = true;
        }

        if (yourScore>0 && yourScore % 10 == 0 && superGrabbed==false)  //Pojawienie się super bańki
        {
            ShowSuperBubble();
            superGrabbed = true;
        }

        if ((yourScore==15|| yourScore == 30 || yourScore == 45 || yourScore == 60) && snailGrabbed==false)  //Pojawienie się ślimaka
        {
            ShowSnail();
            snailGrabbed = true;
        }
        //gameStop to funkcja która zatrzymuje gre gdy umrzemy
        if (!gameStop)
        {
            highScoreTxt.text = highScore.ToString();
            yourScoreTxt.text = "" + yourScore;
            if (Time.time > nextSpawn)
            {
                SpawnEnemies();
            }
   
        }
        if(Lives==0)
        {
            Destroy(Mou3);
            MouDead();
        }
        else if(Lives==2)
        {
            Destroy(Mou1);
        }
        else if(Lives==1)
        {
            Destroy(Mou2);
        }
    }

    public void MouDead()
    {
        if (yourScore > highScore)
        {
            PlayerPrefs.SetInt("highScorelvl2", yourScore);
        }
        speed = 0;
        gameStop = true;
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
    }

    void SpawnEnemies()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax),spawnPoint.position.y);   // losujemy obszar od x min do x max w którym będą pojawiać się bąbelki
        if (speed >= 1.5f && speed<=2.5f) 
        {
            spawnRate = Random.Range(3.5f, 4.0f);
        }
        else if(speed>2.5f && speed<=5.0f)
        {
            spawnRate = Random.Range(2.5f, 3.0f);
        }
        else if(speed>5.0f)
        {
            spawnRate = Random.Range(1.5f, 2.0f);
        }
        nextSpawn = Time.time + spawnRate;
        int randomEnemies = Random.Range(0, bubbles.Length);
        Instantiate(bubbles[randomEnemies],pos, Quaternion.identity);
    }

    void ShowDandelion()    //pojawia się dmuchawiec
    {
        Instantiate(dandelion, dandelionspawnPoint.position, Quaternion.identity);
    }

    void ShowSnail()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), spawnPoint.position.y);
        Instantiate(snail, pos, Quaternion.identity);
    }
    
    void ShowSuperBubble()
    {
        Vector2 pos = new Vector2(Random.Range(xMin, xMax), spawnPoint.position.y);
        Instantiate(superbubble, pos, Quaternion.identity);
    }

    //przyspieszenie poruszania się z czasem 
    public void SpeedUp()
    {     
        // next ifs
        if (speed < 5.0f)
        {
            speed += 0.2f;
        }
        else if (speed<= 12.0f)
        {
           speed += 0.008f;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GoToMenu()
    {                                         
        SceneManager.LoadScene("GameMenu");   
    }
}
