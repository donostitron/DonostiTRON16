using UnityEngine;
using System.Collections;
using System;

public class movimiento : MonoBehaviour {

    public GameObject PJ = null;
    public Sprite spU1 = null;
    public Sprite spU2 = null;

    public Sprite spD1 = null;
    public Sprite spD2 = null;

    public Sprite spL1 = null;
    public Sprite spL2 = null;

    public Sprite spR1 = null;
    public Sprite spR2 = null;

    public int i = 0;
    private int modo = 0;
    bool working = false;

	// Use this for initialization
	void Start () {
        InputManager.OnPressed += MyMethod2;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;
    }

    private void ClearSubscribes() {
        InputManager.OnPressed -= MyMethod2;
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
    }

    // Update is called once per frame
    void Update () {
        if (!working)
        {
            working = true;
            StartCoroutine(MyMethod());
            
        }


    }


    IEnumerator MyMethod()
    {
        yield return new WaitForSeconds(0.3f);
        switch (modo)
        {
            case 0: //UP
                if (i == 0)
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spU1;
                    i = 1;
                }
                else
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spU2;
                    i = 0;
                }
            break;

            case 1: //DOWN
                if (i == 0)
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spD1;
                    i = 1;
                }
                else
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spD2;
                    i = 0;
                }
                break;

            case 2: //LEFT
                if (i == 0)
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spL1;
                    i = 1;
                }
                else
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spL2;
                    i = 0;
                }
                break;

            case 3: //RIGHT
                if (i == 0)
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spR1;
                    i = 1;
                }
                else
                {
                    PJ.GetComponent<SpriteRenderer>().sprite = spR2;
                    i = 0;
                }
                break;
        }


        working = false;
    }

     void MyMethod2(EnteredInput boton)
    {
        if (boton == EnteredInput.Up) modo = 0;
        if (boton == EnteredInput.Down) modo = 1;
        if (boton == EnteredInput.Left) modo = 2;
        if (boton == EnteredInput.Right) modo = 3;
    }
}
