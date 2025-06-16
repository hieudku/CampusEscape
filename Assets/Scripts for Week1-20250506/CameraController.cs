using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;        // Reference to the player object
    public Vector3 offset = new Vector3(1.5f, 2.5f, -4.5f); // Adjustable in Inspector
    public float followSpeed = 5f;
    public float rotationSpeed = 5f;

    void LateUpdate()
    {
        // Calculate desired position based on player's orientation
        Vector3 desiredPosition = player.transform.position + player.transform.TransformDirection(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // Smoothly rotate the camera to face the same direction as the player
        Quaternion desiredRotation = Quaternion.LookRotation(player.transform.forward + Vector3.down * 0.2f);

        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
