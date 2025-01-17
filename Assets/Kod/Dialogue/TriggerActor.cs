using UnityEngine;

public class TriggerActor : MonoBehaviour
{
    public string Name;
    public Dialogue Dialogue;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpeakTo();

        }



    }
    public void SpeakTo()
    {
        DialogueManager.Instance.StartDialogue(Name, Dialogue.RootNode);
    }
}