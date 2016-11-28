using UnityEngine;
using System.Collections;

namespace Gameplay
{
    public class FormacionN : MonoBehaviour
    {
        public int formacionActual;
        public int numPers = 20;
        public GameObject persona;
        public Vector3 posInicial = Vector3.zero;
        public bool moverFormacion = false;
        public float velocidadMovBackG = 1.0f;
        public float velocidadMovGrupo = 10.0f;

        private int _tamFormX, _tamFormY;

        private GameObject[][] arrayFormacion;
        private Vector3[][] arrayPosiciones;
        private float prevPosY = 0.0f;
        private float offSetX = 2.0f;

        private Vector3 _minPos, _maxPos;

        // Use this for initialization
        void Start()
        {
            _tamFormX = TamFormacionX(numPers);
            _tamFormY = TamFormacionY(numPers, _tamFormX);

            arrayFormacion = new GameObject[_tamFormX][];
            for (int i = 0; i < _tamFormX; i++)
                arrayFormacion[i] = new GameObject[_tamFormY];

            arrayPosiciones = new Vector3[_tamFormX][];
            for (int i = 0; i < _tamFormX; i++)
                arrayPosiciones[i] = new Vector3[_tamFormY];
            CuentaCaidos.totalCaidos = 0;

            _minPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));
            _maxPos = Camera.main.ViewportToWorldPoint(new Vector3(0, 1));

            PosicionesPersonas(5);
            formacionActual = 0;
            InicializarFormacion(numPers);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                if (formacionActual == 0)
                {
                    PosicionesPersonas(2);
                    formacionActual = 1;
                    DibujarFormacion(numPers);
                }
                else if (formacionActual == 1)
                {
                    PosicionesPersonas(5);
                    formacionActual = 0;
                    DibujarFormacion(numPers);
                }
            }
            
            ComprobarParados(_tamFormX, _tamFormY);

            if (moverFormacion)
            {
                MoverFormacion(_tamFormX, _tamFormY, velocidadMovBackG);
            }
           

            if (Input.GetKey(KeyCode.DownArrow))
            {
                Vector3 pos = gameObject.transform.position;
                pos += Vector3.down * velocidadMovGrupo * Time.deltaTime;

                if (pos.y - transform.localScale.y >= _minPos.y && pos.y - transform.localScale.y <= _maxPos.y)
                {
                    gameObject.transform.position = pos;
                }

            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                Vector3 pos = gameObject.transform.position;
                pos += Vector3.up * velocidadMovGrupo * Time.deltaTime;

                if (pos.y >= _minPos.y && pos.y <= _maxPos.y)
                {
                    gameObject.transform.position = pos;
                }
            }
        }

        public void ObtenerPrevPosicionY(int x, int y)
        {
           
        }

        public void ComprobarParados(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (arrayFormacion[i][j] != null)
                    {
                        bool parado = arrayFormacion[i][j].gameObject.GetComponent<ControlGrupo>().parado;
                        if (parado)
                        {
                            Vector3 pos = arrayFormacion[i][j].transform.position;
                            arrayFormacion[i][j].transform.parent = null;

                            Vector3 min = Camera.main.ViewportToWorldPoint(new Vector3(0, 0));

                            if (pos.x < min.x - offSetX)
                            {
                                arrayFormacion[i][j].SetActive(false);
                            }
                        }
                    }
                }
            }
        }

        private void InicializarFormacion(int numPers)
        {
            int cont = 0;
            for (int i = 0; i < _tamFormX; i++)
            {
                for (int j = 0; j < _tamFormY; j++)
                {
                    if (cont < numPers - CuentaCaidos.totalCaidos)
                    {
                        arrayFormacion[i][j] = (GameObject)Instantiate(persona, arrayPosiciones[i][j], Quaternion.identity);
                        cont++;
                    }
                }
            }
        }

        private void DibujarFormacion(int numPers)
        {
            int cont = 0;
            for (int i = 0; i < _tamFormX; i++)
            {
                for (int j = 0; j < _tamFormY; j++)
                {
                    if (cont < numPers - CuentaCaidos.totalCaidos)
                    {
                        Vector3 pos = arrayFormacion[i][j].transform.position;
                        pos.x = arrayPosiciones[i][j].x;
                        pos.y = arrayPosiciones[i][j].y;
                        arrayFormacion[i][j].transform.position = pos;
                        arrayFormacion[i][j].transform.parent = transform;
                        cont++;
                    }
                }
            }
        }

        private void PosicionesPersonas(int columnasTotales)
        {
            int fila = 0;
            int cont = 0;

            for(int i = 0; i < _tamFormY; i++)
            {
                int vuelta = 0;
                int j = 0;

                while(columnasTotales * vuelta < _tamFormX)
                {
                    for (j = 0; j < columnasTotales; j++)
                    {
                        if (cont < numPers - CuentaCaidos.totalCaidos)
                        {
                            arrayPosiciones[j + (columnasTotales * vuelta)][i] = new Vector3((j + posInicial.x) * 0.25f, (fila + prevPosY) * 0.25f);
                            cont++;
                        }
                    }

                    fila++;
                    vuelta++;
                }

                
            }
        }

        private int TamFormacionX(float numPers)
        {
            return Mathf.RoundToInt(numPers / 2.0f);
        }

        private int TamFormacionY(float numPers, float tamFormacionX)
        {
            return Mathf.RoundToInt(numPers / tamFormacionX);
        }

        private void MoverFormacion(int x, int y, float velocidad)
        {
            Vector3 pos = gameObject.transform.position;
            pos += Vector3.right * velocidad * Time.deltaTime;
            gameObject.transform.position = pos;
        }
    }

    
}
