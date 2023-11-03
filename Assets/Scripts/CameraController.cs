using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f; 
    public float minZPosition = -7.0f;
    public float maxZPosition = 7.0f; 

    private Vector3 lastMousePosition;

    private void Update()
    {
        // Calculate the difference in mouse or touch input
        if (Input.GetMouseButtonDown(0))
        {
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 currentMousePosition = Input.mousePosition;
            float zMovement = (currentMousePosition.y - lastMousePosition.y) * moveSpeed * Time.deltaTime;

            // Calculate the new Z position of the camera
            float newZPosition = transform.position.z + zMovement;

            // Clamp the Z position within the limits
            newZPosition = Mathf.Clamp(newZPosition, minZPosition, maxZPosition);

            // Set the new position of the camera
            Vector3 newPosition = transform.position;
            newPosition.z = newZPosition;
            transform.position = newPosition;

            lastMousePosition = currentMousePosition;
        }
    }
}
