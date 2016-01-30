using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelTeleport : MonoBehaviour {

	public string JumpToLevel = "Ego";
	private static ILogger logger = Debug.logger;

	// Use this for initialization
	void Start () {

		if (string.IsNullOrEmpty(JumpToLevel)) {
			logger.LogError("Level", "Naming Error");
		}
		System.Globalization.TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;
		JumpToLevel = textInfo.ToTitleCase(JumpToLevel);
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			SceneManager.LoadScene(JumpToLevel);
		}
		// else - nothing
	}
}
