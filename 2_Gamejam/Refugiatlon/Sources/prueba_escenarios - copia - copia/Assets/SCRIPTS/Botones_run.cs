using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Botones_run : MonoBehaviour {

	public Image boton_rojo;
	public Image boton_blanco;
	public Sprite RojoOn;
	public Sprite RojoOff;
	public Sprite BlancoOn;
	public Sprite BlancoOff;
	private float tiempo;
	private bool pulsar;

	void Start () {

		pulsar = false;

	}


	void Update () {

		tiempo += Time.deltaTime;


		if (tiempo >= 0.5f && boton_rojo.sprite == RojoOn && !pulsar) {

			boton_rojo.sprite = RojoOff;
			boton_blanco.sprite = BlancoOn;
			tiempo = 0f;

		}else if (tiempo >= 0.5f && boton_rojo.sprite == RojoOff && !pulsar) {

			boton_rojo.sprite = RojoOn;
			boton_blanco.sprite = BlancoOff;
			tiempo = 0f;
		}
		if (Input.GetKey(KeyCode.Z) || Input.GetKey (KeyCode.X)){
			pulsar = true;
		}
		if (pulsar) {
			boton_rojo.enabled = false;
			boton_blanco.enabled = false;
		}

	}

}
