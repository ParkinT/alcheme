using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MessageTypewriter : MonoBehaviour
{
    /// <summary>
    /// The message that will be displayed when this guide post is reached.
    /// </summary>
    public string Message;


    /// <summary>
    /// Speed at which text is displayed.
    /// </summary>
    public float Delay = 0.2f;


    /// <summary>
    /// UI Text component to display the text.
    /// </summary>
    public Text TextComponent;


    /// <summary>
    /// Background image that the text will be displayed on top of.  Optional.
    /// </summary>
    public GameObject BackgroundImage;


    /// <summary>
    /// Whether the text has already been displayed.
    /// </summary>
    private bool hasBeenTriggered = false;
    

    /// <summary>
    /// Sounds to play as the text is displayed.  Optional.
    /// </summary>
    public AudioClip typeSound1;
    public AudioClip typeSound2;



    /// <summary>
    /// Displays text one character at a time.
    /// </summary>
    IEnumerator TypeText()
    {
        foreach (char letter in Message.ToCharArray())
        {
            TextComponent.text += letter;

            // Play a sound with each letter displayed
            //if (typeSound1 && typeSound2)
            //    SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);

            yield return 0;
            yield return new WaitForSeconds(Delay);
        }
    }


    /// <summary>
    /// Starts the animation to display the message.
    /// </summary>
    /// <param name="other">Object colliding with this object.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Display the background image and the text box
            if (BackgroundImage != null)
                BackgroundImage.SetActive(true);

            //TextComponent
            TextComponent.text = "";
            StartCoroutine(TypeText());

            hasBeenTriggered = true;
        }
    }
}
