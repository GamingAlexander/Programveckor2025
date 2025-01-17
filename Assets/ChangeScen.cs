using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private float delayBeforeSceneChange = 5f; // Tid i sekunder innan scenbytet sker

    [SerializeField]
    private string sceneToLoad; // Namnet p� scenen att ladda

    private void Start()
    {
        // Startar en coroutine som byter scen efter en viss tid
        StartCoroutine(ChangeSceneAfterDelay());
    }

    private System.Collections.IEnumerator ChangeSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeSceneChange); // V�ntar den specificerade tiden
        SceneManager.LoadScene(sceneToLoad); // Byter till �nskad scen
    }
}
