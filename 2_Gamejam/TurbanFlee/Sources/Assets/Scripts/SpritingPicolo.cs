using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpritingPicolo : MonoBehaviour {
    public float interval;

    [SerializeField]
    private List<Sprite> upAnim;
    [SerializeField]
    private List<Sprite> leftAnim;
    [SerializeField]
    private List<Sprite> rightAnim;
    [SerializeField]
    private List<Sprite> downAnim;
    private List<Sprite> currentAnim;

    private int spriteIndex;
    private bool working=false;

    float xcalc;
    float zcalc;
    
    [SerializeField]
    private SpriteRenderer renderer;

    private NavMeshAgent agent;
    // Use this for initialization
    void Start () {
        currentAnim = downAnim;
        spriteIndex = currentAnim.Count;
        agent = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        //animate
        if (!working) {
            working = true;
            if (spriteIndex >= currentAnim.Count) {
                spriteIndex = 0;
            }
            renderer.sprite = currentAnim[spriteIndex];
            spriteIndex++;
            StartCoroutine(Jenkins());
        }
        xcalc = agent.nextPosition.x - transform.position.x;
        zcalc = agent.nextPosition.z - transform.position.z;
        if (xcalc> 0&& xcalc > zcalc&&currentAnim!=rightAnim) {
            Debug.Log("Right");
            ChangeCurrentAnim(rightAnim);
        }
        if (xcalc > 0 && xcalc < zcalc && currentAnim != upAnim) {
            Debug.Log("Up");
            ChangeCurrentAnim(upAnim);
        }
        if(xcalc<0 && xcalc < zcalc && currentAnim != leftAnim) {
            Debug.Log("Left");
            ChangeCurrentAnim(leftAnim);
        }
        if (xcalc < 0 && xcalc > zcalc && currentAnim != downAnim) {
            Debug.Log("Down");
            ChangeCurrentAnim(downAnim);
        }



    }

    void ChangeCurrentAnim(List<Sprite> sprites) {
        currentAnim = sprites;
        spriteIndex = 0;
    }
    IEnumerator Jenkins() {
        yield return new WaitForSeconds(interval);
        working = false;
    }
}
