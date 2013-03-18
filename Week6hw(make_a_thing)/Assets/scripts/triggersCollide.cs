using UnityEngine;
using System.Collections;

public class triggersCollide : MonoBehaviour {
	
	// A simple script to destroy an object when two objects collide.
	
	public GameObject Jedi; // Make external reference to a different object.
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localPosition = new Vector3(0,-0.6f,0); // This script is attached to a child object, whose local position is relative to
		// the parent's position. We want the child to move with the parent and stay in the same relative position so we use this transform command.
	}
	
	void OnTriggerEnter(Collider other) {
		//Debug.Log("destroy!");
		Destroy(Jedi); // If the object with this script collides with the other object, destroy that other object.
	}
}
