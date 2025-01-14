using UnityEngine;

public class animationstart : MonoBehaviour
{
    [SerializeField] private Animator NewSceneFadeController; // Assign the Animator for the fade screen in the Inspector
    [SerializeField] private string fadeInTrigger = "FadeIn"; // The trigger name in the Animator

    private void Start()
    {
        PlayFadeIn(); // Call the fade-in animation when the scene starts
    }

    private void PlayFadeIn()
    {
        if (NewSceneFadeController != null)
        {
            NewSceneFadeController.SetTrigger(fadeInTrigger); // Trigger the fade-in animation
        }
        else
        {
            Debug.LogError("Fade Animator is not assigned! Please assign it in the Inspector.");
        }
    }
}
