﻿using UnityEngine;
using System.Collections;

public class Splash_Nivel_01 : MonoBehaviour {

    float elapsedTime = 0.0f;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 3)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Mapa01");
        }
    }
}
