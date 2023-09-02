using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    private float currentSpeed;
    private float startRot;
    
    [SerializeField] private float rotationSpeed = 3f;
    [SerializeField]private float rotationDamping = 1f;
    
    public bool beingOpened;

    private void Start()
    {
        startRot = transform.eulerAngles.z;
    }

    private void Update()
    {
        if (!beingOpened)
        {
            float currentRot = transform.eulerAngles.z;

            if (currentRot > startRot)
                RotateClockwise();
            else if (currentRot < startRot)
                RotateAntiClockwise();
        }
    }

    public void RotateClockwise()
    {
        if (beingOpened)
        {
            transform.Rotate(Vector3.back * (rotationSpeed * Time.deltaTime));
        }
        else
        {
            currentSpeed *= Mathf.Clamp01(1f - rotationDamping * Time.deltaTime);
            if (currentSpeed <= 0.01f)
            {
                currentSpeed = 0f;
            }
        }
    }

    public void RotateAntiClockwise()
    {
        if (beingOpened)
        {
            transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
        }
        else
        {
            currentSpeed *= Mathf.Clamp01(1f - rotationDamping * Time.deltaTime);
            if (currentSpeed <= 0.01f)
            {
                currentSpeed = 0f;
            }
        }
    }
}