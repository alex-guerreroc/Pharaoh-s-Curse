using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    public Transform player;
    public float speed;
    public Vector3 offset;
    Vector3 desiredPos;
    private Vector2 Dist;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        desiredPos = player.position + offset;
    }

    void FixedUpdate()
    {
        //Vector3 desiredPos = player.position + offset;
        Dist = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y);
        
        /*
        if(Dist.magnitude > 1f)
        {
            //transform.position = player.position - 1*(new Vector3(Dist.x, Dist.y, 0)/Dist.magnitude) + offset;
            Debug.Log("Max");
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.fixedDeltaTime);
            Debug.Log("Norm");
        }
        */

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if(Dist.magnitude > 1.25f && rb.velocity.magnitude != 0f)
        {
            transform.position += new Vector3(rb.velocity.x, rb.velocity.y, 0) * Time.fixedDeltaTime;
            Debug.Log("Max");
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.fixedDeltaTime);
            Debug.Log("Norm");
        }
    }
}
