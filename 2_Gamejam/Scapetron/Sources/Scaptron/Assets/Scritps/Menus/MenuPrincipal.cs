using UnityEngine;
using System.Collections;

public class MenuPrincipal : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {

        //Jugar
	    if(Input.GetKeyDown(KeyCode.Z))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Splash_Nivel_01");
        }

        //Creditos
        if(Input.GetKeyDown(KeyCode.X))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(4);
        }

        //Instrucciones
        if (Input.GetKeyDown(KeyCode.V))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(5);
        }

        //Salir
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }


    }
}
