using UnityEngine;
using System.Collections;

public class ArtifactRise : MonoBehaviour {

	public Vector3 ArtifactUp;
	private bool _rising = false;
	private float _riseRate = 0.45f;

	// Use this for initialization
	void Start () {
		if (ArtifactUp == Vector3.zero) {
			ArtifactUp = new Vector3(transform.position.x, transform.position.y + 0.85f, transform.position.z);
		}
	}

	// Update is called once per frame
	void Update () {
		if (_rising) {
			Transform Artifact = gameObject.transform.parent;
			Artifact.position = Vector3.Lerp(Artifact.position, ArtifactUp, Time.deltaTime * _riseRate);
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			_rising = true;
		}
	}
}
