using UnityEngine;
using System.Collections;

public class Mapa_Nivel_01 : MonoBehaviour {

    float elapsedTime = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Nivel01");
        }
    }
}
