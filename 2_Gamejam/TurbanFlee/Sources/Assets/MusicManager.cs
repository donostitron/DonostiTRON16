using UnityEngine;
using System.Collections;
using System;

public class MusicManager : MonoBehaviour {
    public AudioSource ost;
    public AudioSource countdown;
    public AudioSource gameOver;
    public AudioSource hit;
    public AudioSource key;
    public AudioSource openDoor;
    public AudioSource takeCoran;
    private bool ended;
    // Use this for initialization
    void Awake() {
        ended = false;
        ClearSubscribes();
        HitScript.OnPunish += playHit;
        TimeCounter.TimeUp += playGameOver;
        ObjectiveManager.OnKeyDoor += playOpenDoorKey;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;
        TimeCounter.OnWarning += playCountdown;
        MovePrimitive.OnCoran += playTakeCoran;
        Win.OnWin += playWin;

    }
    private void Update() {
        if (ended) {
            ClearSubscribes();
            ended = false;
        }
    }
    private void ClearSubscribes() {
        HitScript.OnPunish -= playHit;
        TimeCounter.TimeUp -= playGameOver;
        ObjectiveManager.OnKeyDoor -= playOpenDoorKey;
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
        TimeCounter.OnWarning -= playCountdown;
        MovePrimitive.OnCoran -= playTakeCoran;
        Win.OnWin -= playWin;
    }

    private void playOpenDoorKey(bool all) {
        if (!all) {
            key.Play();
        }
        if (all) {
            openDoor.Play();
        }
    }

    void playGameOver(TimeCounter.EndMode mode) {
        if (mode == TimeCounter.EndMode.TimeUp) {
            ended = true;
            countdown.Stop();
            ost.Stop();
            gameOver.Play();
        }
    }
    void playWin(TimeCounter.EndMode awesome) {

        ended = true;
        countdown.Stop();
        ost.Stop();
        takeCoran.Play();

    }

    void playOST() {
        ost.loop = true;
        ost.Play();
    }

    void playCountdown() {
        countdown.loop = true;
        countdown.Play();
    }


    void playHit() {
        hit.Play();
    }

    void playTakeCoran() {
        takeCoran.Play();
    }
    void lowTime() {
        countdown.loop = true;
        countdown.Play();
    }
}
