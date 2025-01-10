using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Update()
    {
        camTarget.z = -10;

        camTarget.x = truck.transform.position.x;
        camTarget.y = truck.transform.position.y;
        transform.position = Vector3.Lerp(transform.position, camTarget, moveSpeed * Time.deltaTime);
    }
}
