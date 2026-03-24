using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 2f, -3.5f);
    [SerializeField] private float followSpeed = 3f;
    [SerializeField] private float lookHeight = 1.6f;
    [SerializeField] private float positionSmoothTime = 0.12f;

    private Vector3 velocity;

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, positionSmoothTime, followSpeed);

        Vector3 lookTarget = target.position + Vector3.up * lookHeight;
        transform.rotation = Quaternion.LookRotation(lookTarget - transform.position, Vector3.up);
    }
}
