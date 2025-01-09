using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance { get; private set; }

    // UI references
    public GameObject DialogueParent; // Main container for dialogue UI
    public TextMeshProUGUI DialogTitleText, DialogBodyText; // Text components for title and body
    public GameObject responseButtonPrefab; // Prefab for generating response buttons
    public Transform responseButtonContainer; // Container to hold response buttons

    [SerializeField] private float typingSpeed = 0.05f; // Delay between each character (adjustable)

    private Coroutine typingCoroutine;

    private void Awake()
    {
        // Singleton pattern to ensure only one instance of DialogueManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Initially hide the dialogue UI
        HideDialogue();
    }

    // Starts the dialogue with given title and dialogue node
    public void StartDialogue(string title, DialogueNode node)
    {
        // Display the dialogue UI
        ShowDialogue();

        // Set dialogue title
        DialogTitleText.text = title;

        // Stop any ongoing typing effect and clear text
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);
        }

        // Start typing the dialogue text
        typingCoroutine = StartCoroutine(TypeText(node.dialogueText));

        // Remove any existing response buttons
        foreach (Transform child in responseButtonContainer)
        {
            Destroy(child.gameObject);
        }

        // Create and setup response buttons based on current dialogue node
        foreach (DialogueResponse response in node.responses)
        {
            GameObject buttonObj = Instantiate(responseButtonPrefab, responseButtonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = response.responseText;

            // Setup button to trigger SelectResponse when clicked
            buttonObj.GetComponent<Button>().onClick.AddListener(() => SelectResponse(response, title));
        }
    }

    // Coroutine to type text letter by letter
    private IEnumerator TypeText(string text)
    {
        DialogBodyText.text = ""; // Clear the text before starting
        foreach (char c in text)
        {
            DialogBodyText.text += c;
            yield return new WaitForSeconds(typingSpeed); // Wait before adding next character
        }
    }

    // Handles response selection and triggers next dialogue node
    public void SelectResponse(DialogueResponse response, string title)
    {
        // Check if there's a scene to load
        if (!string.IsNullOrEmpty(response.sceneToLoad))
        {
            SceneManager.LoadScene(response.sceneToLoad);
            return;
        }

        // Check if there's a follow-up node
        if (!response.nextNode.IsLastNode())
        {
            StartDialogue(title, response.nextNode); // Start next dialogue
        }
        else
        {
            // If no follow-up node, end the dialogue
            HideDialogue();
        }
    }

    // Hide the dialogue UI
    public void HideDialogue()
    {
        DialogueParent.SetActive(false);
    }

    // Show the dialogue UI
    private void ShowDialogue()
    {
        DialogueParent.SetActive(true);
    }

    // Check if dialogue is currently active
    public bool IsDialogueActive()
    {
        return DialogueParent.activeSelf;
    }
}