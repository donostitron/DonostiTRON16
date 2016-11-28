using UnityEngine;
using System.Collections;

public enum EnteredInput { Right, Left, Up, Down }
public class InputManager : MonoBehaviour {

    public delegate void PressedKey(EnteredInput direction);
    public static event PressedKey OnPressed;
    public bool inputEnabled = true;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (inputEnabled) {

            if (Input.GetKeyDown(KeyCode.UpArrow)) {
                OnPressed(EnteredInput.Up);

            }
            if (Input.GetKeyDown(KeyCode.DownArrow)) {
                OnPressed(EnteredInput.Down);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                OnPressed(EnteredInput.Left);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                OnPressed(EnteredInput.Right);
            }
        }
    }

    public void ToggleInput() {
        inputEnabled = !inputEnabled;
    }
}
