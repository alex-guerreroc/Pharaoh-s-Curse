using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escorpion : MonoBehaviour




{
    public Transform playerPosition;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition=GameObject.FindWithTag("Player").transform;
        gameObject.transform.position=Vector2.MoveTowards(gameObject.transform.position,playerPosition.position,speed*Time.deltaTime);
    }
}
