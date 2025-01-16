using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    public string sceneName;
    public AudioTool audioManager;
    public   DarkScreen screen;
    drive truck;
    public float wait;
    public float timer;
    public bool active = false;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger Scene");
        truck = collision.GetComponent<drive>();


        audioManager.FadeOutAllAudio();
        timer = wait;
        active = true;
    }

    void faded()
    {
        SceneManager.LoadScene(sceneName);
    }

        
    private void Update()
    {
        if (active)
        {
           
                //truck.driveForce = 0;
                //truck.rb2d.velocity *= 0.95f;
            

            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                screen.ScreenFadeOut();
                Invoke("faded",1f);
            }
        }
    }
}
