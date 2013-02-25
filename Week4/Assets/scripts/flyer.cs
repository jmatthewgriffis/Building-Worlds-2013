using UnityEngine;
using System.Collections;

public class flyer : MonoBehaviour {
	
	Vector3 target;
	float targetRange = 10f;
	
	// Use this for initialization
	void Start () {
		SetNewTarget();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += ;
	}
	
	void SetNewTarget() {
		target = new Vector3 ( Random.Range(-targetRange, targetRange), Random.Range(-targetRange, targetRange), Random.Range(-targetRange, targetRange) );
	}
}
