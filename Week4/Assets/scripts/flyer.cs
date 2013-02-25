using UnityEngine;
using System.Collections;

public class flyer : MonoBehaviour {
	
	public float speed = 5f;
	Vector3 target;
	public float targetRange = 10f;
	
	// Use this for initialization
	void Start () {
		
		SetNewTarget();
	}
	
	// Update is called once per frame
	void Update () {
		
		// When working with vector math it's useful to normalize the vector, which means dividing it by its magnitude to reduce all
		// vectors to a magnitude of 1, if I understand this correctly:
		//transform.position += Vector3.Normalize(target - transform.position) * Time.deltaTime * speed;
		
		// Here is an alternate, shorthand way to do it (since the program knows the content in parentheses is a Vector 3:
		transform.position += (target - transform.position).normalized * Time.deltaTime * speed;
		
		// Have we reached our destination?
		if ( (target - transform.position).magnitude < 0.1f) {
			SetNewTarget(); // ...Then set a new target.
		}
	}
	
	public void SetNewTarget() {
		
		target = new Vector3 ( Random.Range(-targetRange, targetRange), Random.Range(-targetRange, targetRange), Random.Range(-targetRange, targetRange) );
	}
}
