using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraScripty : MonoBehaviour
{
    [SerializeField] Vector3 camTarget;
    [SerializeField] int moveSpeed;
    GameObject truck;
    
    // Start is called before the first frame update
    void Start()
    {
       truck = FindObjectOfType<drive>().gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        camTarget.z = -10;
        camTarget.x = truck.transform.position.x;
        camTarget.y = truck.transform.position.y;
        transform.position = Vector3.Lerp(transform.position, camTarget, moveSpeed * Time.deltaTime);

        if (SceneManager.GetActiveScene().name == "RIKTIG - Drunk")
        {
            moveSpeed = 10;
        }
        else if (truck.GetComponent<Rigidbody2D>().velocity.y > truck.GetComponent<Rigidbody2D>().velocity.x || truck.GetComponent<Rigidbody2D>().velocity.y < -1)
        {
            moveSpeed = 5;
        }
        else
            moveSpeed = 1;
    }
}
