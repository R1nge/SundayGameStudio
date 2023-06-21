using UnityEngine;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class SlotSpawner : MonoBehaviour
    {
        [SerializeField, Tooltip("In pixels")] private int loadThreshold;
        [SerializeField] private Slot slotPrefab;
        [SerializeField] private ScrollRect scrollRect;
        [SerializeField] private Transform contentParent;
        private int _imageIndex;
        private Vector3 _previousPosition;
        private readonly ImageLoader _imageLoader = new();

        private void Awake()
        {
            _previousPosition = contentParent.position;
            scrollRect.onValueChanged.AddListener(SpawnAndSetImages);
        }

        private void Start() => SpawnAndSetImage(6);

        private void SpawnAndSetImages(Vector2 position)
        {
            if (contentParent.position.y - _previousPosition.y > loadThreshold)
            {
                SpawnAndSetImage(2);
                _previousPosition = contentParent.position;
            }
        }

        private async void SpawnAndSetImage(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _imageIndex++;
                var image = await _imageLoader.GetTexture(_imageIndex);
                if (image != null)
                {
                    var slot = Instantiate(slotPrefab, contentParent);
                    slot.SetImage(image);
                }
            }
        }

        private void OnDestroy() => scrollRect.onValueChanged.RemoveAllListeners();
    }
}