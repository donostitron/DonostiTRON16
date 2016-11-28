using UnityEngine;
using System.Collections;

public class BackgroundSprite : MonoBehaviour {

    public GameObject arena_0;
    public GameObject arena_1;
    public float velocidad = 10.0f;
    public float distanciaEntreArena = 20.0f;
    public float offSet = 8.0f;

    private Vector3 _minPos, _maxPos;

    // Use this for initialization
    void Start ()
    {
        _minPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
        _maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos_0 = arena_0.transform.position;
        Vector3 pos_1 = arena_1.transform.position;
        pos_0.x -= velocidad;
        pos_1.x -= velocidad;

        if (pos_0.x < _minPos.x - offSet)
        {
            pos_0.x = arena_1.transform.position.x + distanciaEntreArena;
        }

        if(pos_1.x < _minPos.x - offSet)
        {
            pos_1.x = arena_0.transform.position.x + distanciaEntreArena;
        }

        arena_0.transform.position = pos_0;
        arena_1.transform.position = pos_1;
	}
}
