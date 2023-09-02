using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothing = 5f;
    [SerializeField] private Vector3 offset;

    [Inject] private CameraRotation _cameraRotation;

    private bool _playerMoving;

    public Transform target;
    
    private void FixedUpdate()
    {
        if (target != null)
        {
            var targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
            
            _cameraRotation.CameraRotaiton();
        }
    }
}