using UnityEngine;

public class CharacterBoundary : MonoBehaviour
{
    [Header("Horizontal boundaries")]
    public float minX = -13f; // left boundary
    public float maxX = 13f;  // right boundary

    private Vector3 clampedPosition;

    void Update()
    {
        // Get the current position
        clampedPosition = transform.position;

        // Clamp the X position
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, minX, maxX);

        // Apply clamped position
        transform.position = clampedPosition;
    }
}
