using UnityEngine;
using System.Collections;

public class moveCam : MonoBehaviour {
	
	public int camPos;
	Vector3 pos0 = new Vector3(66.3f,2.0f,919.4f);//
	Vector3 pos1 = new Vector3(994.4f,2.4f,895.2f);//
	Vector3 pos2 = new Vector3(994.4f,2.4f,810.3f);//
	Vector3 pos3 = new Vector3(994.4f,2.4f,773.5f);//
	Vector3 pos4 = new Vector3(997.2f,2.4f,754.9f);//
	Vector3 pos5 = new Vector3(997.4f,2.4f,733.9f);//
	Vector3 pos6 = new Vector3(997.2f,2.4f,698.3f);//
	//Vector3 pos7 = new Vector3(994.4f,2.4f,895.2f);
	

	// Use this for initialization
	void Start () {
		camPos = 0;

	}
	
	// Update is called once per frame
	void Update () {
		 if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            if (camPos > 0) {
			camPos--;
			}
		}
			else if (Input.GetKeyDown(KeyCode.RightArrow)) {
            if (camPos < 6) {
			camPos++;
			}
		}
		if (camPos == 0) {
			transform.position = pos0;
		}
		else if (camPos == 1) {
			transform.position = pos1;
		}
		else if (camPos == 2) {
			transform.position = pos2;
		}
		else if (camPos == 3) {
			transform.position = pos3;
		}
		else if (camPos == 4) {
			transform.position = pos4;
		}
		else if (camPos == 5) {
			transform.position = pos5;
		}
		else if (camPos == 6) {
			transform.position = pos6;
		}
		/*else if (camPos == 7) {
			transform.position = pos7;
		}*/
		
		//Debug.Log(camPos);
	}
			
	
}