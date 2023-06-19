using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Task_2_3.Scripts
{
    public class CharacterAttackController : MonoBehaviour
    {
        [SerializeField] private float attackDelay;
        private CharacterAnimations _animations;
        private bool _canAttack = true;

        private void Awake() => _animations = GetComponent<CharacterAnimations>();

        public async void Attack()
        {
            if (_canAttack)
            {
                _animations.PlayAttackAnimation();
                await AttackDelay();
                _animations.ResetAttackAnimation();
            }
        }

        private async UniTask AttackDelay()
        {
            _canAttack = false;
            await UniTask.Delay(TimeSpan.FromSeconds(attackDelay));
            _canAttack = true;
        }
    }
}