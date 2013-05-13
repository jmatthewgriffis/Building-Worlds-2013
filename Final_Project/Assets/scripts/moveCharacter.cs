using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour {
	
	bool allowJump;
	float capsuleRad;
	public float moveSpeed;
	public float turnRate;
	float yVel;
	public float gravity;
	public float maxJump;
	Vector3 origin;
	float abyss;
	public float triggerGrav;
	float capsuleHeight;
	Vector3 headCtr;

	// Use this for initialization
	void Start () {
		capsuleRad = 0.75f;
		headCtr = new Vector3(0,capsuleRad,0);
		capsuleHeight = 4.5f;
		moveSpeed = 10f;
		turnRate = 125.0f;
		yVel = 0;
		gravity = -0.5f;
		maxJump = 25f;
		origin = new Vector3(0,30,0);
		abyss = -20;
		triggerGrav = 0.25f;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (transform.position.y < abyss) transform.position = origin; // If you fall off the edge, warp back to the beginning.
		
		#region GRAVITY
        if (!Physics.Raycast(transform.position, -transform.up, triggerGrav) && yVel == 0) { // Shoot a raycast downward; if it doesn't hit anything within 1 distance and we're not jumping...
			transform.position += Physics.gravity * Time.deltaTime; // ...move downward with gravity.
    	}
		#endregion
		
		#region MOVING // This lets you collapse certain code sections easily.
		
		/*Vector3 p1 = transform.position + transform.up * capsuleHeight/2; // Top of capsule
		Vector3 p2 = transform.position - transform.up * capsuleHeight/2; // Bottom of capsule*/
		Vector3 p1 = transform.position+transform.up*0.9f; // Center of torso
		Vector3 p2 = transform.position + transform.up + headCtr; // Center of head
		
		/*bool capsuleCastHitWall = Physics.CapsuleCast(p1, p2, capsuleRad, transform.forward, capsuleRad);
		if (Input.GetKey(KeyCode.W) && !capsuleCastHitWall) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += transform.forward * moveSpeed * Time.deltaTime; // Move forward if there's no wall.
		}*/
		RaycastHit torsoHit;
		bool torsoSphereCastHitWall = Physics.SphereCast(p1, capsuleRad, transform.forward, out torsoHit, capsuleRad);
		if (Input.GetKey(KeyCode.W) && !torsoSphereCastHitWall) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += transform.forward * moveSpeed * Time.deltaTime; // Move forward if there's no wall.
		}
		RaycastHit headHit;
		bool headSphereCastHitWall = Physics.SphereCast(p2, capsuleRad, transform.forward, out headHit, capsuleRad);
		if (Input.GetKey(KeyCode.W) && !headSphereCastHitWall) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += transform.forward * moveSpeed * Time.deltaTime; // Move forward if there's no wall.
		}
		/*bool capsuleCastHitWallBehind = Physics.CapsuleCast(p1, p2, capsuleRad, -transform.forward, capsuleRad);
		if (Input.GetKey(KeyCode.S) && !capsuleCastHitWallBehind) {
			transform.position += -transform.forward * moveSpeed * Time.deltaTime; // Move backward if there's no wall.
		}*/
		RaycastHit torsoHitBehind;
		bool torsoSphereCastHitWallBehind = Physics.SphereCast(p1, capsuleRad, -transform.forward, out torsoHitBehind, capsuleRad);
		if (Input.GetKey(KeyCode.S) && !torsoSphereCastHitWallBehind) {
			transform.position += -transform.forward * moveSpeed * Time.deltaTime; // Move backward if there's no wall.
		}
		RaycastHit headHitBehind;
		bool headSphereCastHitWallBehind = Physics.SphereCast(p2, capsuleRad, -transform.forward, out headHitBehind, capsuleRad);
		if (Input.GetKey(KeyCode.W) && !headSphereCastHitWallBehind) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += -transform.forward * moveSpeed * Time.deltaTime; // Move forward if there's no wall.
		}
		#endregion
		
		/*Debug.DrawRay(p1,transform.forward,Color.red);
		Debug.DrawRay(p2,transform.forward,Color.green);*/
		
		#region JUMPING.
		if (yVel >= 0) yVel += gravity; // Update yVel with gravity to deplete it the higher the jump gets.
		if (yVel <= 0) yVel = 0; // Set yVel to zero if it gets too small.
		
		transform.position += new Vector3(0, yVel, 0) * Time.deltaTime; // Jump if on a surface and there's nothing overhead.
		
		if (Input.GetKey(KeyCode.J) && allowJump == true && Physics.Raycast(transform.position, -transform.up, triggerGrav)) {
			yVel = maxJump;
			allowJump = false;
		}
		else if (!Input.GetKey(KeyCode.J)) {
			yVel = 0;
			if (Physics.Raycast(transform.position, -transform.up, triggerGrav)) allowJump = true;
		}
		if (Physics.Raycast(transform.position + new Vector3(0,capsuleHeight/3,0), transform.up, 1.0f)) yVel = 0;
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
	/*void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position+transform.up*0.9f, capsuleRad);
		Gizmos.color = Color.blue;
		Gizmos.DrawSphere(transform.position + transform.up + new Vector3(0,capsuleRad,0), capsuleRad);
    }*/
}
