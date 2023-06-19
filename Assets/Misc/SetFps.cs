using UnityEngine;

namespace Misc
{
    public class SetFps : MonoBehaviour
    {
        [SerializeField] private int targetFps;

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = targetFps;
        }
    }
}