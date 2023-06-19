using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class LoadingBar : MonoBehaviour
    {
        [SerializeField] private string loadingScene;
        [SerializeField] private Slider loadingBar;
        [SerializeField] private float loadDuration;
        private float _loadingTime;

        private void Update()
        {
            if (_loadingTime >= loadDuration)
            {
                SceneManager.UnloadSceneAsync(loadingScene);
            }

            _loadingTime += Time.deltaTime;
            loadingBar.value = _loadingTime / loadDuration;
        }
    }
}