using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public enum Object {
    Coran, Llave
}
public class objeto : MonoBehaviour {

    public GameObject bola = null;
    public Object obj;

    public delegate void ObjectObtained(Object objs, GameObject sender);
    public static event ObjectObtained OnObtain;

    [SerializeField]
   // private List<Vector2> posiciones= new List<Vector2>();
    private int m = 0;	

    // Use this for initialization
	void Start () {
        
       /* posiciones.Add( new Vector2(1,1));
        posiciones.Add(new Vector2(41,1));
        posiciones.Add(new Vector2(41,27));
        posiciones.Add(new Vector2(1,27));
        posiciones.Add(new Vector2(21,15));
        posiciones.Add(new Vector2(13,20));
        posiciones.Add(new Vector2(29,4));
        posiciones.Add(new Vector2(13,4));
        posiciones.Add(new Vector2(3,15));
        posiciones.Add(new Vector2(39,15));*/
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        /*  Vector3 pos = new Vector3(posiciones[m].x, 0, posiciones[m].y);
          bola.transform.position = pos;
          m++;
          if (m == (posiciones.Count - 1))
          {
              m = 0;
          }*/
        OnObtain(obj, gameObject);
        gameObject.SetActive(false);
    }
}
