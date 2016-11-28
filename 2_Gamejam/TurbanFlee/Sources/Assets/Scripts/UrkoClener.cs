using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class UrkoClener : MonoBehaviour{
    List<Vector3> taken;
    private void Start()
    {
        taken = new List<Vector3>() ;
        List<GameObject> gos = new List<GameObject>(GameObject.FindGameObjectsWithTag("wall"));

        foreach (GameObject goer in gos) {
            
            if (!taken.Contains(goer.transform.position)) {
                taken.Add(goer.transform.position);
                
                
            }else {
                GameObject.Destroy(goer,0);
            }
          
        }

    }

}

