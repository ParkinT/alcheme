using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {

	public float MaxVelocityY = 18.5f;
	private Rigidbody rb;
	private bool playerHasDied = false;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update () {
			double velocityFall = Mathf.Abs(rb.velocity.y);
		if (velocityFall  > MaxVelocityY) {
		}
		if (playerHasDied && velocityFall < 1.5f) {  // delay the death until we hit the ground
			gameObject.GetComponent<PlayerHealth>().Died();
		}
	}
}
