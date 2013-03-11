using UnityEngine;
using System.Collections;
using System.Collections.Generic; // This is necessary to use Lists.

public class analyzeAudio : MonoBehaviour {
	
	public int samplez;
	public float [] samplezArray;
	
	public flyer cubePrefab;
	public List<flyer> myFlyers = new List<flyer>();
	public int cubeCount = 10;
	float mixItUp;

	// Use this for initialization
	void Start () {
		
		// It's necessary to use Instantiate because Unity is built on top of MonoDevelop; otherwise we could just use a constructor.
		// "Vector3.zero" is shorthand for "Vector3(0,0,0)."
		for (int i = 0; i < cubeCount; i++) {
			flyer tempFlyer = Instantiate (cubePrefab, Vector3.zero, Quaternion.identity) as flyer;
			myFlyers.Add(tempFlyer); // Add the temp object to the list.
			tempFlyer.speed = i;
			tempFlyer.SetNewTarget();
		}
		
		samplez = 1024;
		samplezArray = new float [samplez];
	}
	
	// Update is called once per frame
	void Update () {
		
		mixItUp = Random.Range(-4.0f,4.0f);
		
		samplezArray = AudioListener.GetSpectrumData(samplez, 0, FFTWindow.Rectangular); // The AudioListener (which I attached to the main camera)
		// gets the spectrum data using the number of samples specified in the sampleZ variable and stores it in an array of the same size. I don't
		// get the middle number, which is "channel." The third thing is for audio fidelity - I picked the lightest option, which is fastest.
		
		int i = 1;
        while (i < 1023) {
			/*I copied this code in from the Unity Help page: http://docs.unity3d.com/Documentation/ScriptReference/AudioSource.GetSpectrumData.html
			 * As far as I can tell, it simply draws lines that fluctuate based on the audio input. It's pretty confusing but I'll go with it.*/
            /*
			Debug.DrawLine(new Vector3(i - 1, samplezArray[i] + 10, 0), new Vector3(i, samplezArray[i + 1] + 10, 0), Color.red);
            Debug.DrawLine(new Vector3(i - 1, Mathf.Log(samplezArray[i - 1]) + 10, 2), new Vector3(i, Mathf.Log(samplezArray[i]) + 10, 2), Color.cyan);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), samplezArray[i - 1] - 10, 1), new Vector3(Mathf.Log(i), samplezArray[i] - 10, 1), Color.green);
            Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(samplezArray[i - 1]), 3), new Vector3(Mathf.Log(i), Mathf.Log(samplezArray[i]), 3), Color.yellow);
            */
			
			for (int j = 0; j < myFlyers.Count; j++) {
				//myFlyers[j].transform.localScale = new Vector3(samplezArray[i], samplezArray[i + 1] + 10, samplezArray[i]-100);
				//myFlyers[j].transform.localPosition.x = (samplezArray[i]+mixItUp);
				
				Debug.DrawLine(new Vector3(i - 1, samplezArray[i] + 10, 0), new Vector3(myFlyers[j].transform.localPosition.x, myFlyers[j].transform.localPosition.y, myFlyers[j].transform.localPosition.z), Color.red);
            	Debug.DrawLine(new Vector3(i - 1, Mathf.Log(samplezArray[i - 1]) + 10, 2), new Vector3(myFlyers[j].transform.localPosition.x, myFlyers[j].transform.localPosition.y, myFlyers[j].transform.localPosition.z), Color.cyan);
            	Debug.DrawLine(new Vector3(Mathf.Log(i - 1), samplezArray[i - 1] - 10, 1), new Vector3(myFlyers[j].transform.localPosition.x, myFlyers[j].transform.localPosition.y, myFlyers[j].transform.localPosition.z), Color.green);
            	Debug.DrawLine(new Vector3(Mathf.Log(i - 1), Mathf.Log(samplezArray[i - 1]), 3), new Vector3(myFlyers[j].transform.localPosition.x, myFlyers[j].transform.localPosition.y, myFlyers[j].transform.localPosition.z), Color.yellow);
			}
            
            i++;
            
			Debug.Log(i);
        }
		if (i >= 1023) {
			i = 1;
		}
	}
}
