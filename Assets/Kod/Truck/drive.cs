using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class drive : MonoBehaviour
{
    public Rigidbody2D rb2d;
    TruckSprite spriteHandler;
    public float driveForce;   
    bool driving = false;
    public bool backing;
    public bool bracking;
    [SerializeField] float turnAngle;
    [SerializeField] int forceDoubler;
    [SerializeField] float autoTurn;
    public bool offroad;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = FindObjectOfType<Rigidbody2D>();
        spriteHandler = transform.GetChild(0).GetComponent<TruckSprite>();
    }

    // Update is called once per frame
    void Update()
    {
        if (offroad)
        {
            driveForce = 4600;
        }
        else
            driveForce = 5400;

        if(!Input.GetKey(KeyCode.LeftControl) && SceneManager.GetActiveScene().name != "RIKTIG - Drunk") //ifall bromsen inte är tryckt och man inte är full
        {
            if (Input.GetKey(KeyCode.W))  
            {
                if (offroad == true)
                {
                    rb2d.AddForce(transform.up * driveForce * 0.8f * Time.deltaTime); //mindre hastighet ifall offroad;
                }   
                else if (rb2d.velocity.x > forceDoubler || rb2d.velocity.x < -forceDoubler || rb2d.velocity.y > forceDoubler || rb2d.velocity.y < -forceDoubler)
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
                backing = true;
            }
            else
            {
                backing = false;
            }

            if (!Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W)) //automatisk broms
            {
                driving = false;
            }
            bracking = false;
        }
        if(SceneManager.GetActiveScene().name == "RIKTIG - Drunk" && spriteHandler.currentDirectionIndex == 6 || SceneManager.GetActiveScene().name != "RIKTIG - Drunk")
        {
            if (Input.GetKey(KeyCode.A)) //svänga vänster och höger
            {
                transform.Rotate(0, 0, turnAngle * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(0, 0, -turnAngle * Time.deltaTime);
            }
        }
        

        if (Input.GetKey(KeyCode.LeftControl)) //bromsen
        {
            rb2d.AddForce(-rb2d.velocity / 1.5f * Time.deltaTime);
            if(rb2d.velocity.x < 0.8 && rb2d.velocity.x > -0.8 && rb2d.velocity.y < 0.8 && rb2d.velocity.y > -0.8) //lastbilen stannar ifall den hamnar under denna hastighet
            {
                rb2d.Sleep();
            }
            bracking = true;
        }
        else if (driving == false) //automatisk broms
        {
            rb2d.AddForce(-rb2d.velocity / 2 * Time.deltaTime);
            if (rb2d.velocity.x < 0.7 && rb2d.velocity.x > -0.7 && rb2d.velocity.y < 0.7 && rb2d.velocity.y > -0.7) //lastbilen stannar ifall den hamnar under denna hastighet
            {
                rb2d.Sleep();
            }
        }

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            for (int i = 0; i < 7; i++)
            {
                if (spriteHandler.currentDirectionIndex == i)
                {
                    SetAngle(Mathf.LerpAngle(transform.eulerAngles.z, i * 45, autoTurn * Time.deltaTime));
                }
            }
        }
         
       
    }
    private void SetAngle(float Z)
    {
        transform.rotation = Quaternion.Euler(0, 0, Z);
    }
}
