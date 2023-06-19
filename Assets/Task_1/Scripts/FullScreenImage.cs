using UnityEngine;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class FullScreenImage : MonoBehaviour
    {
        [SerializeField] private RawImage image;

        private void Awake() => image.texture = SelectedImageHandler.Instance.GetSelectedImage();
    }
}