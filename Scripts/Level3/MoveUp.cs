using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    //float height, heightBack;
    bool movement;

    [SerializeField]
    GameObject ground;
    [SerializeField]
    GameObject background;
    [SerializeField]
    Transform checkPoint;
    //[SerializeField]
   // Transform checkPoint2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()   //Fixed update bo dzięki temu nie skacze obraz
    {
        if(movement == true)
        {
            ground.transform.position = new Vector2(ground.transform.position.x, GameData.height + moveSpeed * Time.deltaTime);
            background.transform.position = new Vector2(background.transform.position.x, GameData.heightBack + moveSpeed * Time.deltaTime);
        }
        if((ground.transform.position.y >= checkPoint.position.y))//(ground.transform.position.y >= checkPoint2.position.y) || 
        {
            movement = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Block" || collision.tag=="Dandelion3")
        {
            GameData.height -= (float)0.35;
            GameData.heightBack -= (float)0.45;
            movement = true;
            //ground.transform.position = new Vector2(ground.transform.position.x, height); //przesuń w dół
        }
    }
}
