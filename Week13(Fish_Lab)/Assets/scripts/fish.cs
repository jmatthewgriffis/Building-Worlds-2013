using UnityEngine;
using System.Collections;

public class fish : MonoBehaviour {
	
	Vector3 destination;
	public float speed = 200f;
	public float stoppingDistance = 1f;
	
	// Use this for initialization
	void Start () {
		
		SetNewDestination();
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// Quaternion.LookRotation takes any Vector3 forward vector convert to crazy Quaternion format we need:
		// (In other words, this makes the fish face the direction of movement.)
		transform.rotation = Quaternion.LookRotation(rigidbody.velocity);
	
	}
	
	// FixedUpdate for physics:
	// (FixedUpdate is a function Unity recognizes, and it runs at a different rate than the regular Update function.)
	void FixedUpdate() {
		
		// Apply a physics force in the direction of our destination. According to vector math, subtract B - A. B is the destination and A is the
		// current position. This will be a force so we need to normalize.
		rigidbody.AddForce( (destination - transform.position).normalized * Time.fixedDeltaTime * speed, ForceMode.Force );
		
		if (Vector3.Distance( transform.position, destination ) < stoppingDistance) {
			
			SetNewDestination();
			
		}
		
	}
	
	// Function overload is confusing but awesome. We create multiple ways to call the same function with different levels of detail.
	// Furthermore we can feed them into each other. Then if we make a change higher up it cascades into the lower versions, ala CSS.
	
	// Set "destination" to a random point inside an imaginary sphere of radius ______:
			
	void SetNewDestination() {
		
		SetNewDestination(10f);
		
	}
	
	void SetNewDestination( float range ) {
		
		SetNewDestination(Random.insideUnitSphere * range);
		
	}
	
	void SetNewDestination( Vector3 newDestination ) {
		
		destination = newDestination;
	
	}
}
