using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

	[RequireComponent (typeof (AudioSource))]

public class retry : MonoBehaviour {

	public AudioSource deportado;


	void Start () {
		

		AudioSource deportado = GetComponent<AudioSource>();
		deportado.Play();

	}

	void Update () {

		if (Input.GetKeyDown (KeyCode.C)) {
			SceneManager.LoadScene ("Tierra");
		}
	}
}
