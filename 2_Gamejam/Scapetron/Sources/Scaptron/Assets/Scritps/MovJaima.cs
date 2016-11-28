using UnityEngine;
using System.Collections;

public class MovJaima : MonoBehaviour {

    public float velocidad = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);

    }
}
