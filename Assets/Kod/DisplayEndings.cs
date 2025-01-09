using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEndings : MonoBehaviour
{
    CompletedEndings saved;
    int length;
    [SerializeField] GameObject endingIconPrefab;

    void Start()
    {
        saved = GetComponent<CompletedEndings>();
        length = saved.endings.Length;
        for (int i = 0; i < length; i++)
        {
            Instantiate(endingIconPrefab, new Vector3(-length +i, 0), Quaternion.identity, transform);
        }
    }

}
