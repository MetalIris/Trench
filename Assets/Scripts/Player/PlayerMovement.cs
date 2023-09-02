using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed = 5f;
        [SerializeField] private Joystick joystick;
        [SerializeField] private Rigidbody2D playerRigidbody;
        [SerializeField] private Animator animator;
        
        private bool isPlayerMoving;

        private void FixedUpdate()
        {
            Debug.Log(PlayerPrefs.GetInt("CurrentLevel"));
            
            var horizontalInput = joystick.Horizontal;
            var verticalInput = joystick.Vertical;

            var movement = new Vector2(horizontalInput, verticalInput);
            movement.Normalize();
            
            isPlayerMoving = movement.magnitude > 0f;
            
            animator.SetFloat("Speed", Mathf.Max(Mathf.Abs(horizontalInput), Mathf.Abs(verticalInput)));
            
            playerRigidbody.MovePosition(playerRigidbody.position + movement * (playerSpeed * Time.fixedDeltaTime));

            if (movement == Vector2.zero) return;
            var targetAngle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
            playerRigidbody.MoveRotation(targetAngle);
        }
    }
}
