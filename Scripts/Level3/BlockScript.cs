using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    GameObject gamecontroller;
    Transform platform;             //platforma, na której tworzy się wieża klocków            
    public ParticleSystem effect;
    bool effectPlayed = false;
    void Start()
    {
        gamecontroller = GameObject.Find("GameController");
        platform = gamecontroller.GetComponent<GameControllerLvl3>().platform.transform;
    }
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        gameObject.GetComponent<Rigidbody2D>().isKinematic = false;     //wpraw w ruch nieruchomy klocek
        gamecontroller.GetComponent<GameControllerLvl3>().SpawnBlock();
        
        GameData.noOtherBlock = false;                                  //do sprawdzenia czy można tworzyć nowy klocek
    }

    private void OnTriggerStay2D(Collider2D other)                      //unieruchom klocki z wieży
    {
       if(other.tag=="Platform" || other.tag=="Block" || other.tag=="Dandelion3")
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            gameObject.transform.SetParent(platform);
            if (effectPlayed == false)
            {
                var instance = Instantiate(effect, transform.position, transform.rotation);
                instance.Play();
                Destroy(instance.gameObject, 2);
                gamecontroller.GetComponent<GameControllerLvl3>().yourScore++;    //przeniesione tutaj by dodawało punkty tylko raz przy dotknięciu klocka podłogi
                effectPlayed = true;
            }        
        }    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag=="Ground")                                         //utrata życia przy spadniętym klocku (ew. można ustawić lineDead na samym dole ekranu)
        {
            if(gameObject.tag=="Dandelion3")
            {
                PlayerPrefs.DeleteKey("dandelionLvlName3");         // Jeśli klocek z Dandelionem przepadnie, to 3. poziom pozostaje nieodblokowany.
            }
            Destroy(gameObject);
            GameData.noOtherBlock = true;
            Debug.Log("true");      
            gamecontroller.GetComponent<GameControllerLvl3>().Lives--;
        }
        else if (other.tag == "Platform" || other.tag == "Block" || other.tag == "Dandelion3")
        {
            GameData.noOtherBlock = true;
            if (gamecontroller.GetComponent<GameControllerLvl3>().zrodloDzwieku != null)
                gamecontroller.GetComponent<GameControllerLvl3>().zrodloDzwieku.PlayOneShot(gamecontroller.GetComponent<GameControllerLvl3>().soundBlock);
        }
    }
    private void OnTriggerExit2D(Collider2D other)                      // jeśli klocek spadnie z wieży, to znów jest dynamiczny
    {
       if (other.tag == "Platform" || other.tag == "Block" || other.tag == "Dandelion3")
        {
            gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }

    
}
