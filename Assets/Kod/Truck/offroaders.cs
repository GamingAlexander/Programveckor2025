using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class offroaders : LoadSceneTrigger
{

    drive dr;

    int stones = 0;
    float timer2;

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.layer == LayerMask.NameToLayer("offroad"))
        {
            print("offroading");
            dr.offroad = true;
            StartCoroutine(offroadCountdown());
          
        }

        if (collision.gameObject.tag == "STEN" && timer2 < 0)
        {
            stones += 1;
            if (stones == 3)
                die();

            timer2 = 1;
            timer2 -= Time.deltaTime;
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
        die();
        print("its so over");
    }

    void die()
    {
        audioManager.FadeOutAllAudio();
        screen.ScreenFadeOut();
        timer = wait;
        active = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        dr = FindObjectOfType<drive>();
    }

    // Update is called once per frame
    void Update()
    {
        if(active)
        {
             if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}
