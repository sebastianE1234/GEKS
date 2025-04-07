using UnityEngine;

public class ScreenBoundary : MonoBehaviour
{
    void LateUpdate()
    {
        // Clamp the character's X position within the screen bounds
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f); // Modify values as needed
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }
}
