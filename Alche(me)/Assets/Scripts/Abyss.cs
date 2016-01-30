using UnityEngine;

public class Abyss : MonoBehaviour
{
    /// <summary>
    /// The point where the player will be placed when the level starts.
    /// </summary>
    public Transform startPoint;


    /// <summary>
    /// Handles another game object coming in contact with the Abyss.
    /// If the other game object is the player, then the player is moved to the starting position.
    /// </summary>
    /// <param name="other">The game object that has collided with this game object.</param>
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = startPoint.position;
        }
    }
}
