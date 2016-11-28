using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;

public class Spawner : MonoBehaviour {
    [SerializeField]
    private List<Vector3> spawnPoints;
    [SerializeField]
    GameObject keyPrefab;
    [SerializeField]
    GameObject coranPrefab;

    private float waitingTime ;

    [SerializeField]
    private ObjectiveManager mng;

    int numberofKeys;
    // Use this for initialization
    void Start() {
        ClearSubscribes();
        waitingTime = MasterOfManagers.Master.CoranCycle;
        objeto.OnObtain += LiberatePos;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;
        
        numberofKeys = mng.NeededObjectives;
        CreateKeys();
        if (coranPrefab != null) {
            StartCoroutine(CoranCycle());
            objeto.OnObtain += RestartCoran;

        }

    }

    private void ClearSubscribes() {
        
        objeto.OnObtain -= LiberatePos;
        objeto.OnObtain -= RestartCoran;
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
    }

    private void RestartCoran(Object objs, GameObject sender) {
        if (objs == Object.Coran) {
                StartCoroutine(CoranCycle());
        }
    }

    private IEnumerator CoranCycle() {
        yield return new WaitForSeconds(waitingTime);
        GameObject dummie = Instantiate(coranPrefab);
        Vector3 dummie2 = ObtainFreePosIndex();
        if (dummie2 != null) {
            dummie.transform.position = dummie2;
        }


    }

    private void CreateKeys() {
        while (numberofKeys > 0) {
            GameObject dummie = Instantiate(keyPrefab);
            dummie.transform.position = ObtainFreePosIndex();
            numberofKeys--;
        }
    }

    private void LiberatePos(Object objs, GameObject sender) {
        int index = spawnPoints.IndexOf(new Vector3(sender.transform.position.x, sender.transform.position.z, 1));
        spawnPoints[index] = new Vector3(spawnPoints[index].x, spawnPoints[index].y, 0);
    }
    private Vector3 ObtainFreePosIndex() {
        List<Vector3> raw = spawnPoints.Where(i => i.z == 0).ToList<Vector3>();
        Vector3 chosenRaw = raw[UnityEngine.Random.Range(0, raw.Count - 1)];
        if (raw != null) {
            int index = spawnPoints.IndexOf(chosenRaw);
            spawnPoints[index] = new Vector3(spawnPoints[index].x, spawnPoints[index].y, 1);
            return new Vector3(chosenRaw.x, 0.621f, chosenRaw.y);
        } else {
            return new Vector3(-666, -666, -666);
        }

    }

    // Update is called once per frame
    void Update() {

    }

}
