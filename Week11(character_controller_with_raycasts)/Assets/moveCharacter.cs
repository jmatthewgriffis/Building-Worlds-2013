using UnityEngine;
using System.Collections;

public class moveCharacter : MonoBehaviour {
	
	float moveSpeed;
	float turnRate;

	// Use this for initialization
	void Start () {
		
		moveSpeed = 3.0f;
		turnRate = 50.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		#region GRAVITY
        if (!Physics.Raycast(transform.position, -transform.up, 1f)) {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
    	}
		#endregion
		
		#region MOVING // This lets you collapse certain code sections easily.
		bool capsuleCastHitWall = Physics.CapsuleCast(transform.position + transform.up,
			transform.position - transform.up,
			0.5f,
			transform.forward,
			1f);
		if (Input.GetKey(KeyCode.W) && !capsuleCastHitWall) { // Use GetKey so it refreshes every frame (as oppoosed to GetKeyDown).
			transform.position += transform.forward * moveSpeed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.S)) {
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
