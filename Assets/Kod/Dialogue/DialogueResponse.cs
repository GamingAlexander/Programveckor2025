[System.Serializable]
public class DialogueResponse
{
    public string responseText; // Text for the response
    public DialogueNode nextNode; // Next dialogue node
    public string sceneToLoad; // Scene to load if applicable
    public string animationTrigger; // Animation trigger (leave empty if none)
}