using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouScript : MonoBehaviour
{
    // TO DO:
    // -

    Rigidbody2D rb;
    public bool grounded = true;
    public bool inAir = false;
    public AudioSource zrodloDzwieku;                
    public AudioClip odglos;
    public AudioClip odglosDandelion;
    public string dandelionName;
    public ParticleSystem effect;

    [SerializeField]
    float jump = 500f;

    [SerializeField]
    int tap = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!grounded && rb.velocity.y == 0)
        {
            grounded = true;
        }
        if (((Input.touchCount>0 && Input.GetTouch(0).phase==TouchPhase.Began) || Input.GetMouseButtonDown(0)) && grounded)
        {
            tap++;

            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglos);
            if (tap==1)
            {
                rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
                inAir = true;
            }
            else if (tap == 2 && inAir==true)    // Podwójny skok 
            {
                tap = 0;
                rb.AddForce(new Vector2(0f, 250f), ForceMode2D.Force);
                grounded = false;
            }
            else if(tap == 2 && inAir == false)
            {
                tap = 0;
                rb.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
                grounded = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)         // trigger do zbierania Dmuchawca, uniwersalny do poziomów, dlatego później gdy będą inne poziomy, to przenieść do uniwersalnego skryptu Gracza (ja to zrobię/M)
    {
        dandelionName = other.gameObject.tag;
        if (dandelionName == "Dandelion1" || dandelionName == "Dandelion2" || dandelionName == "Dandelion3")  
        {
            dandelionName = dandelionName[dandelionName.Length - 1].ToString();
            if(!PlayerPrefs.HasKey("dandelionLvlName"+dandelionName))   //Tworzy się zapisana zwienna z numerem konkretnego poziomu
            {
                PlayerPrefs.SetString("dandelionLvlName"+dandelionName, dandelionName);
                PlayerPrefs.Save();
            }
            if (zrodloDzwieku != null)              // dodanie dźwięku 
                zrodloDzwieku.PlayOneShot(odglosDandelion);
            var instance = Instantiate(effect, transform.position, transform.rotation);
            instance.Play();
            Destroy(instance, 2f);
            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Ground")
        {
            inAir = false;
        }
    }



}
