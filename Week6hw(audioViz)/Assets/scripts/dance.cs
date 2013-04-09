using UnityEngine;
using System.Collections;

public class dance : MonoBehaviour {
	
	float angle;
	int timer;
	
	float randNum;
	int convertRandNum;
	
	bool danceNow;
	bool angleChanged;

	// Use this for initialization
	void Start () {
		angle = 0;
		timer = 0;
		randNum = Random.Range(0,2);
		convertRandNum = (int) randNum;
		danceNow = false;
		angleChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		angle ++;
		timer ++;
		if (angle >= 360) {
			angle = 0;
		}
		
		//Debug.Log(timer);
		
		Vector3 vec = transform.localPosition;
		vec.z = -15 + (Mathf.Sin(angle)) * Time.deltaTime;
		
		if (convertRandNum == 0) {
			if (timer > 30) {
				if (angleChanged == false) {
				angle /= 2;
					angleChanged = true;
				}
				danceNow = true;
			};
		}
		
		else if (convertRandNum == 1) {
			if (timer > 70) {
				if (angleChanged == false) {
				angle *= 1.25f;
					angleChanged = true;
				}
				danceNow = true;
			};
		}
		
		else if (convertRandNum == 2) {
			if (timer > 120) {
				if (angleChanged == false) {
					angleChanged = true;
				}
				danceNow = true;
			};
		}
		
		if (danceNow == true) {
		transform.localPosition = vec;
		}
	}
}
