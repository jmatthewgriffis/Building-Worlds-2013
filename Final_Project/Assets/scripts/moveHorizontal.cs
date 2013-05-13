using UnityEngine;
using System.Collections;

public class moveHorizontal : MonoBehaviour {
	
	public int speed = 5;
	//int moveLimit = 10;
	Vector3 move = new Vector3(1,0,1);
	//Vector3 posMin = new Vector3(0,0,0);
	//Vector3 posMax = new Vector3(0,0,0);
	//Vector3 moveLimitVector = new Vector3(0,0,0);
	//public Transform player;
	
	// Use this for initialization
	void Start () {
		//moveLimitVector = new Vector3(moveLimit,0,moveLimit);
		//posMin = transform.localPosition - moveLimitVector;
		//posMax = transform.localPosition + moveLimitVector;
		/*if (Random.Range(0.0f, 1.0f) < 0.5f) {
			speed *= -1;
		}*/
		StartCoroutine(moveH() );
	}
	
	// Update is called once per frame
	void Update () {
		
		//moveCharacter moveCharacter = GetComponent<moveCharacter>();
		
		//if (moveCharacter.gravityIsOn == true) {
		/*if (Physics.Raycast(transform.position, -transform.up, triggerGrav) {
			player.parent = transform;
		}
		else {
			player.parent = null;
		}*/
		
		/*if (transform.localPosition.x > posMin.x+speed && transform.localPosition.x < posMax.x-speed 
			&& transform.localPosition.z > posMin.z+speed && transform.localPosition.z < posMax.z-speed) {*/
		transform.localPosition += move * speed * Time.deltaTime;
		/*}
		else {
			//speed *= -1;
		}*/
	}
	
	// Use a "co-routine" to control the order of script actions. Easier than using "if" statements.
	IEnumerator moveH () { // Don't worry about what this is.
		while(true) {
			// "Yield" is a special command only available in the IEnumerator.
			//yield return new WaitForSeconds(Random.Range(2.0f,4.0f));
			yield return new WaitForSeconds(3.0f);
			speed *= -1;
		}
	}
}
