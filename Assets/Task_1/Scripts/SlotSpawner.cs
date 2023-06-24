using UniRx;
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
        private Vector3 _previousPosition;
        private readonly ReactiveProperty<int> _imageIndex = new();
        private readonly ImageLoader _imageLoader = new();

        public ReactiveProperty<int> Index => _imageIndex;

        private void Awake()
        {
            ServiceLocator.Instance.Register(typeof(SlotSpawner), this);

            _previousPosition = contentParent.position;
            scrollRect.onValueChanged.AddListener(SpawnNextImages);
        }

        private void Start() => SpawnSlotWithImage(6);

        private void SpawnNextImages(Vector2 position)
        {
            if (contentParent.position.y - _previousPosition.y > loadThreshold)
            {
                SpawnSlotWithImage(2);
                _previousPosition = contentParent.position;
            }
        }

        private async void SpawnSlotWithImage(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                _imageIndex.Value++;
                var image = await _imageLoader.GetTexture(_imageIndex.Value);
                if (image != null)
                {
                    var slot = Instantiate(slotPrefab, contentParent);
                    slot.SetImage(image);
                }
            }
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.Remove(typeof(SlotSpawner));

            scrollRect.onValueChanged.RemoveAllListeners();
            _imageIndex.Dispose();
        }
    }
}