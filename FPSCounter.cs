using UnityEngine;
using TMPro;

// YouTube Link (Code Monkey) : https://www.youtube.com/watch?v=I2r97r9h074

public class FPSCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI fpsCounter;

    private int lastFrameIndex;

    private float[] frameDeltaTimeArray;

    private void Awake() {
        frameDeltaTimeArray = new float[50];
    }

    void Update()
    {

        frameDeltaTimeArray[lastFrameIndex] = Time.unscaledDeltaTime;

        lastFrameIndex = (lastFrameIndex +1 ) % frameDeltaTimeArray.Length;

        fpsCounter.text = Mathf.RoundToInt(CalculateFPS()).ToString();

    }

    private float CalculateFPS() {

        float total = 0f;

        foreach (float unscaledDeltaTime in frameDeltaTimeArray) {
            total += unscaledDeltaTime;
        }   

        return frameDeltaTimeArray.Length/total;

    }

} // class