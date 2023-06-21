using System;
using UnityEngine;

namespace Task_1.Scripts
{
    public class Timer
    {
        private readonly float _loadDuration;
        private float _loadingTime;
        public event Action<float> OnTimerValueChanged;
        public event Action OnTimerEnd;

        public Timer(float loadDuration)
        {
            _loadDuration = loadDuration;
        }

        public void UpdateTimer()
        {
            if (_loadingTime >= _loadDuration)
            {
                OnTimerEnd?.Invoke();
            }

            _loadingTime += Time.deltaTime;
            OnTimerValueChanged?.Invoke(_loadingTime / _loadDuration);
        }
    }
}