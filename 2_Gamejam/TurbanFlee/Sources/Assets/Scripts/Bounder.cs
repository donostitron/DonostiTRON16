using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class Bounder : MonoBehaviour{
    private bool colisioning = false;

    public bool Colisioning
    {
        get
        {
            return colisioning;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "wall"){
            colisioning = true;
        }
        
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            colisioning = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        colisioning = false;
        
    }
}
