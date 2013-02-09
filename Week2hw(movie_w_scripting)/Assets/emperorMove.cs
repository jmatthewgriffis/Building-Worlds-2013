using UnityEngine;
using System.Collections;

public class emperorMove : MonoBehaviour
{
	
	public float speed = 7f;
	public int timer = 0; // This controls when the movement boolean switches on.
	public bool move = false; // This controls when the emperor moves.
	public int moveState;
	public float wait = 3; // This is how long the emperor waits before moving.
	
	// Use this for initialization
	void Start ()
	{
		moveState = 0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Cue initial movement.
		if (moveState == 0) {
			if (timer < wait / Time.deltaTime) {
				timer++;
			} else {
				move = true;
				timer = 0;
				moveState = 1;
			}
		}
		// Limit initial movement.
		else if (moveState == 1) {
			if (timer < (wait / Time.deltaTime)) {
				timer++;
			} else {
				move = false;
				timer = 0;
				moveState = 2;
			}
		}
		else if (moveState == 2) {
			if (timer < (wait / Time.deltaTime)*2.25) {
				timer++;
			} else {
				move = true;
				timer = 0;
				moveState = 3;
			}
		}
		else if (moveState == 3) {
			if (timer < (wait / Time.deltaTime)*0.3) {
				timer++;
			} else {
				move = false;
				timer = 0;
				moveState = 4;
			}
		}
		else if (moveState == 4) {
			if (timer < (wait / Time.deltaTime)) {
				timer++;
			} else {
				move = true;
				timer = 0;
				moveState = 5;
			}
		}
		
		
		//Debug.Log (timer);
		
		if (move == true) {
			if (moveState < 5) {
			transform.position += new Vector3 (0f, Mathf.Sin (Time.time * speed), 0f) * Time.deltaTime;
			}
			else {
				transform.position += new Vector3 (0f, 0.25f, 0f) * Time.deltaTime;
			}
		}
	}
}
