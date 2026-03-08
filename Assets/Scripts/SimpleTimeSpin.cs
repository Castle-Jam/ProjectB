using UnityEngine;

public class VariabelRotation : MonoBehaviour
{
    public float DayTimeDuration = 45f;
    public float NightTimeDuration = 30f;

    private float _currentRotation = 0f;
    private bool isDay = true;

    void Update()
    {
        float degreesPerSecond = CalculateSpeed();

        float step = degreesPerSecond * Time.deltaTime;
        _currentRotation = (_currentRotation + step) % 360f;

        transform.localRotation = Quaternion.Euler(0, 0, _currentRotation);
    }

    
    private float CalculateSpeed()
    {
        if (_currentRotation < -180f)
        {
            if (isDay)
            {
                isDay = false;
                CustomEvent.NightStarted.Invoke();
            }
            return -180f / NightTimeDuration;
        }
        else
        {
            if (!isDay)
            {
                isDay = true;
                CustomEvent.DayStarted.Invoke();
            }
            return -180f / DayTimeDuration;
        }
    }
}
