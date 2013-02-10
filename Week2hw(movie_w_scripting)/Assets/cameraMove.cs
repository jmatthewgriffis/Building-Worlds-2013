using UnityEngine;
using System.Collections;

public class cameraMove : MonoBehaviour
{
	
	public float timer;
	public float wait;
	public bool move;
	public int moveState;
	
	// Use this for initialization
	void Start ()
	{
		moveState = 0;
		timer = 0;
		wait = 35 / Time.deltaTime;
		move = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (moveState == 0) {
			if (timer < wait) {
				timer++;
			} else {
				move = true;
				timer = 0;
				moveState = 1;
			}
		}
		else if (moveState == 1) {
			if (timer < wait*1.75) {
				timer++;
			} else {
				move = false;
				timer = 0;
				moveState = 2;
			}
		}
		
		if (move == true) {
			transform.position += new Vector3 (0f, 0f, 1.1f) * Time.deltaTime; 
		}
	}
}
