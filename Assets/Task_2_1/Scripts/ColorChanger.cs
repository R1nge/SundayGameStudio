using DG.Tweening;
using UnityEngine;

namespace Task_2_1.Scripts
{
    public class ColorChanger : MonoBehaviour
    {
        [SerializeField] private MeshRenderer[] meshRenderers;
        private Color _randomColor;

        private void OnMouseDown() => ChangeColor();

        private void ChangeColor()
        {
            _randomColor = Random.ColorHSV();
            for (int i = 0; i < meshRenderers.Length; i++)
            {
                meshRenderers[i].material.DOColor(_randomColor, 0.5f);
            }
        }
    }
}