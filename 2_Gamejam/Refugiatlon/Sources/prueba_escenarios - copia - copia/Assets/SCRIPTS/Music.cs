using UnityEngine;
using System.Collections;

public class Music : MonoBehaviour {
	public GameObject player;
	public AudioSource main;
	public AudioSource danger1;
	public AudioSource danger2;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (player.GetComponent<Run>().chase == 1 && !danger1.isPlaying) {
			main.Pause();
			danger2.Pause ();
			danger1.Play ();

		} else if (player.GetComponent<Run>().chase == 2 && !danger2.isPlaying) {
			main.Pause ();
			danger1.Pause ();
			danger2.Play ();
		} else if (player.GetComponent<Run>().chase == 0 && !main.isPlaying) {
			danger1.Pause ();
			danger2.Pause ();
			main.Play ();
		}
	
	}
}
