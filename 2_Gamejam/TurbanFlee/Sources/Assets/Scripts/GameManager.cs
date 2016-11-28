using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System;

public class GameManager : MonoBehaviour {
    
    public GameObject restartMenu;
    
    public GameObject winMenu;

    public GameObject Player;
    [SerializeField]
    InputManager inputmng;


    


    bool ended = false;
    bool won = false;
    // Use this for initialization
    void Awake() {
        ClearSubscribes();
        if (GameObject.FindGameObjectsWithTag("GameManager").Length > 1) {
            Destroy(GameObject.FindGameObjectsWithTag("GameManager")[0]);
        }
        TimeCounter.TimeUp += EndGame;
        Win.OnWin += WinGame;

        MasterOfManagers.OnUnsubscribe += ClearSubscribes;

    }

    private void ClearSubscribes() {
        TimeCounter.TimeUp -= EndGame;
        Win.OnWin -= WinGame;

        MasterOfManagers.OnUnsubscribe -= ClearSubscribes;
    }

    // Update is called once per frame
    void Update() {
        if (ended && Input.GetKeyDown(KeyCode.Escape)) {
           SceneManager.LoadSceneAsync(0);
           
        }
        if (won && (Input.GetKeyDown(KeyCode.V)|| Input.GetKeyDown(KeyCode.X)|| Input.GetKeyDown(KeyCode.Z)|| Input.GetKeyDown(KeyCode.C))) {
            MasterOfManagers.Master.NextLevel(false);
        }

    }

    void EndGame(TimeCounter.EndMode mode) {
        if (!won) {
            inputmng.ToggleInput();
            restartMenu.SetActive(true);
            ended = true;
        }

    }
    void WinGame(TimeCounter.EndMode mode) {
        if (!ended) {
            inputmng.ToggleInput();
            winMenu.SetActive(true);
            won= true;
        }


    }

    void RestartGame() {
        inputmng.ToggleInput();
        restartMenu.gameObject.SetActive(false);
        //posicionar polis
        //resetar puerta y llaves(UI y no UI)
    }
    public void end() {

    }


}
