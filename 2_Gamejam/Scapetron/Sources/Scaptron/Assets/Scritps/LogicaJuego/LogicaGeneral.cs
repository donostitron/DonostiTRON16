using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class LogicaGeneral : MonoBehaviour
    {

        //public float tiempoNecesario = 25.0f;

        //private float _tiempo = 0;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(0);
            }

            /*
            if (_tiempo > tiempoNecesario)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(2);
            }

            _tiempo += Time.deltaTime;*/
        }
    }
}


