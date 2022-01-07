using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DandelionClick2 : MonoBehaviour
{
    string dandelionName;
    GameObject dandelion;
    GameObject gamecontroller;
    AudioSource zrodloDzwieku;
    AudioClip odglos;
    public ParticleSystem effect;

    void Start()
    {
        dandelion = GameObject.FindGameObjectWithTag("Dandelion3");
        gamecontroller = GameObject.Find("GameController");
        zrodloDzwieku = gamecontroller.GetComponent<GameControllerLvl3>().zrodloDzwieku;
        odglos = gamecontroller.GetComponent<GameControllerLvl3>().soundDandelion;
    }
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "Dandelion3")
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
            if (zrodloDzwieku != null)              
                zrodloDzwieku.PlayOneShot(odglos);
        }


    }
}

