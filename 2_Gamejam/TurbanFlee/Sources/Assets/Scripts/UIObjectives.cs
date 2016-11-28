using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class UIObjectives : MonoBehaviour {
    
    [SerializeField]
    ObjectiveManager objectiveMng;
    public GameObject key;
    List<GameObject> keys;
    int index = 0;
    [SerializeField]
    RectTransform parent;

	// Use this for initialization
	void Awake () {
        ClearSubscribes();
        keys = new List<GameObject>();
        int numberOfObjectives = MasterOfManagers.Master.KeyNumber;
        Debug.Log(objectiveMng.neededObjectives);

        while (numberOfObjectives > 0) {
            GameObject dummie = (GameObject)Instantiate(key);
            dummie.transform.SetParent(parent, false);
            keys.Add(dummie);
            numberOfObjectives-=1;
        }
        objeto.OnObtain += GotKey;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;

    }

    private void ClearSubscribes() {
        objeto.OnObtain -= GotKey;
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
    }

    private void GotKey(Object objs, GameObject sender) {
        if(objs == Object.Llave) {
            keys[index].GetComponent<Image>().color = Color.white;
            index++;
        }
    }


    // Update is called once per frame
    void Update () {
	    
	}
}
