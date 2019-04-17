using UnityEngine;

public class InputComponent : IInputComponent
{
    public float GetAxis(string axisName)
    {
        return Input.GetAxis(axisName);
    }
    
    public float GetAxisRaw(string axisName)
    {
        return Input.GetAxisRaw(axisName);
    }

    public bool GetKeyDown(KeyCode keyCode)
    {
        return Input.GetKeyDown(keyCode);
    }

    public bool GetKeyUp(KeyCode keyCode)
    {
        return Input.GetKeyUp(keyCode);
    }

    public bool GetKey(KeyCode keyCode)
    {
        return Input.GetKey(keyCode);
    }

}