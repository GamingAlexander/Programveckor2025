using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlackingTrigger : MonoBehaviour
{
    [SerializeField] GameObject screen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        screen.GetComponent<Image>().color += new Color(0, 0, 0, 1) * Time.deltaTime;
    }
}
