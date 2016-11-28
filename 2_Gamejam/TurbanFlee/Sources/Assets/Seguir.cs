using UnityEngine;
using System.Collections;

public class Seguir : MonoBehaviour {
    NavMeshAgent agent;
    
    public GameObject follow;

    bool recalculating = false;
    [SerializeField]
   public float recalculateTime = .5f;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        
        agent.SetDestination(follow.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (!recalculating) {
            recalculating = true;
            StartCoroutine("recalculate");
        }
	}

    IEnumerator recalculate() {
        
        yield return new WaitForSeconds(recalculateTime);
        agent.SetDestination(follow.transform.position);
        recalculating = false;
    }
}
