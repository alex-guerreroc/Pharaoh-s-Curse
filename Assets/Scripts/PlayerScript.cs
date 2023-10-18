using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float baseSpeed;
    private Vector2 direction;
    public float sprintSpeedMultiplier;
    public float tiredSpeedMultiplier;
    public float sprintDrainPerSec;
    public float sprintGainPerSec;
    private float currentSpeed;
    public double staminaValue;
    private double staminaValueCounter;
    private bool Tired = false;
    private bool Sprinting = false;

    public enum MovementType {Walking, Sprinting, Tired}
    MovementType Movement;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed=baseSpeed;
        staminaValueCounter=staminaValue;
    }

    void Update()
    {
    


        if(Input.GetKeyDown(KeyCode.LeftShift) && Movement != MovementType.Tired)
        {
            Movement = MovementType.Sprinting;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift) && Movement != MovementType.Tired)
        {
            Movement = MovementType.Walking;
        }

        switch(Movement)
        {
            case MovementType.Walking:
                currentSpeed=baseSpeed;
                break;
            case MovementType.Sprinting:
                currentSpeed=baseSpeed*sprintSpeedMultiplier;
                break;
            case MovementType.Tired:
                currentSpeed=baseSpeed*tiredSpeedMultiplier;
                break;
        }

        if(Movement == MovementType.Sprinting && staminaValueCounter>0)
        {
            staminaValueCounter -= Time.deltaTime * sprintDrainPerSec;
        }
        else if(staminaValueCounter<staminaValue)
        {
            staminaValueCounter += Time.deltaTime * sprintGainPerSec;
        }

        if(staminaValueCounter<=0)
        {
            staminaValueCounter=0;
            Movement = MovementType.Tired;
        }
        if (staminaValueCounter>=60 && Movement == MovementType.Tired)
        {
            Movement = MovementType.Walking;
        }
        if (staminaValueCounter>=staminaValue)
        {
            staminaValueCounter=staminaValue;
        }

        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        

        //Debug.Log(staminaValueCounter);

    }
    void FixedUpdate()
    {
        //rb.AddForce(direction.normalized * currentSpeed,ForceMode2D.Impulse);
        rb.velocity = (direction.normalized * currentSpeed);
    }
}
