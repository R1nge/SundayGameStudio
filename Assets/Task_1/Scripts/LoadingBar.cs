using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class LoadingBar : MonoBehaviour
    {
        [SerializeField] private float loadDuration;
        [SerializeField] private string loadingScene;
        [SerializeField] private Slider loadingBar;
        private Timer _timer;

        private void Awake()
        {
            _timer = new(loadDuration);
            _timer.OnTimerValueChanged += UpdateBar;
            _timer.OnTimerEnd += UnloadScene;
        }

        private void Update() => _timer.UpdateTimer();

        private void UpdateBar(float time) => loadingBar.value = time;

        private void UnloadScene() => SceneManager.UnloadSceneAsync(loadingScene);

        private void OnDestroy()
        {
            _timer.OnTimerValueChanged -= UpdateBar;
            _timer.OnTimerEnd -= UnloadScene;
        }
    }
}