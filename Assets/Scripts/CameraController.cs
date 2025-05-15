using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    [SerializeField] private Camera mainCamera;
    private float followSpeed = 10f;

    void LateUpdate()
    {
        if (target && mainCamera)
        {
            Vector3 currentPos = mainCamera.transform.position;
            Vector3 targetPos = target.transform.position;
            targetPos.z = currentPos.z;

            mainCamera.transform.position = Vector3.Lerp(currentPos, targetPos, followSpeed * Time.deltaTime);
        }
    }
}
