[System.Serializable]
public class DialogueResponse
{
    public string responseText; // Texten för detta val
    public DialogueNode nextNode; // Nästa nod för dialogen
    public string sceneToLoad; // Namnet på scenen att ladda (lämna tomt om ingen scenbyte ska ske)
}
