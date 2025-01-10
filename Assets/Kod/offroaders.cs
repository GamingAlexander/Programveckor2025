using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offroaders : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("hej hej");
        if (collision.gameObject.layer == LayerMask.NameToLayer("offroad"))
        {
            StartCoroutine(offroadCountdown());
        }
    }

    IEnumerator offroadCountdown()
    {
        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(1);
        }
        print("its so over");
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
