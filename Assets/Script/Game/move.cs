using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    private float moveR;
    [SerializeField] 
    private float moveL;

    float dirx, moveSpeed = 4f;
    bool moveRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > moveR)
            moveRight = false;
        if (transform.position.x < moveL)
            moveRight = true;

        if (moveRight)
            transform.position = new Vector2 (transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        else
            transform.position = new Vector2 (transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
    }
}
