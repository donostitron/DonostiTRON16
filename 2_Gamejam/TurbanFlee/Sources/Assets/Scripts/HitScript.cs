using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {


    public delegate void PunishedPlayer();
    public static event PunishedPlayer OnPunish;
    // Use this for initialization

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Punisher") {
            OnPunish();
        }
    }
    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Punisher") {
            
            OnPunish();
        }
    }
}
