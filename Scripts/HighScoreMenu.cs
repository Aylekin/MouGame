using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreMenu : MonoBehaviour
{
    [SerializeField]
    Text highScoreLvl1;
    [SerializeField]
    Text highScoreLvl2;
    [SerializeField]
    Text highScoreLvl3;

    void Update()
    {
        highScoreLvl1.text = PlayerPrefs.GetInt("highScorelvl1").ToString();
        highScoreLvl2.text = PlayerPrefs.GetInt("highScorelvl2").ToString();
        highScoreLvl3.text = PlayerPrefs.GetInt("highScorelvl3").ToString();
    }
}
