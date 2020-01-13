using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInputManager : InputManager
{
    public static event MoveInputHandler OnMoveInput;
    public static event RotateInputHandler OnRotateInput;
    public static event ZoomInputHandler OnZoomInput;
    public static event FocusCharacterHandler OnFocusCharacter;

    [SerializeField]
    public GameObject character;

    // Update is called once per frame
    void Update()
    {
        //Move
        if (Input.GetKey(KeyCode.UpArrow))
        {
            OnMoveInput?.Invoke(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            OnMoveInput?.Invoke(-Vector3.forward);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            OnMoveInput?.Invoke(-Vector3.right);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            OnMoveInput?.Invoke(Vector3.right);
        }

        //rotate
        if (Input.GetKey(KeyCode.Q))
        {
            OnRotateInput?.Invoke(-1f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            OnRotateInput?.Invoke(1f);
        }

        //zoom
        if (Input.GetKey(KeyCode.R))
        {
            OnZoomInput?.Invoke(-1f);
        }
        if (Input.GetKey(KeyCode.T))
        {
            OnZoomInput?.Invoke(1f);
        }


        if (Input.GetKey(KeyCode.Alpha1))
        {
            OnFocusCharacter?.Invoke(true);
        }

    }
}
