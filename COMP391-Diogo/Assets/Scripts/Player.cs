using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public int speed;
    private Vector2 newVelocity;
    
    void Start()
    {
        newVelocity = new Vector2(0f, 0f);
    }

    void Update()
    {
        horizontalInput =  Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        newVelocity.x = horizontalInput;
        newVelocity.y = verticalInput;

        GetComponent<Rigidbody2D>().velocity = newVelocity * speed;
    }
}
