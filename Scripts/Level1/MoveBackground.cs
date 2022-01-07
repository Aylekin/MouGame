using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float leftWay = -8f, rightWay = 8f;

    // Update is called once per frame
    void Update()
    {   
        transform.position = new Vector3(transform.position.x + moveSpeed * Time.deltaTime,
            transform.position.y, transform.position.z);

        if(transform.position.x < leftWay)
        {
            transform.position = new Vector3(rightWay, transform.position.y, transform.position.z);
        }
    }
}
