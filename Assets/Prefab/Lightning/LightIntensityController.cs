using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightIntensityController : MonoBehaviour
{
    public Light2D light2D; // Reference to the 2D light
    public Light2D light2DRight; // Reference to the 2D light
    public KeyCode increaseKey = KeyCode.Space; // The key to increase intensity
    public KeyCode decreaseKey = KeyCode.LeftShift; // The key to decrease intensity (optional)
    public float intensityChangeRate = 0.5f; // How quickly the intensity changes
    public float maxIntensity = 5f; // The maximum light intensity
    public float minIntensity = 0f; // The minimum light intensity

    void Update()
    {
        // Check if the increase key is held down
        if (Input.GetKey(increaseKey))
        {
            light2D.intensity = Mathf.Clamp(light2D.intensity + intensityChangeRate * Time.deltaTime, minIntensity, maxIntensity);
            light2DRight.intensity = Mathf.Clamp(light2DRight.intensity + intensityChangeRate * Time.deltaTime, minIntensity, maxIntensity);
        }

        // Optional: Check if the decrease key is held down
        if (Input.GetKey(decreaseKey))
        {
            light2D.intensity = Mathf.Clamp(light2D.intensity - intensityChangeRate * Time.deltaTime, minIntensity, maxIntensity);
            light2DRight.intensity = Mathf.Clamp(light2DRight.intensity - intensityChangeRate * Time.deltaTime, minIntensity, maxIntensity);
        }
    }
}
