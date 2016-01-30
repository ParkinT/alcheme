using UnityEngine;
using System.Collections;

public class FallDamage : MonoBehaviour {

	public float MaxVelocityY = 18.5f;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();

	}

	// Update is called once per frame
	void Update () {
			double velocityFall = Mathf.Abs(rb.velocity.y);
		if (velocityFall  > MaxVelocityY) {
			gameObject.GetComponent<PlayerHealth>().Died();
		}
	}
}
