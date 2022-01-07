using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public int speed = 3;
    public float maxValue;
    public float minValue;
    public float currentValue;
    int random;
    // Start is called before the first frame update
    void Start()
    {
        maxValue = 3f;
        minValue = -3f;
        currentValue = 0;
        InvokeRepeating("SpeedUp", 2.0f, 15.0f);
    }
    
    void SpeedUp()
    {
        random=Random.Range(0, 100);
        if(random>=0 && random<=50)
        {
            speed = 5;
            Invoke("SlowDown", 2f);
        }
        
        
    }
    void SlowDown()
    {
        speed = 3;
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        currentValue += Time.deltaTime * speed;
        if (currentValue >= maxValue)
        {
            speed *= -1;
            currentValue = maxValue;
        }
        else if (currentValue <= minValue)
        {
            speed *= -1;
            currentValue = minValue;
        }
        this.transform.position = new Vector2(currentValue, transform.position.y);
    }
}
