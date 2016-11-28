using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class ControlGrupo : MonoBehaviour
    {
        public float velocidadMov = 10.0f;
        public bool caido = false;
        public bool parado = false;

        public GameObject idle;
        public GameObject dead;

        private bool mantener = false;
        private float auxVel;


        // Use this for initialization
        void Start()
        {
            auxVel = velocidadMov;
        }

        
        // Update is called once per frame
        void Update()
        {
            
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            if(coll.gameObject.tag == "Rio" && !mantener)
            {
                gameObject.SetActive(false);
                CuentaCaidos.totalCaidos++;
            }

            if (coll.gameObject.tag == "Enemigo")
            {
                gameObject.SetActive(false);
                CuentaCaidos.totalCaidos++;
            }

            if (coll.gameObject.tag == "Obstaculo")
            {
                parado = true;
                
                CuentaCaidos.totalCaidos++;
            }

            if (coll.gameObject.tag == "InicioPuente")
            {
                mantener = true;
            }
            else
            {
                mantener = false;
            }

            if (coll.gameObject.tag == "FinalPuente")
            {
                mantener = false;
            }



            if (coll.gameObject.tag == "FinalValla")
            {
                velocidadMov = auxVel;
            }

            if (coll.gameObject.tag == "Valla")
            {
                velocidadMov = 0.0f;
                mantener = true;
            }

            CheckIfLevelFinished(coll.gameObject.tag);
        }

        private void CheckIfLevelFinished(string tag)
        {
            if(tag == "Final_01")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Splash_Nivel_02");
            }

            if (tag == "Final_02")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Splash_Nivel_03");
            }

            if (tag == "Final_03")
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Winner");
            }
        }

    }
}