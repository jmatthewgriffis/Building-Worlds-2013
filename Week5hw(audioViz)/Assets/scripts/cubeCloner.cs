using UnityEngine;
using System.Collections;
using System.Collections.Generic; // This is necessary to use Lists.

public class cubeCloner : MonoBehaviour
{
	
	// Let's use scripting to generate objects. In Unity we created an empty gameObject and attached this script to it.
	
	// We have a script called flyer; let's make a slot to associate a prefab with that script to this script.
	/*public flyer cubePrefab;
	public List<flyer> myFlyers = new List<flyer>();
	public int cubeCount = 10;*/

	// Use this for initialization
	void Start ()
	{
		
		// It's necessary to use Instantiate because Unity is built on top of MonoDevelop; otherwise we could just use a constructor.
		// "Vector3.zero" is shorthand for "Vector3(0,0,0)."
		/*for (int i = 0; i < cubeCount; i++) {
			flyer tempFlyer = Instantiate (cubePrefab, Vector3.zero, Quaternion.identity) as flyer;
			myFlyers.Add(tempFlyer); // Add the temp object to the list.
			tempFlyer.speed = i;
			tempFlyer.SetNewTarget();*/
		}
	
	}
	
	// Update is called once per frame
	/*void Update ()
	{
		//Debug.Log(myFlyers.Count);
		
		
	}*/

//}
