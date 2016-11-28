using UnityEngine;
using System.Collections;

namespace Logica
{
    public class LogicaPuentes : MonoBehaviour
    {
        public GameObject puente;
        public GameObject valla;
        public float distanciaEntrePuentes = 20.0f;
        public float posInicio = 30.0f;
        public float velocidad = 0.1f;
        public float minTam = 1.0f;
        public float maxTam = 2.0f;

        private GameObject[] arrayPuentes = new GameObject[5];
        //private GameObject[][] arrayVallas = new GameObject[5][];
        private float offSetX = 2.0f;
        private Vector3 _minPos, _maxPos;

        // Use this for initialization
        void Start()
        {
            _minPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
            _maxPos = Camera.main.ViewportToWorldPoint(new Vector3(1, 1));

            for (int i = 0; i < arrayPuentes.Length; i++)
            {
                arrayPuentes[i] = Instantiate(puente);

                //Puente
                Vector3 posPuente = arrayPuentes[i].transform.position;
                posPuente.x = (i * distanciaEntrePuentes)+posInicio;
                posPuente.y = Random.Range(_minPos.y, _maxPos.y);
                arrayPuentes[i].transform.localScale = new Vector3(4, Random.Range(minTam, maxTam));
                arrayPuentes[i].transform.position = posPuente;

                //Vallas
                /*arrayVallas[i] = new GameObject[2];
                arrayVallas[i][0] = Instantiate(valla);
                arrayVallas[i][1] = Instantiate(valla);
                Vector3[] posValla = new Vector3[2];
                posValla[0] = arrayVallas[i][0].transform.position;
                posValla[1] = arrayVallas[i][1].transform.position;
                posValla[0].x = posPuente.x;
                posValla[1].x = posPuente.x;
                posValla[0].y = posPuente.y + arrayPuentes[i].transform.localScale.y / 2;
                posValla[1].y = posPuente.y - arrayPuentes[i].transform.localScale.y / 2;

                arrayVallas[i][0].transform.position = posValla[0];
                arrayVallas[i][1].transform.position = posValla[1];*/
            }
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < arrayPuentes.Length; i++)
            {
                Vector3 posPuente = arrayPuentes[i].transform.position;
                posPuente.x -= velocidad;

                Vector3[] posValla = new Vector3[2];
                //posValla[0] = arrayVallas[i][0].transform.position;
                //posValla[1] = arrayVallas[i][1].transform.position;
                posValla[0].x -= velocidad;
                posValla[1].x -= velocidad;

                Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));

                if (posPuente.x < min.x - offSetX)
                {
                    //Puente
                    posPuente.x = arrayPuentes[GetPrevColPosInArray(i)].transform.position.x + distanciaEntrePuentes;
                    posPuente.y = Random.Range(_minPos.y, _maxPos.y);
                    arrayPuentes[i].transform.localScale = new Vector3(4, Random.Range(minTam, maxTam));

                    //Valla
                    /*posValla[0].x = posPuente.x;
                    posValla[1].x = posPuente.x;
                    posValla[0].y = posPuente.y + arrayPuentes[i].transform.localScale.y / 2;
                    posValla[1].y = posPuente.y - arrayPuentes[i].transform.localScale.y / 2;*/


                }

                arrayPuentes[i].transform.position = posPuente;
                //arrayVallas[i][0].transform.position = posValla[0];
                //arrayVallas[i][1].transform.position = posValla[1];
            }
        }

        int GetPrevColPosInArray(int currPos)
        {
            int pos = currPos - 1;
            if (pos < 0)
                pos = arrayPuentes.Length - 1;

            return pos;
        }
    }
}
