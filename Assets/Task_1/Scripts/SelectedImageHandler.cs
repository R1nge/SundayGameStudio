using UnityEngine;

namespace Task_1.Scripts
{
    public class SelectedImageHandler : Singleton<SelectedImageHandler>
    {
        private Texture _selectedImage;

        public void SetSelectedImage(Texture selected) => _selectedImage = selected;

        public Texture GetSelectedImage() => _selectedImage;
    }
}