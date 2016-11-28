using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class TimeCounter : MonoBehaviour {
    public enum EndMode {
        TimeUp, Win
    }
    public Text coundownText;
    public delegate void GameEnded(EndMode mode);
    public static event GameEnded TimeUp;
    public delegate void LowTime();
    public static event LowTime OnWarning;
    [SerializeField]
    private Text subtracter;

    public ObjectiveManager mng;
    private float timeLeft;


    private int minutes;

    private int seconds;

    private bool played = false;

    private bool called = false;

    private bool punishable = true;
    // Use this for initialization
    void Start() {
        ClearSubscribes();
        subtracter.color = new Color(1, 0, 0, 0);
        HitScript.OnPunish += ManagePunishment;
        timeLeft = MasterOfManagers.Master.TimePerKey * MasterOfManagers.Master.KeyNumber;
        MasterOfManagers.OnUnsubscribe += ClearSubscribes;
    }

    private void ClearSubscribes() {
        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
        HitScript.OnPunish -= ManagePunishment;
    }

    // Update is called once per frame


    void Update() {
        timeLeft -= Time.deltaTime;
        if (!called) {
            minutes = (int)timeLeft / 60; // minutes is the integer part of seconds/60
            seconds = (int)timeLeft % 60;
            if (seconds > 9) {

                coundownText.text = minutes + ":" + seconds;
            } else {
                coundownText.text = minutes + ":0" + seconds;
            }

        }
        if (Input.GetKeyDown(KeyCode.D)) {
            timeTaken(10);
        }
        if (timeLeft <= 0 && !called) {
            called = true;
            TimeUp(EndMode.TimeUp);
        }
        if (timeLeft <= 10) {
            if (!played) {
                played = true;
                OnWarning();
            }
        }

    }

    public void timeTaken(int seconds) {
        if (timeLeft > 0) {
            subtracter.text = "- " + seconds;
            if (timeLeft - seconds <= 0) {
                {
                    timeLeft = 0;

                    coundownText.text = minutes + ":00";
                }

            }
            timeLeft -= seconds;
            StopCoroutine("ShowHide");
            StartCoroutine("ShowHide");
        }
    }
    IEnumerator ShowHide() {
        while (subtracter.color.a <= 0.99) {
            subtracter.color = Color.Lerp(subtracter.color, new Color(1, 0, 0, 1), 0.1f);
            yield return new WaitForSeconds(.01f);

        }
        yield return new WaitForSeconds(.5f);

        while (subtracter.color.a >= 0.01) {
            subtracter.color = Color.Lerp(subtracter.color, new Color(1, 0, 0, 0), 0.1f);
            yield return new WaitForSeconds(.05f);


        }
    }

    void ManagePunishment() {
        if (punishable) {
            punishable = false;
            timeTaken(10);
            StartCoroutine("Punished");

        }
    }

    IEnumerator Punished() {
        yield return new WaitForSeconds(.5f);
        punishable = true;
    }
}
