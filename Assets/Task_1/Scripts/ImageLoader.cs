using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class ImageLoader : MonoBehaviour
    {
        [SerializeField, Tooltip("In pixels")] private int loadThreshold;
        [SerializeField] private Slot slotPrefab;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private Transform contentParent;
        private int _imageIndex;
        private Vector3 _previousPosition;

        private void Awake()
        {
            _previousPosition = contentParent.position;
            scrollRect.onValueChanged.AddListener(LoadNewImages);
        }

        private void Start() => GetImages(6);

        private void LoadNewImages(Vector2 position)
        {
            if (contentParent.position.y - _previousPosition.y > loadThreshold)
            {
                GetImages(2);
                _previousPosition = contentParent.position;
            }
        }

        private async void GetImages(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _imageIndex++;
                var image = await GetTexture(_imageIndex);
                if (image != null)
                {
                    var slot = Instantiate(slotPrefab, contentParent);
                    slot.SetImage(image);
                }
            }
        }

        private async UniTask<Texture> GetTexture(int index)
        {
            UnityWebRequest request = await UnityWebRequestTexture.
                GetTexture($"https://data.ikppbb.com/test-task-unity-data/pics/{index}.jpg").
                SendWebRequest().
                WithCancellation(this.GetCancellationTokenOnDestroy());

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
                return null;
            }

            return DownloadHandlerTexture.GetContent(request);
        }

        private void OnDestroy() => scrollRect.onValueChanged.RemoveAllListeners();
    }
}