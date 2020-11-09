using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed = 0.7f;
    public float jumpForce = 4f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float dirHorizontal = Input.GetAxis("Horizontal");
        rb2d.AddForce(new Vector2(dirHorizontal, 0) * speed,ForceMode2D.Impulse);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(new Vector2(0, 1) * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
