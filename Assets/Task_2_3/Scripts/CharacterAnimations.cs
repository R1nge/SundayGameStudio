using UnityEngine;

namespace Task_2_3.Scripts
{
    public class CharacterAnimations : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        private static readonly int Speed = Animator.StringToHash("WalkingSpeed");
        private static readonly int Attack = Animator.StringToHash("Attack");

        public void PlayWalkAnimation(float speed) => animator.SetFloat(Speed, speed);

        public void PlayAttackAnimation() => animator.SetTrigger(Attack);

        public void ResetAttackAnimation() => animator.ResetTrigger(Attack);
    }
}