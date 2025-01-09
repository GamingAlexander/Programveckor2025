using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField] int driveForce;   
    bool driving = false;
    [SerializeField] float turnAngle;
    [SerializeField] int forceDoubler;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = FindObjectOfType<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKey(KeyCode.LeftControl))
        {
            if (Input.GetKey(KeyCode.W))
            {
                if ((rb2d.velocity.x > forceDoubler || rb2d.velocity.x < -forceDoubler || rb2d.velocity.y > forceDoubler || rb2d.velocity.y < -forceDoubler))
                {
                    rb2d.AddForce(transform.up * driveForce * 1.6f);
                }
                else
                    rb2d.AddForce(transform.up * driveForce);
                driving = true;
            }

            if (Input.GetKey(KeyCode.S))
            {
                rb2d.AddForce(-transform.up * driveForce);
                driving = true;
            }

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
            {
                driving = false;
            }
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, turnAngle);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -turnAngle);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            rb2d.AddForce(-rb2d.velocity / 0.4f);
            if(rb2d.velocity.x < 0.8 && rb2d.velocity.x > -0.8 && rb2d.velocity.y < 0.8 && rb2d.velocity.y > -0.8)
            {
                rb2d.Sleep();
            }
        }
        else if (driving == false)
        {
            rb2d.AddForce(-rb2d.velocity / 0.7f);
            if (rb2d.velocity.x < 0.7 && rb2d.velocity.x > -0.7 && rb2d.velocity.y < 0.7 && rb2d.velocity.y > -0.7)
            {
                rb2d.Sleep();
            }
        }
    }
}
