using UnityEngine;

namespace Task_2_3.Scripts
{
    public class FootprintController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Vector3 offset;
        [SerializeField] private Transform playerModel;
        [SerializeField] private ParticleSystem system;
        [SerializeField] private float delta = 1;
        [SerializeField] private float gap = 0.5f;
        private int _dir = 1;
        private Vector3 _lastEmit;

        private void Start() => _lastEmit = playerModel.transform.position;

        private void Update()
        {
            if (Vector3.Distance(_lastEmit, playerModel.transform.position) > delta && characterController.isGrounded)
            {
                var pos = playerModel.transform.position + playerModel.transform.right * (gap * _dir) + offset;
                _dir *= -1;
                ParticleSystem.EmitParams emitParams = new ParticleSystem.EmitParams
                {
                    position = pos,
                    rotation = playerModel.transform.rotation.eulerAngles.y
                };
                system.Emit(emitParams, 1);
                _lastEmit = playerModel.transform.position;
            }
        }
    }
}