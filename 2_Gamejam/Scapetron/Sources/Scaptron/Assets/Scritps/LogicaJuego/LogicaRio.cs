using UnityEngine;
using System.Collections;

namespace Logica
{
    public class LogicaRio : MonoBehaviour
    {

        public GameObject rio;
        public float distanciaEntreRios = 20.0f;
        public float velocidad = 0.1f;
        public float posInicio = 30.0f;

        private GameObject[] arrayRios = new GameObject[5];
        private float offSetX = 2.0f;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < 5; i++)
            {
                arrayRios[i] = Instantiate(rio);
                Vector3 pos = arrayRios[i].transform.position;
                pos.x = i * distanciaEntreRios + posInicio;
                arrayRios[i].transform.position = pos;
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < arrayRios.Length; i++)
            {
                Vector3 pos = arrayRios[i].transform.position;
                pos.x -= velocidad;

                Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));

                if (pos.x < min.x - offSetX)
                {
                    pos.x = arrayRios[GetPrevColPosInArray(i)].transform.position.x + distanciaEntreRios;
                }

                arrayRios[i].transform.position = pos;
            }
        }

        int GetPrevColPosInArray(int currPos)
        {
            int pos = currPos - 1;
            if (pos < 0)
                pos = arrayRios.Length - 1;

            return pos;
        }
    }
}
