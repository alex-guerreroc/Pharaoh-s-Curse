using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float baseSpeed;
    private Vector2 direction;
    public float sprintSpeedMultiplier;
    private float currentSpeed;
    public double staminaValue;
    private double staminaValueCounter;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed=baseSpeed;
        staminaValueCounter=staminaValue;
    }

    void Update()
    {
    


        if(Input.GetKeyDown(KeyCode.LeftShift) && staminaValueCounter>10)
        {
            currentSpeed=baseSpeed*sprintSpeedMultiplier;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) || staminaValueCounter==0)
        {
            currentSpeed=baseSpeed;
        }

        staminaValueCounter=staminaValueCounter+0.2;


        if(currentSpeed>baseSpeed)
        {
            staminaValueCounter--;
        }
        if(staminaValueCounter<0)
        {
            staminaValueCounter=0;
        }
        if (staminaValueCounter>staminaValue)
        {
            staminaValueCounter=staminaValue;
        }

        /*currentSpeed=baseSpeed;
        if(Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = baseSpeed*sprintSpeedMultiplier;
            if(staminaValueCounter > 0)
            {
                staminaValueCounter-= Time.deltaTime/3;
            }
        }
        else if(staminaValueCounter<staminaValue)
        {
            staminaValueCounter-= Time.deltaTime/6;
        }*/



        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        

        Debug.Log(staminaValueCounter);

    }
    void FixedUpdate()
    {
        rb.velocity = (direction.normalized * currentSpeed);
    }
}
