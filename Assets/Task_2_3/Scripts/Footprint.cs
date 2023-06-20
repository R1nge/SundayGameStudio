using UnityEngine;

namespace Task_2_3.Scripts
{
    public class Footprint : MonoBehaviour
    {
        [SerializeField] private new ParticleSystem particleSystem;

        private void OnEnable()
        {
            particleSystem.Play();
            Invoke(nameof(Hide), particleSystem.main.duration);
        }

        private void Hide() => gameObject.SetActive(false);
    }
}