using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;

public class MovePlayer : MonoBehaviour {
    EnteredInput previousDirection;
    EnteredInput nextDirection;
    bool working = false;
    [SerializeField]
    bool iddle = true;
    Vector3 newpos;
    [SerializeField]
    private List<Bounder> bounds;
    [SerializeField]
    float speedMultiplier = 1f;

    CharacterController player;


    [SerializeField]
    private float step;

    // Use this for initialization
    void Start() {
        ClearSubscribes();
        nextDirection = EnteredInput.Right;
        InputManager.OnPressed += ChooseDirection;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;
        player = GetComponent<CharacterController>();


    }

    // Update is called once per frame
    void Update() {
        if (!iddle && !working) {
            switch (nextDirection) {
                case EnteredInput.Right:
                    if (CanMove(2)) {
                        newpos = Vector3.right;
                    } else {
                        if (previousDirection == EnteredInput.Right) {
                            iddle = true;
                        }
                    }
                    break;
                case EnteredInput.Left:
                    if (CanMove(1)) {
                        newpos = Vector3.left;
                    } else {
                        if (previousDirection == EnteredInput.Left) {
                            iddle = true;
                        }
                    }
                    break;
                case EnteredInput.Up:
                    if (CanMove(0)) {
                        newpos = Vector3.forward;
                    } else {
                        if (previousDirection == EnteredInput.Up) {
                            iddle = true;
                        }
                    }
                    break;
                case EnteredInput.Down:
                    if (CanMove(3)) {
                        newpos = Vector3.back;
                    } else {
                        if (previousDirection == EnteredInput.Down) {
                            iddle = true;
                        }
                    }
                    break;
            }
            working = true;
            Move(newpos);
            StartCoroutine("Move", newpos);


        }



    }
    void ChooseDirection(EnteredInput direction) {
        iddle = false;

        nextDirection = direction;

    }
    IEnumerator Move(Vector3 position) {
       
        player.Move(position*speedMultiplier);
          
        
        working = false;

        yield return null;
        /*transform.DOMove(position, 1).OnComplete(() =>
        {
            transform.position = newpos;

            working = false;
        });*/

    }
    private bool CanMove(int index) {
        bool canmove = true;

        if (bounds[index].Colisioning) {
            canmove = false;
        }

        return canmove;
    }
    public void ClearSubscribes() {
        InputManager.OnPressed -= ChooseDirection;
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
    }

}
