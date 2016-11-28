using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Day : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        GetComponent<Text>().text = "Day : "+MasterOfManagers.Master.Day;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
