using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    public void GoToLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void GoToLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void GoToLevel3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void GoToGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
    public void GotoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void GoToStory()
    {
        SceneManager.LoadScene("Story");
    }
    public void EndStory()
    {
        SceneManager.LoadScene("EndStory"); 
    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }
}
