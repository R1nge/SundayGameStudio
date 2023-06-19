using UnityEngine;

namespace Task_2_2.Scripts
{
    public class CarController : MonoBehaviour
    {
        [SerializeField] private Transform centerOfMass;
        [SerializeField] private float accelerationTime, timeToStop;
        [SerializeField] private float maxSpeed, maxBackSpeed;
        [SerializeField] private float distanceToGround;
        [SerializeField] private float maxSteerAngle;
        [SerializeField] private Transform[] frontWheels, rearWheels;
        [SerializeField] private WheelCollider[] frontWheelsColliders, rearWheelColliders;
        private float _steeringAngle;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _rigidbody.centerOfMass = centerOfMass.localPosition;
        }

        private void FixedUpdate()
        {
            UpdateWheelPoses();
            DownForce();
        }

        public void ResetSteer() => Steer(0);

        public void SteerLeftMobile() => Steer(-1);

        public void SteerRightMobile() => Steer(1);

        public void ForwardMobile()
        {
            if (GetCurrentSpeedKmh() <= maxSpeed)
            {
                SetTorque(1 * CalculateAcceleration(maxSpeed));
            }
        }

        public void BackwardMobile()
        {
            if (GetCurrentSpeedKmh() <= maxBackSpeed)
            {
                SetTorque(-1 * CalculateAcceleration(maxBackSpeed));
            }
        }
        
        public void StopAccelerateMobile() => SetTorque(0);
        
        public void StopBrakingMobile() => SetBrakeTorque(0);

        public void BrakeMobile()
        {
            if (GetCurrentSpeedKmh() >= 0.1f)
            {
                SetBrakeTorque(CalculateBrakeTorque());
            }
            else
            {
                SetBrakeTorque(0);
            }

            SetTorque(0);
        }

        private float CalculateAcceleration(float max)
        {
            var current = GetCurrentSpeedMs();
            var accelerationRate = (max - current) / accelerationTime;
            return accelerationRate * _rigidbody.mass;
        }

        private float CalculateBrakeTorque()
        {
            var momentum = _rigidbody.mass * maxSpeed * 3600 * 1000;
            var torque = momentum / timeToStop;
            var force = torque * rearWheelColliders[0].forwardFriction.stiffness * 2;
            return force * 2;
        }

        private void Steer(float input)
        {
            _steeringAngle = maxSteerAngle * input;

            for (int i = 0; i < frontWheels.Length; i++)
            {
                frontWheelsColliders[i].steerAngle = _steeringAngle;
            }
        }

        private void SetTorque(float value)
        {
            for (int i = 0; i < rearWheelColliders.Length; i++)
            {
                var wheel = rearWheelColliders[i];
                wheel.motorTorque = value;
            }
        }

        private void SetBrakeTorque(float value)
        {
            if (value < 0)
            {
                value *= -1;
            }

            for (int i = 0; i < rearWheelColliders.Length; i++)
            {
                var wheel = rearWheelColliders[i];
                wheel.brakeTorque = value;
            }
        }

        private void UpdateWheelPoses()
        {
            for (int i = 0; i < frontWheels.Length; i++)
            {
                UpdateWheelPose(frontWheels[i], frontWheelsColliders[i]);
            }

            for (int i = 0; i < rearWheels.Length; i++)
            {
                UpdateWheelPose(rearWheels[i], rearWheelColliders[i]);
            }
        }

        private void UpdateWheelPose(Transform transform, WheelCollider collider)
        {
            collider.GetWorldPose(out var pos, out var quat);
            transform.position = pos;
            transform.rotation = quat;
        }

        private void DownForce()
        {
            if (!IsGrounded()) return;
            _rigidbody.AddForce(Vector3.down * 25f);
        }

        private float GetCurrentSpeedKmh() => _rigidbody.velocity.magnitude * 3.6f;

        private float GetCurrentSpeedMs() => _rigidbody.velocity.magnitude;

        private bool IsGrounded()
        {
            return Physics.Raycast(transform.position + new Vector3(0, .1f, 0), -Vector3.up, distanceToGround);
        }
    }
}