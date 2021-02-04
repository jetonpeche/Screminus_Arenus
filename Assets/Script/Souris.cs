using UnityEngine;

public class Souris : MonoBehaviour
{
    void Start()
    {
        BloquerCurseur();
    }

    public static void BloquerCurseur()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public static void DebloquerCurseur()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
