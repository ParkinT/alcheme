// This script lives on the Altar to 'receive' an artifact
﻿using UnityEngine;
using System.Collections;

public class AltarReceiver : MonoBehaviour {

private string [] ARTIFACTS_LIST = { "artifact_ego", "artifact_faith", "artifact_courage"} ;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider other) {
		if ((other.gameObject as GameObject).tag == "Player") {
				GameObject player = other.gameObject as GameObject;
				PlayerInventory playerInv = player.GetComponent<PlayerInventory>();
				if (playerInv.hasAnArtifact()) {
					foreach (string artifact in ARTIFACTS_LIST) {
						if (playerInv.hasArtifact(artifact)) {
							ArtifactResponse(artifact);
							playerInv.DropArtifact(artifact);
							return;
						}
					}
				}
		}
		// else nothing happens
	}

	private void ArtifactResponse(string artifact) {
		Debug.Log("We need to respond appropriately to " + artifact.ToUpper());
	}
}
