using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class LoadingBarView : MonoBehaviour
    {
        [SerializeField] private string loadingScene;
        [SerializeField] private Slider loadingBar;

        public void UpdateBar(float time) => loadingBar.value = time;

        public void UnloadScene() => SceneManager.UnloadSceneAsync(loadingScene);
    }
}