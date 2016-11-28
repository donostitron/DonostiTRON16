using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {

    public GameObject jugador;
    public float maxPosX;
    public float velocidad;

    private Vector3 _offset;

	// Use this for initialization
	void Start () {
        _offset = transform.position - jugador.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x = jugador.transform.position.x + _offset.x;

        if (pos.x < maxPosX)
            transform.position = pos;

    }
}
