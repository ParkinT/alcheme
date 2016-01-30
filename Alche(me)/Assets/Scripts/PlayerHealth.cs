// A centralized place - attached to the Player Controller - where we can track and respond to player health and well-being
﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int MaxHealth = 100;
	private int currentHealth;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void Awake() {
		currentHealth = MaxHealth;
		// Default - wipe all entries
		PlayerPrefs.SetString("artifact", string.Empty);
		PlayerPrefs.SetInt("health", MaxHealth);
	}

	public int Reduce(int amt) {
		currentHealth -= Mathf.Abs(amt);
	}

	public int Revive() {
		currentHealth = MaxHealth;
	}

	public void Died() {
		PlayerInventory playerInv = gameObject.GetComponent<PlayerInventory>();
		playerInv.DropAll();
		PlayerPrefs.SetInt("health", MaxHealth);   //initialize for reload
		SceneManager.LoadScene("Main");
	}
}
