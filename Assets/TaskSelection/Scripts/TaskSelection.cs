using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TaskSelection.Scripts
{
    public class TaskSelection : MonoBehaviour
    {
        private void Awake() => DontDestroyOnLoad(gameObject);

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadSceneAsync("TaskSelection/TaskSelection");
            }
        }

        public void Select(int index)
        {
            if (index == 0)
            {
                SceneManager.LoadSceneAsync("TaskSelection/TaskSelection");
            }
            else if (index == 1)
            {
                SceneManager.LoadSceneAsync("Task_1/Task_1_MainMenu");
            }
            else if (index == 2)
            {
                SceneManager.LoadSceneAsync("Task_2_1/Task_2_1");
            }
            else if (index == 3)
            {
                SceneManager.LoadSceneAsync("Task_2_2/Task_2_2");
            }
            else if (index == 4)
            {
                SceneManager.LoadSceneAsync("Task_2_3/Task_2_3");
            }
        }
    }
}