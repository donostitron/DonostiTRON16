using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	private float currentTime = 0f;
	public bool started = false;

	private Text text;

	// Use this for initialization
	void Awake () {
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (started)
			currentTime += Time.deltaTime;
		text.text = "Time: " + currentTime;
	}

	// Return the current value for "currentTime"
	float getTime(){
		return currentTime;
	}
}
