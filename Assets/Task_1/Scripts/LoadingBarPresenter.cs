using System;
using UniRx;
using UnityEngine;

namespace Task_1.Scripts
{
    public class LoadingBarPresenter : MonoBehaviour
    {
        [SerializeField] private int slotsToLoad;
        [SerializeField] private LoadingBarView loadingBarView;
        private SlotSpawner _slotSpawner;

        private void Awake()
        {
            _slotSpawner = (SlotSpawner)ServiceLocator.Instance.Get(typeof(SlotSpawner));
            _slotSpawner.Index.Subscribe(UpdateUI);
        }

        private void UpdateUI(int value)
        {
            loadingBarView.UpdateBar((float) value / slotsToLoad);

            if (value == slotsToLoad)
            {
                loadingBarView.UnloadScene();
            }
        }
    }
}