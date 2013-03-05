using UnityEngine;
using System.Collections;

public class useCue : MonoBehaviour {
	
	//public GameObject ball;
	//public Vector3 moveBall = new Vector3(10,0,0);
	
	Vector3 cuePos;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		cuePos
			//Input(mousePos);
		
		transform.position = Input.mousePosition;
		
		if (Input.GetMouseButton(0)) {
			Debug.Log("Pressed!");
			//ball.transform.position = transform.forward;
		}
	}
}