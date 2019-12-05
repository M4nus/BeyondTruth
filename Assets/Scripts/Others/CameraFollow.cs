using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 10f;

    private void FixedUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = new Vector3(smoothedPosition.x, transform.position.y, transform.position.z);
    }
}
