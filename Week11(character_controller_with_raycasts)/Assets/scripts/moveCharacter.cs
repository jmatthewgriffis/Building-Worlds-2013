using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour {
	
	bool allowJump;
	float capsuleRad;
	public float moveSpeed;
	public float turnRate;
	float yPos;
	float yVel;
	public float gravity;
	public float maxJump;
	Vector3 origin;
	float abyss;

	// Use this for initialization
	void Start () {
		capsuleRad = 0.5f;
		moveSpeed = 3.0f;
		turnRate = 125.0f;
		yPos = 0;
		yVel = 0;
		gravity = -0.5f;
		maxJump = 15f;
		origin = new Vector3(0,10,0);
		abyss = -10;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y < abyss) transform.position = origin; // If you fall off the edge, warp back to the beginning.
		
		#region GRAVITY
        if (!Physics.Raycast(transform.position, -transform.up, 1f) && yVel == 0) { // Shoot a raycast downward; if it doesn't hit anything within 1 distance and we're not jumping...
			transform.position += Physics.gravity * Time.deltaTime; // ...move downward with gravity.
    	}
		#endregion
		
		#region MOVING // This lets you collapse certain code sections easily.
		bool capsuleCastHitWall = Physics.CapsuleCast(transform.position + transform.up, // Top of capsule
			transform.position - transform.up, // Bottom of capsule
			capsuleRad, // Radius of capsule
			transform.forward, // Direction of raycast
			1f); // Range
		if (Input.GetKey(KeyCode.W) && !capsuleCastHitWall) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += transform.forward * moveSpeed * Time.deltaTime; // Move forward if there's no wall.
		}
		bool capsuleCastHitWallBehind = Physics.CapsuleCast(transform.position + transform.up, // Top of capsule
			transform.position - transform.up, // Bottom of capsule
			capsuleRad, // Radius of capsule
			-transform.forward, // Direction of raycast
			1f); // Range
		if (Input.GetKey(KeyCode.S) && !capsuleCastHitWallBehind) {
			transform.position += -transform.forward * moveSpeed * Time.deltaTime; // Move backward if there's no wall.
		}
		#endregion
		
		#region JUMPING.
		if (yVel >= 0) yVel += gravity; // Update yVel with gravity to deplete it the higher the jump gets.
		if (yVel <= 0) yVel = 0; // Set yVel to zero if it gets too small.
		
		transform.position += new Vector3(0, yVel, 0) * Time.deltaTime; // Jump if on a surface and there's nothing overhead.
		
		if (Input.GetKey(KeyCode.J) && allowJump == true && Physics.Raycast(transform.position, -transform.up, 1f)) {
			yVel = maxJump;
			allowJump = false;
		}
		else if (!Input.GetKey(KeyCode.J)) {
			yVel = 0;
			if (Physics.Raycast(transform.position, -transform.up, 1f)) allowJump = true;
		}
		if (Physics.Raycast(transform.position, transform.up, 1.0f)) yVel = 0;
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
