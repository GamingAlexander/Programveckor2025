using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAsTruck : MonoBehaviour
{
    TruckSprite truck;
    [SerializeField] float offsetZ;
    private void Start()
    {
        truck = transform.parent.GetComponent<TruckSprite>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < 7; i++)
        {
            if (truck.currentDirectionIndex == i)
            {
                //transform.localEulerAngles = new Vector3(0, 0, 0);
                transform.eulerAngles = new Vector3(0,0, i * 45 + offsetZ);
                //transform.Rotate(0, 0, i * 45 + offsetZ, Space.World);
            }
        }
    }
}
