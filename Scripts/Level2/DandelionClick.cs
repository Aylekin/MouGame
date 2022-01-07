using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionClick : MonoBehaviour
{
    string dandelionName;
    GameObject dandelion;
    GameObject gamecontroller;
    public AudioSource zrodloDzwieku;
    public AudioClip odglos;
    public ParticleSystem effect;

    void Start()
    {
        dandelion = GameObject.FindGameObjectWithTag("Dandelion2");     //uniwersalność? 
        gamecontroller = GameObject.Find("GameController");
        zrodloDzwieku = gamecontroller.GetComponent<GameControllerLvl2>().zrodloDzwieku;
        odglos = gamecontroller.GetComponent<GameControllerLvl2>().soundDandelion;
    }
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Debug.Log("Kliku klik");
        if (gameObject.tag == "Dandelion2")
        {
            var instance = Instantiate(effect, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance, 2f);

            dandelionName = dandelion.gameObject.tag;
            dandelionName = dandelionName[dandelionName.Length - 1].ToString();
            if (!PlayerPrefs.HasKey("dandelionLvlName" + dandelionName))   //Tworzy się zapisana zmienna z numerem konkretnego poziomu
            {
                PlayerPrefs.SetString("dandelionLvlName" + dandelionName, dandelionName);
                PlayerPrefs.Save();
            }
            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglos);
            Destroy(dandelion);
        }


    }
}
