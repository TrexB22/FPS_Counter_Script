using UnityEngine;
using TMPro;

// YouTube Video Link : https://www.youtube.com/watch?v=I2r97r9h074

namespace CodeMonkey.SimpleFpsCounter {

    /// <summary>
    /// This script provides average and consistently smooth FPS values.
    /// </summary>
    public class FPSCounter : MonoBehaviour {

        #region Fields

        [SerializeField] private TextMeshProUGUI fpsCounter;

        private int lastFrameIndex;

        private float[] frameDeltaTimeArray;

        #endregion

        #region Event Functions

        private void Awake() {
            frameDeltaTimeArray = new float[50];
        }

        void Update() {

            frameDeltaTimeArray[lastFrameIndex] = Time.unscaledDeltaTime;

            lastFrameIndex = (lastFrameIndex + 1) % frameDeltaTimeArray.Length;

            fpsCounter.text = Mathf.RoundToInt(CalculateFPS()).ToString();

        }

        #endregion

        #region Average FPS Calculation Logic

        private float CalculateFPS() {

            float total = 0f;

            foreach (float unscaledDeltaTime in frameDeltaTimeArray) {
                total += unscaledDeltaTime;
            }

            return frameDeltaTimeArray.Length / total;

        }

        #endregion

    } // class

} // namespace
