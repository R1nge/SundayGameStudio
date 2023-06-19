using UnityEngine;

namespace Task_2_1.Scripts
{
    public class ObjectRotator : MonoBehaviour
    {
        [SerializeField] private float speed;

        [SerializeField, Tooltip("Only 0 and 1 values are allowed")]
        private Vector3 direction;

        private void OnValidate() => ValidateDirection();

        private void Update() => Rotate();

        private void Rotate() => transform.Rotate(direction * (speed * Time.deltaTime));

        private void ValidateDirection()
        {
            ValidateValue(ref direction.x);
            ValidateValue(ref direction.y);
            ValidateValue(ref direction.z);
        }

        private void ValidateValue(ref float value)
        {
            if (value is < 1 and > 0)
            {
                value = 1;
            }
            else if (value is < -1 and < 0)
            {
                value = -1;
            }
            else if (value < -1)
            {
                value = -1;
            }
            else if (value > 1)
            {
                value = 1;
            }
        }
    }
}