using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : MonoBehaviour {
	public List<string> Artifacts;

	// Use this for initialization
	void Start () {

		//load PlayerPrefs
		string carrying_artifact = PlayerPrefs.GetString("artifact");
		if (!string.IsNullOrEmpty(carrying_artifact)) {
				Artifacts.Add(carrying_artifact);
		}
		// add health too

Debug.Log(carrying_artifact);
	}

	// Update is called once per frame
	void Update () {

	}

	// Is the player currently carrying ANY artifact?
	public bool hasAnArtifact() {
		return (Artifacts.Count > 0);
	}

	// Does the player currently posses the artifact named?
	public bool hasArtifact(string name) {
		return (Artifacts.Contains(name.ToLower()));
	}

	// Add an artifact - the player has "picked up"
	public void AddArtifact(string name) {
		if (Artifacts.Contains(name.ToLower())) {
			//nop
		}
		else
		{
			Artifacts.Add(name.ToLower());
		}
	}

	// We no longer need to carry this artifact
	public void DropArtifact(string name) {
		if (Artifacts.Contains(name.ToLower())) {
			Artifacts.Remove(name.ToLower());
		}
	}

	public void DropAll() {
		Artifacts.Clear();
		PlayerPrefs.SetString("artifact", string.Empty);
	}
}
