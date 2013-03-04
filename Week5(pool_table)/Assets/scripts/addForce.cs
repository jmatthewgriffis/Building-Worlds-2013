using UnityEngine;
using System.Collections;

public class addForce : MonoBehaviour {
	
	public GameObject ball;
	public Vector3 moveBall = new Vector3(10,0,0);
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0)) {
			Debug.Log("Pressed!");
			ball.transform.position = transform.forward;
		}
	}
}
