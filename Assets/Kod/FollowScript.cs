using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    public GameObject target;
    [SerializeField] Vector3 offset;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position + offset, 1000);
    }
}
