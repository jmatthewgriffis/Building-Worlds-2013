/* MATT EXPLANATORY NOTE: This is Robert's script, copied over from https://gist.github.com/radiatoryang/3ac9b7cd466157918efb. We're going over
 * it in class and I'm commenting things further for my own understanding. */


using UnityEngine;
using System.Collections;
using System.Collections.Generic; // MATT EXPLANATORY NOTE: Need this to use List.
 
// YOUR INDIVIDUAL SCENE SETUP WILL VARY
// code and values assume: the cursor can always raycast to something; there is 0 friction; Time.timeScale is slower, at like 0.2 or something
public class PoolVector : MonoBehaviour {
  
	public List<Vector3> trajectory = new List<Vector3>(); // MATT EXPLANATORY NOTE: ArrayList of Vector3s.
	
	bool aimingMode = false;
	Rigidbody ball;
	
	LineRenderer line;
	
	public Rigidbody ourBall; // assign in Inspector
 
	// Use this for initialization
	void Start () {
		line = GetComponent<LineRenderer>(); // cache reference to LineRenderer
	}
	
	// Update is called once per frame
	void Update () {
		// Simpler Input?
//		if (Input.GetKeyDown( KeyCode.LeftArrow ) )
//			ourBall.transform.Rotate(new Vector3(0f, -15f, 0f) );
//		
//		if (Input.GetKeyDown( KeyCode.RightArrow ) )
//			ourBall.transform.Rotate(new Vector3(0f, 15f, 0f) );
//		
//		if (Input.GetKeyDown( KeyCode.Space ) )
//			ourBall.AddForce( ourBall.transform.forward * 100000f );
		
		// Click and drag
		Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition ); // generate a ray based on our mousePosition
		// MATT EXPLANATORY NOTE: "camera.main" specifies the main camera since this is camera-dependent. It calls on the built-in main camera
		// function. "ScreenPointToRay" is the raycast function that asks for a vector3 to give direction. Input.mousePosition gives the x and y.
		
		RaycastHit rayHit = new RaycastHit(); // initialize the struct we'll need for rayHit later
		
		if ( Physics.Raycast( ray, out rayHit, 1000f ) ) { // did the raycast from our mousePosition hit something?
			// MATT EXPLANATORY NOTE: "ray" is the shooting object. "out" outputs the data from this raycast into the specified parameter,
			// in this case "rayHit." 1000f is the distance.
			if ( Input.GetMouseButton(0) ) { // is left mouse button pressed down?
				// MATT EXPLANATORY NOTE: we might put the check for mouseButton before the raycast to be more economical. Alternatively we
				// might want to raycast first if we were going to check for mouseHover or some such.
				if (rayHit.collider.tag == "Ball") { // the thing we hit -- is it tagged with "Ball"?
					aimingMode = true;
					ball = rayHit.collider.rigidbody; // MATT EXPLANATORY NOTE: Store the collided object in the "ball" variable.
				} else if (aimingMode) { // it wasn't the ball, but the player has clicked and dragged from the ball, so take an aiming vector
					// MATT EXPLANATORY NOTE: stating a boolean without a condition is shorthand for "true." Use an exclamation point in front for false.
					Vector3 levelRayHitPoint = new Vector3(rayHit.point.x, ball.transform.position.y, rayHit.point.z);
					CalculateTrajectory( ball.transform.position, (ball.transform.position - levelRayHitPoint).normalized );
					ShowTrajectory();
				}
			} else { // so then the left mouse button is UP?
				if (aimingMode) {
					Vector3 levelRayHitPoint = new Vector3(rayHit.point.x, ball.transform.position.y, rayHit.point.z);
					// MATT EXPLANATORY NOTE: pulling the ball's yPos is a workaround that takes the y-axis out of the equation to avoid wonky physics.
					ball.AddForce( (ball.transform.position - levelRayHitPoint).normalized * 10000f); // I multiply force by 10000 for testing purposes; but ideally we should (a) do this in FixedUpdate() and (b) take length of the line as force 
					// MATT EXPLANATORY NOTE: subtract the ball's pos from the ray source because we want to calculate the vector heading towards the ball.
				}
				// go to Edit > Project Settings > Time and set Fixed Time Step to something small (0.05)
				// and set Time Scale to something slow (0.2) or 20% of regular time speed.
				
				aimingMode = false; // mouse button was released + ball launched, so turn off aimingMode
			}
		} else { // raycast didn't hit anything
			aimingMode = false;
		}
	}
}
 
// SNIP! CalculateTrajectory() and ShowTrajectory() are missing, we'll go over them in class