using UnityEngine;
using System.Collections;

using UnityEngine.UI;
using System;

public class Boton1 : MonoBehaviour {

    public Button boton1 = null;
    public Button boton2 = null;
  //  public Enabler level;
    // public Enabler menu;

    private int i = 0;
    private void Start() {
        int day = MasterOfManagers.Master.Day;
        MasterOfManagers.OnUnsubscribe += DoSomething;

    }

    private void DoSomething() {
        Debug.Log("Doing Something");
        MasterOfManagers.OnUnsubscribe -= DoSomething;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            i = 0;
            boton2.image.color = Color.gray;
            boton1.image.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            i = 1;
            boton1.image.color = Color.gray;
            boton2.image.color = Color.white;
        }

        if (Input.GetKeyDown(KeyCode.V)) {
            if (i == 0)
                //MasterOfManagers.Master.CleanSubcribes();
                //  level.EnableObjects(true);
                //menu.EnableObjects(false);
                MasterOfManagers.Master.NextLevel(true);
            if (i == 1) {

                Application.Quit();
            }
        }
    }
}
