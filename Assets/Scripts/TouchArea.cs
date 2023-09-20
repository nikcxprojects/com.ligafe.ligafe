using UnityEngine;

public class TouchArea : MonoBehaviour
{
    private Vector2 startTouch;

    public static bool isPressing;
    public static float dragDistance;

    private void OnMouseDown()
    {
        isPressing = true;
        startTouch = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseUp()
    {
        isPressing = false;
    }

    private void OnMouseDrag()
    {
        var currentPos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dragDistance = Vector2.Distance(startTouch, currentPos);
    }
}
