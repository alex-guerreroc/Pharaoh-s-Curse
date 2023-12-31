using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CustomEnemyAI : MonoBehaviour
{

    public Transform target;
    public float speed;
    public float nextWaypointDistance;

    Path path;
    int currentWaypoint=0;
    bool reachedEndOfPath=false;

    Seeker seeker;
    Rigidbody2D rb;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        seeker=GetComponent<Seeker>();
        rb=GetComponent<Rigidbody2D>();
        sr=transform.GetChild(0).GetComponent<SpriteRenderer>();

        InvokeRepeating("UpdatePath",0f,.5f);


    }

    void Update()
    {
        if(target.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(rb.position, target.position, OnPathComplete);
        
    }


    void OnPathComplete(Path p)
    {
        if(!p.error)
        {
            path=p;
            currentWaypoint=0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (path==null)
        {
            return;}

            if(currentWaypoint>=path.vectorPath.Count)
            {
                reachedEndOfPath=true;
                return;
            } else
            {
                reachedEndOfPath=false;
            }

            Vector2 direction=((Vector2)path.vectorPath[currentWaypoint]-rb.position).normalized;
            Vector2 force=direction*speed*Time.fixedDeltaTime;

            //rb.AddForce(force); 
            rb.velocity=force;

            float distance= Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

            if(distance<nextWaypointDistance)
            {
                currentWaypoint++;
            }

        
    }
}
