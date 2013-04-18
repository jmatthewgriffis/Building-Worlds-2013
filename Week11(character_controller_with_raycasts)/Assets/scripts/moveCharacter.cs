using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour {
	
	public float moveSpeed;
	public float turnRate;

	// Use this for initialization
	void Start () {
		
		moveSpeed = 3.0f;
		turnRate = 125.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		#region GRAVITY
        if (!Physics.Raycast(transform.position, -transform.up, 1f)) { // Shoot a raycast downward; if it doesn't hit anything within 1 distance...
            transform.position += Vector3.down * moveSpeed * Time.deltaTime; // ...move downward ala gravity.
    	}
		#endregion
		
		#region MOVING // This lets you collapse certain code sections easily.
		bool capsuleCastHitWall = Physics.CapsuleCast(transform.position + transform.up, // Top of capsule
			transform.position - transform.up, // Bottom of capsule
			0.5f, // Radius of capsule
			transform.forward, // Direction of raycast
			1f); // Range
		if (Input.GetKey(KeyCode.W) && !capsuleCastHitWall) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		bool capsuleCastHitWallBehind = Physics.CapsuleCast(transform.position + transform.up, // Top of capsule
			transform.position - transform.up, // Bottom of capsule
			0.5f, // Radius of capsule
			-transform.forward, // Direction of raycast
			1f); // Range
		if (Input.GetKey(KeyCode.S) && !capsuleCastHitWallBehind) {
			transform.position += -transform.forward * moveSpeed * Time.deltaTime;
		}
		#endregion
		
		#region TURNING // This lets you collapse certain code sections easily.
		
		if (Input.GetKey(KeyCode.A)) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.Rotate(Vector3.up * -turnRate * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.D)) {
			transform.Rotate(Vector3.up * turnRate * Time.deltaTime);
		}
		#endregion
	}
}
