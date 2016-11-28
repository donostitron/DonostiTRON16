using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CorreBarra : MonoBehaviour {
	public Image playerIm;
	public Image polisia;
	public float largoPista = 32.89f;
	public float distanciaPaso = 0.2f;
	public float delay = 0.3f;
	public GameObject andy;

	private float destino;
	private float origen;
	private Vector3 temp;
	private bool lastZ = false;
	private float tiempo;
	private Run script;

	// Use this for initialization
	void Start () {
		origen = playerIm.rectTransform.position.x;
		destino = origen;
		tiempo = 0f;
		script = andy.GetComponent<Run> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		if ((Input.GetKeyDown (KeyCode.X) || Input.GetKeyDown (KeyCode.Z))) {
			if (Input.GetKeyDown (KeyCode.X) && lastZ) {
				lastZ = false;
				destino += 0.89f;
			} else if (Input.GetKeyDown (KeyCode.Z) && !lastZ) {
				lastZ = true;
				destino += 0.89f;
			}
		}
		temp = playerIm.rectTransform.position;
		temp.x = destino;
		playerIm.rectTransform.position = temp;

		if(script.started){
			tiempo += Time.deltaTime;
			if (tiempo >= delay) {
				delay = 0.2f;
				tiempo = 0f;
				temp = polisia.rectTransform.position;
				temp.x += 1.5f;
				polisia.rectTransform.position = temp;
			}
			if (script.chase == 1f && polisia.rectTransform.position.x < playerIm.rectTransform.position.x - 50f)
				polisia.rectTransform.position = playerIm.rectTransform.position - new Vector3 (50f, 0, 0);
			else if (script.chase == 2f && polisia.rectTransform.position.x < playerIm.rectTransform.position.x - 25f) 
				polisia.rectTransform.position = playerIm.rectTransform.position - new Vector3 (25f, 0, 0);

		}
	
	}
}
