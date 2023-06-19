using UnityEngine;

namespace Task_2_3.Scripts
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 7.5f;
        [SerializeField] private float jumpSpeed = 8.0f;
        [SerializeField] private float gravity = 20.0f;
        [SerializeField] private FixedJoystick moveJoystick;
        [SerializeField] private Camera playerCamera;
        [SerializeField] private Transform playerModel;
        private Vector3 _moveDirection = Vector3.zero;
        private CharacterController _characterController;
        private CharacterAnimations _characterAnimations;
        private float _rotationVelocity;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _characterAnimations = GetComponent<CharacterAnimations>();
        }

        private void Update()
        {
            Move();
            Rotate();
        }

        public void JumpMobile()
        {
            if (_characterController.isGrounded)
            {
                _moveDirection.y = jumpSpeed;
                _characterController.Move(_moveDirection * Time.deltaTime);
            }
        }

        private void Move()
        {
            if (_characterController.isGrounded)
            {
                Vector3 forward = playerCamera.transform.forward;
                forward.y = 0;
                Vector3 right = playerCamera.transform.right;
                right.y = 0;
                float curSpeedX = moveSpeed * moveJoystick.Vertical;
                float curSpeedY = moveSpeed * moveJoystick.Horizontal;
                _moveDirection = forward * curSpeedX + right * curSpeedY;

                if (Input.GetButton("Jump"))
                {
                    _moveDirection.y = jumpSpeed;
                }

                _characterAnimations.PlayWalkAnimation(Mathf.Abs(_moveDirection.x) + Mathf.Abs(_moveDirection.z));
            }

            _moveDirection.y -= gravity * Time.deltaTime;

            _characterController.Move(_moveDirection * Time.deltaTime);
        }

        private void Rotate()
        {
            if (_moveDirection.x == 0 && _moveDirection.z == 0) return;
            var dir = _moveDirection;
            dir.y = 0;
            playerModel.transform.LookAt(playerModel.transform.position + dir, Vector3.up);
        }
    }
}