using System;
using UnityEngine;

namespace Task_2_3.Scripts
{
    public class CharacterCamera : MonoBehaviour
    {
        [SerializeField] private FixedJoystick lookJoystick;
        [SerializeField] private float sensitivity = 2.0f;
        [SerializeField] private GameObject cameraTarget;
        [SerializeField] private float topClamp = 70.0f;
        [SerializeField] private float bottomClamp = -30.0f;
        [SerializeField] private float cameraAngleOverride;
        private float _targetYaw;
        private float _targetPitch;
        
        private void Start()
        {
            _targetYaw = cameraTarget.transform.rotation.eulerAngles.y;
        }

        private void LateUpdate() => Rotate();

        private void Rotate()
        {
            _targetYaw += lookJoystick.Horizontal * Time.deltaTime * sensitivity;
            _targetPitch += lookJoystick.Vertical * Time.deltaTime * sensitivity;

            _targetYaw = ClampAngle(_targetYaw, float.MinValue, float.MaxValue);
            _targetPitch = ClampAngle(_targetPitch, bottomClamp, topClamp);

            cameraTarget.transform.rotation =
                Quaternion.Euler(_targetPitch + cameraAngleOverride,
                    _targetYaw,
                    0.0f);
        }

        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}