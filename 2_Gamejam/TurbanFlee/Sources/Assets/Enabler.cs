using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enabler : MonoBehaviour {
   public List<GameObject> objects;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnableObjects(bool yes) {
        foreach (GameObject go in objects) {
            go.gameObject.SetActive(!yes);
        }
    }
}
