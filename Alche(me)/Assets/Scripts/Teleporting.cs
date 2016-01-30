using UnityEngine;

public class Teleporting : MonoBehaviour
{
    /// <summary>
    /// Initial field of view for the camera
    /// </summary>
    public float initFOV;

    /// <summary>
    /// Final field of view for the camera
    /// </summary>
    public float finalFOV;


    /// <summary>
    /// Speed at which 
    /// </summary>
    public float speed = 10.0f;


    /// <summary>
    /// Location that the player will be teleported to
    /// </summary>
    public Transform beamToHere;


    /// <summary>
    /// The player to teleport
    /// </summary>
    public GameObject _player;


    /// <summary>
    /// Whether the player is currently being teleported
    /// </summary>
    private bool beamMeUp = false;


    /// <summary>
    /// Sound made when the teleportation occurs
    /// </summary>
    private AudioSource teleportSound;


    /// <summary>
    /// Execute when the scripts is started
    /// </summary>
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        teleportSound = gameObject.GetComponent<AudioSource>();
        initFOV = Camera.main.fieldOfView;
    }


    /// <summary>
    /// Manages the actual teleporting sequence
    /// </summary>
    void Update()
    {
        if (beamMeUp)
            Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, finalFOV, speed * Time.deltaTime);

        if (Camera.main.fieldOfView >= (finalFOV - 10.0f))
        {
            beamMeUp = false;
            Camera.main.fieldOfView = initFOV;

            // Move the player to the portal on the other end of the teleporter
            _player.transform.position = beamToHere.position;
        }
    }


    /// <summary>
    /// Triggers the script to start the teleportation sequence
    /// </summary>
    void OnTriggerPlay()
    {
        if (Input.GetKeyUp(KeyCode.T))
        {
            beamMeUp = true;
            teleportSound.Play();
        }
    }    
}
