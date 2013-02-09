using UnityEngine;
using System.Collections;

public class troopersMove : MonoBehaviour
{
	
	// Highlight any code and hit Command+' to pull up the Unity reference materials.
	
	// Labeling these variables as "public" is important because it exposes them to the Inspector in Unity, to be edited on the fly there.
	// "f" indicates a float.
	public float speed = 7f; // This limits the height of the trooper's bounce (the higher the number, the lower they bounce).
	public int timer = 0; // This controls when the movement boolean switches on.
	public bool move = false; // This controls when the troopers move.
	public float wait = 15; // This is how long the troopers wait before moving.
	
	// Update is called once per frame
	void Update ()
	{
		if (timer < wait / Time.deltaTime) {
			timer++;
		}
		else {
			move = true;
		}
		
		//Debug.Log (timer);
		
		if (move == true) {
			// This first script moves the cubes upward by transforming the y-pos.
			// Time.deltaTime is the interval between frames. This way the movement is proportionally consistent regardless of frame rate.
			// Now use math to make the cubes bounce. Adjust the y-pos based on the sin of time passed.
			transform.position += new Vector3 (0f, Mathf.Sin (Time.time * speed), 0f) * Time.deltaTime;
			// What if you want to move a cube whatever direction is currently forward for it (presumably there's rotation)? Use this specialized Vector3:
			transform.localPosition += transform.forward * Time.deltaTime;
		}
	}
}
