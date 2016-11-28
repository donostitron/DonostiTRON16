using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Botellón : MonoBehaviour {
	public Slider barra;
	private Run script;

	// Use this for initialization
	void Start () {
		script = GetComponent<Run> ();
		barra.value = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
			barra.value += 0.01f;
			if (barra.value >= 1f)
				script.chase = 3;
		}
	
	}
}