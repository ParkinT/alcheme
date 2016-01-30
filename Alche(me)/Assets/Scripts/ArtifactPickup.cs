using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ArtifactPickup : MonoBehaviour {

	public string ArtifactName = "FILL IN ARTIFACT NAME";

	private static ILogger logger = Debug.logger;

	// Use this for initialization
	void Start () {

		if (string.IsNullOrEmpty(ArtifactName)) {
			Debug.LogError("Artifact Must Be Named!");
			logger.LogError("Artifact", "Naming Error");
			throw new System.ArgumentNullException("Artifact Name");
		}
		if (!ArtifactName.Contains("_")) {
			ArtifactName = "artifact_" + ArtifactName;
		}
	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			PlayerInventory playerInv = other.GetComponent<PlayerInventory>();
			playerInv.AddArtifact(this.ArtifactName.ToLower());
		  //Destroy(this, 1);	 //this is not necessary because we reload the scene
			PlayerPrefs.SetString("artifact", ArtifactName.ToLower());
			//set current health this way too
			SceneManager.LoadScene("Main");
		}
		// else - nothing
	}
}
