using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Animator fadeAnimator; // Attach your FadeScreen Animator
    [SerializeField] private float fadeDuration = 1f; // Match this to the length of the animation

    private void Start()
    {
        DontDestroyOnLoad(fadeAnimator.gameObject);
      
    }
    public void PlayGame()
    {
        Debug.Log("PlayGame button clicked!");
        fadeAnimator.SetTrigger("FadeIn"); // Ensure this matches the trigger in Animator
        StartCoroutine(LoadSceneAfterFade());
    }

    private IEnumerator LoadSceneAfterFade()
    {
        Debug.Log("Waiting for fade-out to complete...");
        yield return new WaitForSeconds(fadeDuration);
        SceneManager.LoadScene("GasstationTest");
    }

    public void QuitGame()
    {
        Debug.Log("QuitGame button clicked!");
        Application.Quit();
    }
}
