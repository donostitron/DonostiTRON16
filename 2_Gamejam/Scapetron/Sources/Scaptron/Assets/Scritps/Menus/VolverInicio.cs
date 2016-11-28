using UnityEngine;
using System.Collections;

public class VolverInicio : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Menu Principal
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
    }
}
