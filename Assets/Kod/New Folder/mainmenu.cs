using System.Collections; // For IEnumerator
using UnityEngine; // For Unity-specific functionality
using UnityEngine.SceneManagement; // For SceneManager

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator; // Assign your FadeScreen Animator in the Inspector
    [SerializeField] private float fadeDuration = 1f; // Set fade animation duration (match it with your Animator)

    public void PlayGame()
    {
        Debug.Log("PlayGame button clicked!");
        StartCoroutine(FadeAndLoadScene());
    }

    public void Quit()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }

    private IEnumerator FadeAndLoadScene()
    {
        // Trigger the fade-to-black animation
        fadeAnimator.SetTrigger("LowTaperFade1");

        // Wait for the fade animation to complete
        yield return new WaitForSeconds(fadeDuration);

        // Load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
