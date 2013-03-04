using UnityEngine;
using System.Collections;

public class flyer : MonoBehaviour {
	
	//public Vector3 target;
	public float timeToReachTarget = 5f;
	// "Transform" lets us assign another object to give coordinate information to this script.
	public Transform Jedi; // Use to track the Jedi's position.
	public Transform Stormtrooper; // Use to track the stormtrooper's position.
	public GameObject StormtrooperHit; // Use to destroy the stormtrooper.
	Transform WhatsMyTarget;
	bool towardsJedi;
	
	public lineLogger refLineScript; // Use this to refer to functions in this script via another script.
	
	// Use this for initialization
	void Start () {
		towardsJedi = true;
		// "Invoke" lets you control when a coroutine starts, while "InvokeRepeating" lets you call the coroutine repeatedly.
		//Invoke ("StartMoving", 2f);
		// First number is delay before first call; second number is interval thereafter between calls.
		InvokeRepeating("StartMoving", 1f, 6f);
	}
	
	void StartMoving () {
		// Move towards the target (the source of the Transform above):
		StartCoroutine( StartMove(WhatsMyTarget, timeToReachTarget) );
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("towardsJedi=" + towardsJedi + "; whatsmytarget=" + WhatsMyTarget);
		
		if (towardsJedi == true) {
			WhatsMyTarget = Jedi;
		}
		else {
			WhatsMyTarget = Stormtrooper;
		}
	}
	
	// If the projectile hits a target, reverse direction:
	void OnTriggerEnter(Collider other) {
		//refLineScript.pastPositions.RemoveRange(0,refLineScript.numLines); // I thought this would help resolve a speed
		// issue but it ended up delaying the rebound of the laser! Commented out.
		/*if (WhatsMyTarget == Stormtrooper) {
			Destroy(StormtrooperHit);
		}*/
		Debug.Log("collision!");
        towardsJedi = !towardsJedi;
	}
	
	// Trying Coroutines again. They are good because their entire action doesn't complete in one frame, so you can
	// run an action for a limited amount of time without completing the full cycle every frame. 
	IEnumerator StartMove (Transform destination, float duration) {
		float t=0f;
		Vector3 start = transform.position;
		
		while (t < 1f) {
			t += Time.deltaTime / duration;
			
			// "Lerp" is "linear interpolate." It allows smooth movement. The first number is the starting point,
			// the next number is the ending point, and the third number is the progress along the path between the two.
			// This third value only takes "normalized" numbers, i.e. it must be between 0 and 1. This is why we set the
			// while loop to run only when t < 1.
			transform.position = Vector3.Lerp(start, destination.position, t);
			
			// "Yield" is unique to coroutines and tells them to wait a certain amount of time. "Return" tells the
			// function to expect a certain value, in this case 1 frame.
			yield return 0;
			//alt. would be "yield return new WaitForSeconds(2f)" or some such.
		}
	}
}
