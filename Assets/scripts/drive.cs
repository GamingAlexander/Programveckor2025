using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] int driveForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKey(KeyCode.D))
            {
                rb2d.AddForce(transform.right * 1);
            }

            if (Input.GetKey(KeyCode.A))
            {
                rb2d.AddForce(-transform.right * 1);
            }

            if (Input.GetKey(KeyCode.W))
            {
                rb2d.AddForce(transform.up * 1);
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb2d.AddForce(-transform.up * 1);
            }
        }
       
        rb2d.AddForce(new Vector2(rb2d.totalForce.x, rb2d.totalForce.y).normalized * driveForce);

        if (Input.GetKey(KeyCode.Space))
        {
            rb2d.AddForce(-rb2d.velocity / 0.4f);
            if(rb2d.velocity.x < 0.9 && rb2d.velocity.x > -0.9 && rb2d.velocity.y < 0.9 && rb2d.velocity.y > -0.9)
            {
                rb2d.Sleep();
            }


        }
    }
}
