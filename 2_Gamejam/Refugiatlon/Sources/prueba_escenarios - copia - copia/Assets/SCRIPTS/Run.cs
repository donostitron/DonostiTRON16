using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Run : MonoBehaviour {

	public float forwardDistance = 0.1f;
	public float sideDistance = 1f;
	public float MAXRight = 2f;
	public float MAXLeft = 0f;
	public bool isLeft = false;
	public bool isRight = false;
	public float chase = 0f;
	public Camera mcamera;
	public Image poli_1;
	public Image poli_2;
	private bool left = false;
	private bool right = false;
	private Vector3 destination;
	private Vector3 camPos;
	private float chaseTime;
	private float notChase;
	public bool started;
	private float harambe = -3f;
	private Botellón script;


	// Use this for initialization
	void Start () {
		started = false;
		mcamera = Camera.main;
		camPos = mcamera.transform.position;
		chase = 2;
		script = GetComponent<Botellón> ();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.z == MAXRight)
			isRight = true;
		else
			isRight = false;

		if (transform.position.z == MAXLeft)
			isLeft = true;
		else
			isLeft = false;
		
		if (Input.GetKey (KeyCode.X) && !Input.GetKey (KeyCode.Z) && GetComponent<Animator> ().GetBool ("playerRight")) {
			if (!started) {
				chase = 0;
				started = true;
			}
			chaseTime -= 1.5f * Time.deltaTime;
			Legs (false);
		} else if (Input.GetKey (KeyCode.Z) && !Input.GetKey (KeyCode.X) && !GetComponent<Animator> ().GetBool ("playerRight")) {
			if (!started) {
				chase = 0;
				started = true;
			}
			chaseTime -= 1.5f * Time.deltaTime;
			Legs (true);
		} else if (!Input.GetKey (KeyCode.X) && !Input.GetKey (KeyCode.Z)) {
			GetComponent<Animator> ().SetBool ("isRun", false);
			if (started)
				chaseTime += Time.deltaTime;
			if (chaseTime >= 0.8f && started) {
				chase ++;
				chaseTime = 0f;
			}
		}
		if (chaseTime <= harambe && started) {
			if (chase > 0)
				chase--;
			chaseTime = 0f;
		}

		if (Input.GetKeyDown (KeyCode.RightArrow) && !isRight) {
			if (!started) {
				chase = 0;
				started = true;
			}
			if (!right)
				destination = transform.position + new Vector3 (0, 0, -sideDistance);
			right = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow) && !isLeft) {
			if (!started) {
				chase = 0;
				started = true;
			}
			if (!left)
				destination = transform.position + new Vector3 (0, 0, sideDistance);
			left = true;
		}
		if (right)
			MoveRight ();
		else if (left)
			MoveLeft ();
		mcamera.transform.position = new Vector3 (mcamera.transform.position.x, mcamera.transform.position.y, camPos.z);

		if (chase == 0) {
			poli_1.enabled = false;
			poli_2.enabled = false;
		} else if (chase == 1) {
			poli_1.enabled = true;
			poli_2.enabled = false;
		} else if (chase == 2) {
			poli_1.enabled = true;
			poli_2.enabled = true;
		} else if (chase == 3)
			Deport ();
		if (chase == 2)
			harambe = -0.8f;
		else
			harambe = -0.8f;
	}
	float tleft = 0;
	float tright = 0;

	//Move the character to the right side of the track
	void MoveLeft (){
		tleft += 0.5f * Time.deltaTime;
		Vector3 currentPos = GetComponent<Transform> ().position;
		//Vector3 destination = currentPos + new Vector3 (0, 0, sideDistance);
		if (GetComponent<Transform> ().position.z < destination.z) {
			//GetComponent<Transform>().position = currentPos + new Vector3 (0, 0, sideDistance);
			float ejeZ = Mathf.Lerp (currentPos.z, destination.z, tleft);
			transform.position = new Vector3 (transform.position.x, transform.position.y, ejeZ);
		} else {
			left = false;
			tleft = 0;		
		}
	}

	//Move the character to the left side of the track
	void MoveRight (){
		tright += 0.5f * Time.deltaTime;
		Vector3 currentPos = GetComponent<Transform> ().position;
		if (GetComponent<Transform> ().position.z > destination.z) {
			float ejeZ = Mathf.Lerp (currentPos.z, destination.z, tright);
			transform.position = new Vector3 (transform.position.x, transform.position.y, ejeZ);
		} else {
			right = false;
			tright = 0;
		}
	}

	// Move the character's right side
	void Legs (bool r){
		Vector3 currentPos = GetComponent<Transform>().position;
		GetComponent<Transform>().position = currentPos + new Vector3 (forwardDistance, 0, 0);
		if (r) {
			GetComponent<Animator> ().SetBool ("playerRight", true);
			GetComponent<Animator> ().SetBool ("isRun", true);
		} else {
			GetComponent<Animator>().SetBool("playerRight",false);
			GetComponent<Animator>().SetBool("isRun",true);
		}
		//mcamera.GetComponent<Transform> ().position = mcamera.GetComponent<Transform> ().position + new Vector3 (forwardDistance,0,0);
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Prop") {
			chase++;
		} else if (other.tag == "Ganas") {
			SceneManager.LoadScene ("ganas");
		} else if (other.gameObject.tag == "Botella") {
			script.barra.value -= 0.7f;
			Destroy (other);
		}
	}

	void Deport (){
		SceneManager.LoadScene ("Deported");
	}
}
