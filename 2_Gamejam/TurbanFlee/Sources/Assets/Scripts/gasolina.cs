using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class gasolina : MonoBehaviour
{

    public GameObject PJ = null;
    public GameObject objeto = null;

    [SerializeField]
    private List<Vector2> posiciones = new List<Vector2>();
    private int m = 0;

    // Use this for initialization
    void Start()
    {
        posiciones.Add(new Vector2(13, 20));
        posiciones.Add(new Vector2(29, 4));
        posiciones.Add(new Vector2(13, 4));
        posiciones.Add(new Vector2(3, 15));
        posiciones.Add(new Vector2(39, 15));
        posiciones.Add(new Vector2(1, 1));
        posiciones.Add(new Vector2(41, 1));
        posiciones.Add(new Vector2(41, 27));
        posiciones.Add(new Vector2(1, 27));
        posiciones.Add(new Vector2(21, 15));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider col)
    {
        this.transform.position = new Vector3(1000, 1000, 1000);
        Debug.Log("entramos en la funcion");

        StartCoroutine(MyMethod());

        if (m >= (posiciones.Count - 1))
        {
            m = 0;
        }
    }

    IEnumerator MyMethod()
    {
        Debug.Log("Before Waiting 2 seconds");
        yield return new WaitForSeconds(5.0f);
        Debug.Log("After Waiting 2 Seconds");

        Vector3 pos = new Vector3(posiciones[m].x, 0, posiciones[m].y);
        this.transform.position = pos;
        if (objeto.transform.position.Equals(this.transform.position))
        {
            m = m + 2;
        }
        else
        {
            m++;
        }
    }
}