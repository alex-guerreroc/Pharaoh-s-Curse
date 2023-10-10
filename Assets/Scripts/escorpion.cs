using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escorpion : MonoBehaviour




{
    public Transform playerPosition;
    public float speed;
    public Rigidbody2D hitbox;
    public Vector2 goPosition;
    public Vector3 offset=new Vector3(0,0.72f,0);


    // Start is called before the first frame update
    void Start()
    {
        hitbox=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition=GameObject.FindWithTag("Player").transform;
        
        
    }

    void FixedUpdate()
    {
        goPosition=Vector2.MoveTowards(gameObject.transform.position,playerPosition.position-offset,speed*Time.fixedDeltaTime);
        hitbox.MovePosition(goPosition);
    }
}
