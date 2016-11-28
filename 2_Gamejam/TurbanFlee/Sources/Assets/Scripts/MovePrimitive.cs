using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Collections.Generic;
using System;

public class MovePrimitive : MonoBehaviour
{
    EnteredInput previousDirection;
    EnteredInput nextDirection;
    bool working = false;
    [SerializeField]
    bool iddle = true;
    Vector3 newpos;
    [SerializeField]
    private List<Bounder> bounds;
    public delegate void CoranUP();
    public static event CoranUP OnCoran;


    [SerializeField]
    private float step;

    private bool ready;
    // Use this for initialization
    void Awake()
    {
        CleanOnSubscribes();
        gameObject.transform.position = new Vector3(1, 0, 1);

        nextDirection = EnteredInput.Right;
        InputManager.OnPressed += ChooseDirection;
        objeto.OnObtain += ActivatePowerUp;
        MasterOfManagers.OnUnsubscribe += CleanOnSubscribes;

    }

    private void CleanOnSubscribes() {
        objeto.OnObtain -= ActivatePowerUp;
        MasterOfManagers.OnUnsubscribe -= CleanOnSubscribes;
    }

    private void ActivatePowerUp(Object objs, GameObject sender) {
        if(objs == Object.Coran) {
            OnCoran();
            ready =true;
        }
    }

    private IEnumerator SpeedUp() {
        
        step += .15f;
        yield return new WaitForSeconds(5);
        step -= .15f;
    }

    // Update is called once per frame
    void Update()
    {if(ready && Input.GetKeyDown(KeyCode.V)) {
            StartCoroutine(SpeedUp());
            ready = false;
        }
        if (!iddle && !working)
        {
            switch (nextDirection)
            {
                case EnteredInput.Right:
                    if (CanMove(2))
                    {
                        newpos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        if (previousDirection == EnteredInput.Right)
                        {
                            iddle = true;
                        }
                    }
                    break;
                case EnteredInput.Left:
                    if (CanMove(1))
                    {
                        newpos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                    }
                    else
                    {
                        if (previousDirection == EnteredInput.Left)
                        {
                            iddle = true;
                        }
                    }
                    break;
                case EnteredInput.Up:
                    if (CanMove(0))
                    {
                        newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
                    }
                    else
                    {
                        if (previousDirection == EnteredInput.Up)
                        {
                            iddle = true;
                        }
                    }
                    break;
                case EnteredInput.Down:
                    if (CanMove(3))
                    {
                        newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
                    }
                    else
                    {
                        if (previousDirection == EnteredInput.Down)
                        {
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
    void ChooseDirection(EnteredInput direction)
    {
        iddle = false;
       
        nextDirection = direction;

    }
    IEnumerator Move(Vector3 position)
    {
        while((transform.position-newpos).magnitude >= step){
            transform.position = Vector3.MoveTowards(transform.position, newpos,step);
            
            yield return new WaitForSeconds(.025f);
        }
        transform.position = newpos;
        working = false;
        /*transform.DOMove(position, 1).OnComplete(() =>
        {
            transform.position = newpos;

            working = false;
        });*/

    }
    private bool CanMove(int index)
    {
        bool canmove = true;
        
            if (bounds[index].Colisioning)
            {
                canmove = false;
            }
        
        return canmove;
    }

}
