using UnityEngine;

public static class CursorController
{
    public static bool IsCursorVisible => Cursor.visible;

    #region Cursor Toggle Method
    /// <summary>Disable cursor.</summary>
    public static void DisableCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    /// <summary>Enable cursor.</summary>
    public static void EnableCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    #endregion
}