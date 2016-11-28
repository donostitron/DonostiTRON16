using UnityEngine;
using System.Collections;

public class StopHammerTime : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = Quaternion.Euler(new Vector3(45,0,0));
    }
}
