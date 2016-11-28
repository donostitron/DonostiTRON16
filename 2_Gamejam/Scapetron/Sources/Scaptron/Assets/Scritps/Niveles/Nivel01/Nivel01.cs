using UnityEngine;
using System.Collections;

public class Nivel01 : MonoBehaviour {

    public float velocidad;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = gameObject.transform.position;
        pos += Vector3.left * velocidad * Time.deltaTime;
        gameObject.transform.position = pos; 

    }
}
