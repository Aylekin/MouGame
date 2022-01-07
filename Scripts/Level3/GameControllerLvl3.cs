using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerLvl3 : MonoBehaviour
{
    public static GameControllerLvl3 instance = null;
    [SerializeField]
    GameObject restartBtn;
    [SerializeField]
    GameObject menuBtn;
    [SerializeField]
    public AudioSource zrodloDzwieku;
    [SerializeField]
    public AudioClip soundBlock;
    [SerializeField]
    public AudioClip soundDandelion;

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
    Transform spawnPoint;       //punkt pojawiania się klocków

    [SerializeField]
    GameObject[] blocks;
    [SerializeField]
    public GameObject platform;
    [SerializeField]
    GameObject dandelion;
    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject background;

    int highScore = 0;
    public int yourScore = 0;
    public static bool gameStop;
    public float Lives = 3;
    bool dandelionGrabbed = false;
    bool play = true;
    string EndStoryShowed;
    // Start is called before the first frame update
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
        Time.timeScale = 1f;
        highScore = PlayerPrefs.GetInt("highScorelvl3");
        //PlayerPrefs.DeleteKey("dandelionLvlName3");
        int randomBlock = Random.Range(0, blocks.Length);       // utwórz jeden klocek od razu
        Instantiate(blocks[randomBlock], spawnPoint.position, Quaternion.identity);

        GameData.height = ground.transform.position.y;
        GameData.heightBack = background.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lives <= 0)
        {
            Destroy(Mou3);
            MouDead();
        }
        else if (Lives == 2)
        {
            Destroy(Mou1);
        }
        else if (Lives == 1)
        {
            Destroy(Mou2);
        }

        if (!gameStop)
        {
            highScoreTxt.text = highScore.ToString();
            yourScoreTxt.text = "" + yourScore;

        }
    }

    public void SpawnBlock()    //nowy klocek
    {
        if(play)
        {
            StartCoroutine(WaitCoroutine());                //after 2 seconds create new Block
        }
        
    }

    public void MouDead()
    {
        if (yourScore > highScore)
        {
            PlayerPrefs.SetInt("highScorelvl3", yourScore);
        }
        gameStop = true;
        restartBtn.SetActive(true);
        menuBtn.SetActive(true);
        play = false;
    }
    
    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(2);
        if (GameData.noOtherBlock == true && play == true)
        {
            if (yourScore == 7 && !PlayerPrefs.HasKey("dandelionLvlName3"))   // Pojawianie się Dmuchawca
            {
                Instantiate(dandelion, spawnPoint.position, Quaternion.identity);
            }
            else
            {
                int randomBlock = Random.Range(0, blocks.Length);
                Instantiate(blocks[randomBlock], spawnPoint.position, Quaternion.identity); //tworzy nowy klocek
            }
            
            GameData.noOtherBlock = false;
        }

    }
    public void RestartGame()
    {
        SceneManager.LoadScene("Level3");
    }
    public void GoToMenu()
    {
        if (!PlayerPrefs.HasKey("dandelionLvlName3") || (PlayerPrefs.HasKey("dandelionLvlName3") && PlayerPrefs.HasKey("EndStoryShowed")))
        {
            SceneManager.LoadScene("GameMenu");
        }
        else if(PlayerPrefs.HasKey("dandelionLvlName3")&& !PlayerPrefs.HasKey("EndStoryShowed"))
        {
            PlayerPrefs.SetString("EndStoryShowed",EndStoryShowed);
            SceneManager.LoadScene("EndStory");
        }

    }

}

