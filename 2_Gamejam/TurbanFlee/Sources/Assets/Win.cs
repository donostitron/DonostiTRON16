using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

    public delegate void GameEnded(TimeCounter.EndMode awesome);
    public static event GameEnded OnWin;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    private void OnTriggerExit(Collider other) {

        if(other.gameObject.tag == "Bounds") {
            OnWin(TimeCounter.EndMode.Win);
        }
    }
}
