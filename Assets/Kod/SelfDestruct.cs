using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float deathTimer;

    public virtual void Start()
    {
        Destroy(gameObject, deathTimer);
    }
}
