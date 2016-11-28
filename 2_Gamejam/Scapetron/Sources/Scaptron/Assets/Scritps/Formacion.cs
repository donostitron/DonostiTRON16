using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public static class CuentaCaidos
    {
        public static int totalCaidos { get; set; }
    }

    public class Formacion : MonoBehaviour
    {
        public int numPers = 20;
        public int formacionActual;
        public GameObject persona;
        public GameObject sha;
        public Vector3 posInicial = Vector3.zero;
        public bool moverFormacion = false;
        public float velocidadMovBackG = 1.0f;
        public float velocidadMovGrupo = 10.0f;

        private int _tamForm;
        private GameObject[][] formacion;
        private Vector3 prevPos;
        private float offSetX = 2.0f;

        private Vector3 _minPos, _maxPos;

        // Use this for initialization
        void Start()
        {
            _tamForm = TamFormacion(numPers);
            formacion = new GameObject[_tamForm][];
            for (int i = 0; i < _tamForm; i++)
                formacion[i] = new GameObject[5];
            CuentaCaidos.totalCaidos = 0;

            _minPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
            _maxPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));

            DibujarFormacion(_tamForm, 5, numPers, posInicial);
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                if(formacionActual == 0)
                {
                    BorrarFormacion(_tamForm, 5);
                    RehacerFormacion(_tamForm, 2);
                    DibujarRectangulo();
                }
                else if(formacionActual == 1)
                {
                    BorrarFormacion(_tamForm, 2);
                    RehacerFormacion(_tamForm, 5);
                    DibujarCuadrado();
                }
            }

           if (formacionActual == 0)
            {
                ComprobarParados(_tamForm, 5);

                if (moverFormacion)
                {
                    MoverFormacion(_tamForm, 5, velocidadMovBackG);
                }
            }
            else if (formacionActual == 1)
            {
                ComprobarParados(_tamForm, 2);

                if (moverFormacion)
                {
                    MoverFormacion(_tamForm, 2, velocidadMovBackG);
                }
            }

            if(numPers <= CuentaCaidos.totalCaidos)
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 pos = gameObject.transform.position;
                pos += Vector3.down * velocidadMovGrupo * Time.deltaTime;

                if (pos.y-transform.localScale.y >= _minPos.y && pos.y - transform.localScale.y <= _maxPos.y)
                {
                    gameObject.transform.position = pos;
                }

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 pos = gameObject.transform.position;
                pos += Vector3.up * velocidadMovGrupo * Time.deltaTime;

                if (pos.y - transform.localScale.y >= _minPos.y && pos.y - transform.localScale.y <= _maxPos.y)
                {
                    gameObject.transform.position = pos;
                }
            }
        }

        private int TamFormacion(int numPers)
        {
            return numPers / 2;
        }

        private void DibujarFormacion(int x, int y, int numPers, Vector3 offSet)
        {
            int cont = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (cont < numPers-CuentaCaidos.totalCaidos)
                    {
                        formacion[i][j] = (GameObject)Instantiate(persona);
                    
                        Vector3 pos = formacion[i][j].transform.position;
                        pos.x = (i+ offSet.x) * 0.25f;
                        pos.y = (j + offSet.y) * 0.25f;
                        formacion[i][j].transform.position = pos;
                        formacion[i][j].transform.parent = transform;

                        cont++;
                    }
                }
            }
        }

        public void DibujarCuadrado()
        {
            DibujarFormacion(_tamForm, 5, numPers, prevPos);
            formacionActual = 0;
        }

        public void DibujarRectangulo()
        {
            DibujarFormacion(_tamForm, 2, numPers, prevPos);
            formacionActual = 1;
        }

        public void BorrarFormacion(int x, int y)
        {
            ObtenerPrevPosicion(x, y);
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    Destroy(formacion[i][j]);
                }
            }
        }

        public void RehacerFormacion(int x, int y)
        {
            formacion = new GameObject[x][];
            for (int i = 0; i < x; i++)
            {
                formacion[i] = new GameObject[y];
            }
        }

        public void ObtenerPrevPosicion(int x, int y)
        {
            /*
            bool valorObtenido = false;
            int i = 0;
            int j = 0;

            while(i < x && !valorObtenido)
            {
                while(j < y && !valorObtenido)
                {
                    if (formacion[i][j] != null)
                    {
                        prevPos = formacion[i][j].transform.position + posInicial;
                        valorObtenido = true;
                    }
                }
            }*/

            prevPos = transform.position + posInicial;
        }

        public void ComprobarParados(int x, int y)
        {
            for(int i = 0; i < x; i++)
            {
                for(int j=0; j < y; j++)
                {
                    if(formacion[i][j] != null)
                    {
                        bool parado = formacion[i][j].gameObject.GetComponent<ControlGrupo>().parado;
                        if (parado)
                        {
                            Vector3 pos = formacion[i][j].transform.position;
                            formacion[i][j].transform.parent = null;

                            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
                            
                            if (pos.x < min.x - offSetX)
                            {
                                formacion[i][j].SetActive(false);
                            }
                        }
                    }
                }
            }
        }

        private void MoverFormacion( int x, int y, float velocidad)
        {
            /*
            for(int i = 0; i < x; i++)
            {
                for(int j=0; j < y; j++)
                {
                    if(formacion[i][j]!=null)
                    {
                        Vector3 posPers = formacion[i][j].transform.position;
                        posPers += Vector3.right * velocidad * Time.deltaTime;
                        formacion[i][j].transform.position = posPers;
                    }
                }
            }*/


            Vector3 pos = gameObject.transform.position;
            pos += Vector3.right * velocidad * Time.deltaTime;
            gameObject.transform.position = pos;
        }
    }
}