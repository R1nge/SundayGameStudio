using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Task_1.Scripts
{
    public class Slot : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private RawImage rawImage;

        public void SetImage(Texture image) => rawImage.texture = image;

        public void OnPointerClick(PointerEventData eventData) => Open();

        private void Open()
        {
            SelectedImageHandler.Instance.SetSelectedImage(rawImage.texture);
            SceneManager.LoadSceneAsync("Task_1_Preview");
        }
    }
}