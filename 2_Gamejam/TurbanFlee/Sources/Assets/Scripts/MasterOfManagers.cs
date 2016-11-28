using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MasterOfManagers {

    private static MasterOfManagers master;
    float timePerKey;
    int keyNumber;
    int picolonumbers;
    float picoloSpeed;
    int day;
    float coranCycle;
    int picoloIndex;

    public delegate void Unsubscriber();
    public static event Unsubscriber OnUnsubscribe;

    public float TimePerKey { get { return timePerKey; } }
    public int KeyNumber { get { return keyNumber; } }
    public int Picolonumbers { get { return picolonumbers; } }
    public float PicoloSpeed { get { return picoloSpeed; } }
    public int Day { get { return day; } }
    public float CoranCycle { get { return coranCycle; } }


    public static MasterOfManagers Master {
        get
        {
            if (master == null) {
                master = new MasterOfManagers();
            }
            return master;
        }
    }

    MasterOfManagers() {
        day = 0;
        timePerKey = 15;
        picoloSpeed = 4;
        picolonumbers = 1;
        coranCycle = 20;
        keyNumber = 3;
        picoloIndex = 0;/*
        timePerKey -= Random.Range(10, 15);
        picoloSpeed = Random.Range(4, 8);
        keyNumber = Random.Range(3, 8);
        picolonumbers = Random.Range(3, 8);*/

    }

    public void NextLevel(bool firstDay) {

        OnUnsubscribe();
        day++;
        if (!firstDay) {

            if (timePerKey >= 3) {
                timePerKey -= Random.Range(1f, 2f);
            }
            picoloSpeed += Random.Range(0.2f, 0.4f);
            keyNumber = Random.Range(3, 10);
            if (picoloIndex <= 7) {
                picoloIndex++;
            }
            picolonumbers = Random.Range(picoloIndex, picoloIndex + 1);
            if (coranCycle > 1) {
                coranCycle -= Random.Range(1f, 2f);

            }
        }else {
            day = 1;
            timePerKey = 15;
            picoloSpeed = 4;
            picolonumbers = 1;
            coranCycle = 20;
            keyNumber = 3;
            picoloIndex = 0;
        }

        
        SceneManager.LoadScene(1);
    }




}
