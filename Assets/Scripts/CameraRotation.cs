using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float swayAmount = 0.2f;
    [SerializeField] private float swaySpeed = 2f;

    private float _initialXRotation;
    private float _initialYRotation;

    private void Start()
    {
        _initialXRotation = transform.rotation.eulerAngles.x;
        _initialYRotation = transform.rotation.eulerAngles.y;
    }

    public void CameraRotaiton()
    {
        float swayX = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        float swayY = Mathf.Sin(Time.time * swaySpeed * 0.7f) * swayAmount;

        Quaternion targetRotation = Quaternion.Euler(_initialXRotation + swayX, _initialYRotation + swayY, 
            transform.rotation.eulerAngles.z);
        transform.rotation = targetRotation;
    }
}
