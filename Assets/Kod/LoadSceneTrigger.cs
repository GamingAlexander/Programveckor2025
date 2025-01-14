using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneTrigger : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] AudioTool audioManager;
    drive truck;
    public float wait;
    float timer;
    bool active = false;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        print("trigger Scene");
        truck = collision.GetComponent<drive>();
        truck.driveForce = 0;
        truck.rb2d.velocity = truck.rb2d.velocity / 2;
        audioManager.FadeOutAllAudio();
        timer = wait;
        active = true;
    }

    private void Update()
    {
        if (active)
        {
            truck.rb2d.velocity *= 0.95f;

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
