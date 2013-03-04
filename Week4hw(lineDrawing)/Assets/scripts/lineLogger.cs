using UnityEngine;
using System.Collections;
// This next line lets us import tools that include the list (arrayList):
using System.Collections.Generic;

public class lineLogger : MonoBehaviour {
	
	public List<Vector3> pastPositions = new List<Vector3>(); // Make this public so the other script can make reference to it.
	
	LineRenderer lineRenderer;
	
	public int numLines = 30;

	// Use this for initialization
	void Start () {
		
		lineRenderer = GetComponent<LineRenderer>(); // Grab reference to LineRenderer.
		
		InvokeRepeating("RecordPosition", 0f, 0.1f); // Call RecordPosition() every 2 seconds after an initial delay of 0 seconds.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void RecordPosition() { // Make this function public so the other script can make reference to it.
		pastPositions.Add( transform.position ); // Add our current position to our list of past positions.
		// We don't want the trail to be retained forever, so let's delete older elements as we go:
		if (pastPositions.Count > numLines) { // If there are more than x elements...
			pastPositions.RemoveAt(0); // ...delete the first (oldest) one.
		}
		
		lineRenderer.SetVertexCount ( pastPositions.Count );
		for (int i = 0; i < pastPositions.Count; i++) {
			lineRenderer.SetPosition( i, pastPositions[i] );
		}
	}
}
