using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingTrigger : MonoBehaviour
{
    [SerializeField] int ending;
    private void Start()
    {
        GetComponent<CompletedEndings>().CompleteEndning(ending);
    }
}
