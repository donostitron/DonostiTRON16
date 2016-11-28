using UnityEngine;
using System.Collections;

public class Botones : MonoBehaviour {

	public GameObject boton_on;
	public GameObject boton_off;
	private float tiempo;
	private bool pulsar;

	void Start () {
	
		boton_on.SetActive(false);
		boton_off.SetActive(false);
		pulsar = false;

	}
	

	void Update () {

		tiempo += Time.deltaTime;
		if (tiempo >= 2f && !pulsar) {

			boton_off.SetActive(true);
			pulsar = true;
			tiempo = 0f;

		} else if (tiempo >= 1f && boton_off.activeSelf) {

			boton_off.SetActive (false);
			boton_on.SetActive (true);
			tiempo = 0f;
		
		} else if (tiempo >= 1f && boton_on.activeSelf) {
			boton_off.SetActive (true);
			boton_on.SetActive (false);
			tiempo = 0f;
		}

	
	}
}
