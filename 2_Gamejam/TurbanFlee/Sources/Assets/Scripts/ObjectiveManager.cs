using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ObjectiveManager : MonoBehaviour {
    [SerializeField]
    private GameObject exitLight;

    public delegate void ObjectTaken(bool all);
    public static event ObjectTaken OnKeyDoor;
    
    public List<GameObject> doors;
    public int neededObjectives;
    private int earntObjectives = 0;

    public int NeededObjectives {
        get
        {
            return neededObjectives;
        }
    }
	// Use this for initialization
	void Awake () {
        ClearSubscribes();
        neededObjectives = MasterOfManagers.Master.KeyNumber;
        objeto.OnObtain += ObjectiveDone;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;

    }

    private void ClearSubscribes() {
        objeto.OnObtain -= ObjectiveDone;
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
    }

    // Update is called once per frame
    void Update () {
	
	}

    void ObjectiveDone(Object objeto, GameObject sender) {
        if(objeto == Object.Llave) {
            OnKeyDoor(false);
            earntObjectives++;
            if(earntObjectives >= neededObjectives) {
                OpenDoor();
            }
        }
    }
    void OpenDoor() {
        OnKeyDoor(true);
        GameObject dummie = Instantiate(exitLight);
        GameObject chosenDoor = doors[(int)UnityEngine.Random.Range(0, doors.Count)];
        dummie.transform.position = new Vector3(chosenDoor.transform.position.x, dummie.transform.position.y, chosenDoor.transform.position.z);
        chosenDoor.SetActive(false);
        
    }
}
