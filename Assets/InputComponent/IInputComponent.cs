using UnityEngine;

public interface IInputComponent
{
    float GetAxis(string axisName);
    float GetAxisRaw(string axisName);
    
    bool GetKeyDown(KeyCode keyCode);
    bool GetKeyUp(KeyCode keyCode);
    bool GetKey(KeyCode keyCode);
}