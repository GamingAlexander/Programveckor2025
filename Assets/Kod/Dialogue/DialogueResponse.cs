[System.Serializable]
public class DialogueResponse
{
    public string responseText; // Texten f�r detta val
    public DialogueNode nextNode; // N�sta nod f�r dialogen
    public string sceneToLoad; // Namnet p� scenen att ladda (l�mna tomt om ingen scenbyte ska ske)
}
