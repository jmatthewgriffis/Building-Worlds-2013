using UnityEngine;
using System.Collections;

public class flyer : MonoBehaviour {
	
	// This script causes the projectile to fly towards the Jedi, then causes the Jedi to move backwards then forwards again as the projectile
	// reverses direction towards the stormtrooper, then destroys the stormtrooper and the projectile. I spent some time adding in scripting to
	// make the Jedi move up and down in a victory dance and then I realized it's pointless because the script gets destroyed along with the
	// stormtrooper object. I'd need to do separate scripting on another object to achieve that particular goal.
	
	
	
	//public Vector3 target;
	public float timeToReachTarget = 5f;
	// "Transform" lets us assign another object to give coordinate information to this script.
	public Transform Jedi; // Use to track the Jedi's position.
	public Transform Stormtrooper; // Use to track the stormtrooper's position.
	public GameObject StormtrooperHit; // Use to destroy the stormtrooper.
	public GameObject JediHit; // Use to move the Jedi.
	public GameObject Self; // Use to destroy the projectile itself.
	Transform WhatsMyTarget;
	bool towardsJedi;
	bool addToTimer;
	bool addToOtherTimer;
	int timer;
	int otherTimer;
	float bounceLaser;
	float returnPos;
	bool dontMove;
	int timerLimit;
	int angle;
	bool addAngle;
	//float moveY;
	
	public lineLogger refLineScript; // Use this to refer to functions in this script via another script.
	
	// Use this for initialization
	void Start () {
		towardsJedi = true;
		addToTimer = false;
		timer = 0;
		addToOtherTimer = false;
		otherTimer = 0;
		// "Invoke" lets you control when a coroutine starts, while "InvokeRepeating" lets you call the coroutine repeatedly.
		//Invoke ("StartMoving", 2f);
		// First number is delay before first call; second number is interval thereafter between calls.
		InvokeRepeating("StartMoving", 1f, 6f);
		bounceLaser = 1.5f;
		returnPos = 0.53f;
		dontMove = false;
		timerLimit = 95;
		angle = 0;
		addAngle = false;
		//moveY = 0;
	}
	
	void StartMoving () {
		// Move towards the target (the source of the Transform above):
		StartCoroutine( StartMove(WhatsMyTarget, timeToReachTarget) );
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("towardsJedi=" + towardsJedi + "; whatsmytarget=" + WhatsMyTarget);
		//Debug.Log(otherTimer);
		//Debug.Log(angle);
		
		if (towardsJedi == true) {
			WhatsMyTarget = Jedi;
		}
		else {
			WhatsMyTarget = Stormtrooper;
		}
		
		if (addToTimer == true) {
			timer ++;
		}
		
		if (timer >= timerLimit) {
				Destroy(StormtrooperHit);
				Destroy(Self);
			addAngle = true;
			}
		
		if (addAngle == true) {
		angle ++;
			//moveY = Mathf.Sin(angle);
			//moveY = 5f;
			//JediHit.transform.position = new Vector3(JediHit.transform.position.x, moveY, JediHit.transform.position.z);
		}
			if (angle >= 360) {
				angle = 0;
			}
		
		if (addToOtherTimer == true && otherTimer < timerLimit + 20) {
			otherTimer ++;
		}
		
		if (otherTimer >= timerLimit + 20 && addToOtherTimer == true) {
			JediHit.transform.position = new Vector3(JediHit.transform.position.x, JediHit.transform.position.y, returnPos);
			addToOtherTimer = false;
			}
	}
	
	// If the projectile hits a target, reverse direction:
	void OnTriggerEnter(Collider other) {
		//refLineScript.pastPositions.RemoveRange(0,refLineScript.numLines); // I thought this would help resolve a speed
		// issue but it ended up delaying the rebound of the laser! Commented out.
		if (WhatsMyTarget == Jedi) {
			if (dontMove == false) {
			other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, bounceLaser);
				dontMove = true;
			}
			addToOtherTimer = true;
		}
		if (WhatsMyTarget == Stormtrooper) {
			addToTimer = true;
		}
		//Debug.Log("collision!");
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
