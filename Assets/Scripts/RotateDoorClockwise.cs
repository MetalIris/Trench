using UnityEngine;

public class RotateDoorClockwise : MonoBehaviour
{
    private DoorMovement dm;

    private void Start()
    {
        dm = GetComponentInParent<DoorMovement>();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        dm.RotateClockwise();
        dm.beingOpened = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        dm.beingOpened = false;
    }
}