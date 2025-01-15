using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noGas : MonoBehaviour
{
    GameObject truck;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(noMoreGas());
            truck = collision.gameObject;
        }
    }

    IEnumerator noMoreGas()
    {
        for (int i = 0; i < 100; i++)
        {
            print("no more as lol");
            yield return new WaitForSeconds(0.1f);
            truck.gameObject.GetComponent<drive>().driveForce -= 41;
        }
    }
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
