using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Story : MonoBehaviour
{
    [SerializeField]
    int tap = 0;
    [SerializeField]
    public GameObject Slajd1, Slajd2, Slajd3, Slajd4;
    [SerializeField]
    public Text Text1, Text2, Text3, Text4, Text5, Text6;
   
    void Start()
    {
        tap = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            tap++;
            if(tap==1)
            {
                FadeIn(Text1, Color.black);
            }
            else if(tap==2)
            {
                FadeIn(Text2, Color.black);
            }
            else if(tap==3)
            {
                Slajd1.SetActive(false);
                Slajd2.SetActive(true);
            }
            else if(tap==4)
            {
                FadeIn(Text3, Color.black);
            }
            else if (tap == 5)
            {
                FadeIn(Text4, Color.black);
            }
            else if (tap == 6)
            {
                Slajd2.SetActive(false);
                Slajd3.SetActive(true);
            }
            else if (tap == 7)
            {
                FadeIn(Text5, Color.black);
            }
            else if (tap == 8)
            {
                Slajd3.SetActive(false);
                Slajd4.SetActive(true);             
            }
            else if (tap == 9)
            {
                FadeIn(Text6, Color.black);
            }
            else if (tap == 10)
            {
                Slajd4.SetActive(false);
                SceneManager.LoadScene("GameMenu");
            }         
        }      
    }

    public void FadeIn(Text Tekst, Color newColor)
    {
        if(Time.deltaTime==0)           
        {
            Tekst.color = newColor;
        }
        else
        {
            StartCoroutine(FadeInRoutine());
            IEnumerator FadeInRoutine()
            {
                while (Tekst.color.a < 255)
                    {
                        Tekst.color = Color.Lerp(Tekst.color, newColor, 1f * Time.deltaTime); 
                        yield return null;
                    }
            }
        }
    }
}
