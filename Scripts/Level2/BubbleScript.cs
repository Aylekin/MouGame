using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleScript : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed;
    GameObject gamecontroller;
    public AudioSource zrodloDzwieku;
    public AudioClip odglosBubble;
    public AudioClip odglosToxin;
    public AudioClip odglosSnail;
    public ParticleSystem effect;


    private void Start()
    {
        gamecontroller= GameObject.Find("GameController");   // uzyskiwanie dostępu do punktów z GameControllera
        zrodloDzwieku = gamecontroller.GetComponent<GameControllerLvl2>().zrodloDzwieku;
        odglosBubble = gamecontroller.GetComponent<GameControllerLvl2>().soundBubble;
        odglosToxin = gamecontroller.GetComponent<GameControllerLvl2>().soundToxin;
        odglosSnail = gamecontroller.GetComponent<GameControllerLvl2>().soundSnail;
        moveSpeed = gamecontroller.GetComponent<GameControllerLvl2>().speed;
    }
    void Update()
    {
        transform.position = new Vector2(transform.position.x,transform.position.y + moveSpeed * Time.deltaTime);
        
        if (transform.position.y > 10f)
        {
            if (gameObject.tag == "Snail")
            {
                gamecontroller.GetComponent<GameControllerLvl2>().snailGrabbed = false;
                Destroy(gameObject);
            }

            if (gameObject.tag == "SuperBubble")
            {
                gamecontroller.GetComponent<GameControllerLvl2>().superGrabbed = false;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

            
        }
    }

    void OnMouseDown()
    {
        if (gameObject.tag == "Firefly")
        {
            var instance = Instantiate(effect, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance.gameObject, 2);
            gamecontroller.GetComponent<GameControllerLvl2>().yourScore+=1;
            
            Destroy(this.gameObject);
            Debug.Log("Świetlik!");
            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglosBubble);
            gamecontroller.GetComponent<GameControllerLvl2>().SpeedUp();
           
        }
        else if(gameObject.tag=="Toxin")
        {
            var instance = Instantiate(effect, transform.position, transform.rotation);
            instance.Play();
            
            gamecontroller.GetComponent<GameControllerLvl2>().Lives -= 1;
            Handheld.Vibrate();
            Destroy(this.gameObject);
            Destroy(instance.gameObject, 2);
            


            Debug.Log("TOKSYNA!");
            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglosToxin);
        }
        else if (gameObject.tag=="Snail")
        {
            var instance = Instantiate(effect, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance.gameObject, 2);
            Destroy(this.gameObject);
            Debug.Log("Ślimak!");
            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglosSnail);
            gamecontroller.GetComponent<GameControllerLvl2>().speed -= 1.5f;
            gamecontroller.GetComponent<GameControllerLvl2>().yourScore += 1;
            gamecontroller.GetComponent<GameControllerLvl2>().snailGrabbed = false;
          
        }
        else if (gameObject.tag=="SuperBubble")
        {
            var instance = Instantiate(effect, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance.gameObject, 2);
            gamecontroller.GetComponent<GameControllerLvl2>().yourScore += 5;
            Destroy(this.gameObject);
            Debug.Log("Super Świetlik!");
            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglosBubble);
            gamecontroller.GetComponent<GameControllerLvl2>().SpeedUp();
            
            gamecontroller.GetComponent<GameControllerLvl2>().superGrabbed = false;
        }

    }
}
