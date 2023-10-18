using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escorpion : MonoBehaviour




{
    public Transform playerTransform;
    public float speed;
    public Rigidbody2D hitbox;
    public Vector2 goPosition;
    public Vector3 offset=new Vector3(0,0.72f,0);

    public enum AIState {Wander, Chase};
    public AIState ScorpionState;

    // Start is called before the first frame update
    void Start()
    {
        hitbox=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerTransform=GameObject.FindWithTag("Player").transform;
        /*
        RaycastHit2D hit = Physics2D.Raycast(transform.position, playerTransform.position - transform.position, Vector2.Distance(playerTransform.position, transform.position));
        Debug.Log(hit.collider.tag);
        if(hit.collider.tag == "Player")
        {
            ScorpionState = AIState.Chase;
            Debug.Log(1);
        }
        else
        {
            ScorpionState = AIState.Wander;
            Debug.Log(2);
        }
        */
    }

    void FixedUpdate()
    {
        /*
        if(ScorpionState == AIState.Wander)
        {
            goPosition=Vector2.MoveTowards(gameObject.transform.position,playerTransform.position-offset,(speed/2)*Time.fixedDeltaTime);
        }
        else if(ScorpionState == AIState.Chase)
        {
            goPosition=Vector2.MoveTowards(gameObject.transform.position,playerTransform.position-offset,speed*Time.fixedDeltaTime);
        }
        */
        goPosition=Vector2.MoveTowards(gameObject.transform.position,playerTransform.position-offset,speed*Time.fixedDeltaTime);
        hitbox.MovePosition(goPosition);
    }
}
