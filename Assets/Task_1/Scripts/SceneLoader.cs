using UnityEngine;
using UnityEngine.SceneManagement;

namespace Task_1.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void ChangeScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
            SceneManager.LoadSceneAsync("Task_1_Loading", LoadSceneMode.Additive);
        }
    }
}