using UnityEngine;
using System.Collections;

public class makeBoxFall : MonoBehaviour {
	
	// Use this to make a public reference field for another game object
	public GameObject cubeCrush;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	// When a collider hits the object with this script, add a rigidbody to
	// the cubeCrush object. This causes it to fall! Success!
	void OnTriggerEnter(Collider other) {
        cubeCrush.AddComponent("Rigidbody");
    }
}
