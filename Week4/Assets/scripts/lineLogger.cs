using UnityEngine;
using System.Collections;
// This next line lets us import tools that include the list (arrayList):
using System.Collections.Generic;

public class lineLogger : MonoBehaviour {
	
	List<Vector3> pastPositions = new List<Vector3>();
	
	LineRenderer lineRenderer;

	// Use this for initialization
	void Start () {
		
		lineRenderer = GetComponent<LineRenderer>(); // Grab reference to LineRenderer.
		
		InvokeRepeating("RecordPosition", 0f, 2f); // Call RecordPosition() every 2 seconds after an initial delay of 0 seconds.
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void RecordPosition() {
		pastPositions.Add( transform.position ); // Add our current position to our list of past positions.
		
		lineRenderer.SetVertexCount ( pastPositions.Count ); // .Length for array, .Count for list.
		for (int i = 0; i < pastPositions.Count; i++) {
			lineRenderer.SetPosition( i, pastPositions[i] );
		}
	}
}
