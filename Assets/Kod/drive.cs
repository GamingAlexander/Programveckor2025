using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drive : MonoBehaviour
{
    Rigidbody2D rb2d;
    TruckSprite spriteHandler;
    [SerializeField] int driveForce;   
    bool driving = false;
    [SerializeField] float turnAngle;
    [SerializeField] int forceDoubler;
    [SerializeField] float autoTurn;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = FindObjectOfType<Rigidbody2D>();
        spriteHandler = transform.GetChild(0).GetComponent<TruckSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!Input.GetKey(KeyCode.LeftControl)) //ifall bromsen inte är tryckt
        {
            if (Input.GetKey(KeyCode.W))  
            {
                if (rb2d.velocity.x > forceDoubler || rb2d.velocity.x < -forceDoubler || rb2d.velocity.y > forceDoubler || rb2d.velocity.y < -forceDoubler)
                {
                    rb2d.AddForce(transform.up * driveForce * 2f * Time.deltaTime); //ifall man har mer än en viss hastighet så ökas kraften som ges, enkel acceleration
                }
                else
                    rb2d.AddForce(transform.up * driveForce * Time.deltaTime); //annars används samma vanliga hastighet
                driving = true;
            }

            if (Input.GetKey(KeyCode.S)) //backa
            {
                rb2d.AddForce(-transform.up * driveForce * Time.deltaTime);
                driving = true;
            }

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) //automatisk broms
            {
                driving = false;
            }
        }

        if(Input.GetKey(KeyCode.A)) //svänga vänster och höger
        {
            transform.Rotate(0, 0, turnAngle * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -turnAngle * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftControl)) //bromsen
        {
            rb2d.AddForce(-rb2d.velocity / 1.5f * Time.deltaTime);
            if(rb2d.velocity.x < 0.8 && rb2d.velocity.x > -0.8 && rb2d.velocity.y < 0.8 && rb2d.velocity.y > -0.8) //lastbilen stannar ifall den hamnar under denna hastighet
            {
                rb2d.Sleep();
            }
        }
        else if (driving == false) //automatisk broms
        {
            rb2d.AddForce(-rb2d.velocity / 2 * Time.deltaTime);
            if (rb2d.velocity.x < 0.7 && rb2d.velocity.x > -0.7 && rb2d.velocity.y < 0.7 && rb2d.velocity.y > -0.7) //lastbilen stannar ifall den hamnar under denna hastighet
            {
                rb2d.Sleep();
            }
        }

        if (spriteHandler.currentDirectionIndex == 0) //ifall sprite är norr 
        {
            Debug.Log("fix north");
            float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, 0, autoTurn * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
        if (spriteHandler.currentDirectionIndex == 2) //ifall sprite är öst
        {
            Debug.Log("fix east");
            float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, 90, autoTurn * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
        if (spriteHandler.currentDirectionIndex == 4) //ifall sprite är syd
        {
            Debug.Log("fix south");
            float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, 180, autoTurn * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }
        if (spriteHandler.currentDirectionIndex == 6) //ifall sprite är väst
        {
            Debug.Log("fix west");
            float newAngle = Mathf.LerpAngle(transform.eulerAngles.z, 270, autoTurn * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, 0, newAngle);
        }

    }
}
