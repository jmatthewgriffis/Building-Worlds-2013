using UnityEngine;
using System.Collections;

public class emperorMove : MonoBehaviour {
	
	public float speed = 7f;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (0f, Mathf.Sin (Time.time * speed), 0f) * Time.deltaTime;
	}
}
