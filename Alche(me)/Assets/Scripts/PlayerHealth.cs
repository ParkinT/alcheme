// A centralized place - attached to the Player Controller - where we can track and respond to player health and well-being
﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int MaxHealth = 100;
	public float DiseaseInterval = 1;  //number of points per second you lose
	public bool InDarkness = false;  // while in darkness health is being depleted
	private int currentHealth;
	private float _deltaTimeTotal = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		currentHealth = System.Convert.ToInt32(MaxHealth - Time.timeSinceLevelLoad);
		if (Application.loadedLevelName == "Main")
			currentHealth = MaxHealth;

			//the code below works but this code (above) is simpler
		/*
		if (!InDarkness)
			return;  // quick check and jump out - to improve performance

		if (_deltaTimeTotal >= 1.0f) {  // a second (at least) has passed
			_deltaTimeTotal = 0;  // reset for next calculation
			Reduce(1);
		}
		_deltaTimeTotal += Time.deltaTime;
		*/
	}

	void Awake() {
		currentHealth = MaxHealth;
		// Default - wipe all entries
		PlayerPrefs.SetString("artifact", string.Empty);
		PlayerPrefs.SetInt("health", MaxHealth);
	}

	public int Reduce(int amt) {
		currentHealth -= Mathf.Abs(amt);
		return currentHealth;
	}

	public int Revive() {
		currentHealth = MaxHealth;
		return currentHealth;
	}

	public bool IsAlive() {
		return (currentHealth > 1);
	}

	public void Died() {
		PlayerInventory playerInv = gameObject.GetComponent<PlayerInventory>();
		playerInv.DropAll();
		PlayerPrefs.SetInt("health", MaxHealth);   //initialize for reload
		SceneManager.LoadScene("Main");
	}
}
