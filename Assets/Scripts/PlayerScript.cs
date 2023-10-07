using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector3 direction;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0);
        direction = direction.normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction*speed*Time.fixedDeltaTime);
    }
}
