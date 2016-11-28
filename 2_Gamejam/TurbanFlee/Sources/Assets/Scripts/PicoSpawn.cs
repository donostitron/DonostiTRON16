using UnityEngine;
using System.Collections.Generic;
using System;
using System.Linq;

public class PicoSpawn : MonoBehaviour {
    [SerializeField]
    private List<Vector3> spawnPoints;
    [SerializeField]
    GameObject picoPrefab;
    [SerializeField]
    List<int> navLayers = new List<int>();
    [SerializeField]
    GameObject playerFollow;

    int navlayermask = 111;
    private float waitingTime = 20;
    
    private int numberOfPicos;
    private float picoSpeed;

    int numberofKeys;
    // Use this for initialization
    void Start() {
        if (numberOfPicos > 8) {
            numberOfPicos = 8;
        }

        foreach (int mas in navLayers) {
            navlayermask += mas;

        }
        numberOfPicos = MasterOfManagers.Master.Picolonumbers;
        picoSpeed = MasterOfManagers.Master.PicoloSpeed;
        CreatePicos();


    }




    private void CreatePicos() {
        while (numberOfPicos > 0) {
            GameObject dummie = Instantiate(picoPrefab);
            dummie.transform.position = ObtainFreePosIndex();
            dummie.GetComponent<NavMeshAgent>().areaMask = navlayermask - navLayers[UnityEngine.Random.Range(0, navLayers.Count - 1)];
            dummie.GetComponent<Seguir>().follow = playerFollow;
            dummie.GetComponent<NavMeshAgent>().speed = picoSpeed;
            numberOfPicos--;
        }
        foreach (Vector3 point in spawnPoints) {

            int auxIndex = spawnPoints.IndexOf(point);
            spawnPoints[auxIndex] = new Vector3(spawnPoints[auxIndex].x, spawnPoints[auxIndex].y, 0);
        }
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
