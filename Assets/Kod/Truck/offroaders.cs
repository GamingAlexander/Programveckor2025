using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offroaders : MonoBehaviour
{

    drive dr;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("offroad"))
        {
            print("offroading");
            dr.offroad = true;
            StartCoroutine(offroadCountdown());
          
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("offroad"))
        {
            print("onroading");
            dr.offroad = false;
            StopAllCoroutines();

        }
    }



    IEnumerator offroadCountdown()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
        }
        print("its so over");
    }

    // Start is called before the first frame update
    void Start()
    {
        dr = FindObjectOfType<drive>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
