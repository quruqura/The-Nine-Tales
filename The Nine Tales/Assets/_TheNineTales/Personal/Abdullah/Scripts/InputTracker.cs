
using UnityEngine;

public static class InputTracker 
{
    public const string AXIS_HORIZONTAL = "Horizontal";
    public const string AXIS_VERTICAL = "Vertical";
    public const string BUTTON_JUMP = "Jump";


    public static Vector2 GetDirectionalInput()
    {
        return new Vector2(Input.GetAxisRaw(AXIS_HORIZONTAL), Input.GetAxisRaw(AXIS_VERTICAL));
    }


    public static bool WasJumpPressed()
    {
        return Input.GetButtonDown(BUTTON_JUMP);
    }


    public static bool IsJumpPressed()
    {
        return Input.GetButton(BUTTON_JUMP);
    }
}
