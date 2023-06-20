using UnityEngine;

namespace Misc
{
    public class ScreenOrientationSetter : MonoBehaviour
    {
        private enum Orientations
        {
            AutoRotation,
            Portrait,
            LandScapeLeft,
            LandScapeRight,
            PortraitUpsideDown
        }

        [SerializeField] private Orientations orientation;

        private void Awake()
        {
            switch (orientation)
            {
                case Orientations.AutoRotation:
                    Screen.orientation = ScreenOrientation.AutoRotation;
                    break;
                case Orientations.Portrait:
                    Screen.orientation = ScreenOrientation.Portrait;
                    break;
                case Orientations.LandScapeLeft:
                    Screen.orientation = ScreenOrientation.LandscapeLeft;
                    break;
                case Orientations.LandScapeRight:
                    Screen.orientation = ScreenOrientation.LandscapeRight;
                    break;
                case Orientations.PortraitUpsideDown:
                    Screen.orientation = ScreenOrientation.PortraitUpsideDown;
                    break;
            }
        }
    }
}