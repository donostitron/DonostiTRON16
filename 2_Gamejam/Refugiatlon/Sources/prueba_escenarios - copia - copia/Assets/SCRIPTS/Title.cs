using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

  [RequireComponent (typeof (AudioSource))]

public class Title : MonoBehaviour {

	public MovieTexture movie;
	public AudioSource audioP;

	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		audioP = GetComponent<AudioSource> ();
		movie.Play ();
		audioP.Play ();
		movie.loop = true;


	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) {
			SceneManager.LoadScene ("Tierra");	
		}
	}
}
