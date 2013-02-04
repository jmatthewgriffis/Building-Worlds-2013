using UnityEngine;
using System.Collections;

public class cubeMove : MonoBehaviour {
	
	// Highlight any code and hit Command+' to pull up the Unity reference materials.
	
	// Labeling these variables as "public" is important because it exposes them to the Inspector in Unity, to be edited on the fly there.
	// "f" indicates a float.
	public float speed = 2f;
	public float distance = 2f;

	// Use this for initialization
	void Start () {
		StartCoroutine(movie() );
	}
	
	// Update is called once per frame
	void Update () {
		// This first script moves the cubes upward by transforming the y-pos.
		// Time.deltaTime is the interval between frames. This way the movement is proportionally consistent regardless of frame rate.
		//transform.position += new Vector3 (0f, speed, 0f) * Time.deltaTime;
		
		// Now use math to make the cubes bounce. Adjust the y-pos based on the sin of time passed. Don't need to multiply by Time.deltaTime.
		//transform.position += new Vector3 (0f, Mathf.Sin(Time.time * speed), 0f) * Time.deltaTime * distance;
		
		// For rotation, Unity stores information in quaternions instead of vectors. Easily convert by using "eulerAngles" like so:
		//transform.rotation.eulerAngles += new Vector3 (0f, 1f, 0f) * Time.deltaTime; //Doesn't work?
		
		//transform.Rotate (new Vector3 (0f, 10f, 0f) * Time.deltaTime);
		
		//transform.localScale += new Vector3 (Mathf.Cos(Time.time), Mathf.Sin(Time.time), Mathf.Tan(Time.time)) * Time.deltaTime;
		
		// What if you want to move a cube whatever direction is currently forward for it (presumably there's rotation)? Use this specialized Vector3:
		//transform.localPosition += transform.forward * Time.deltaTime;
		//Debug.Log(transform.forward);
	}
	
	// Use a "co-routine" to control the order of script actions. Easier than using "if" statements.
	IEnumerator movie () { // Don't worry about what this is.
		while(true) {
			// "Yield" is a special command only available in the IEnumerator.
			yield return new WaitForSeconds(1f);
			transform.localPosition += transform.forward;
		}
	}
}
