using UnityEngine;

public class VariabelRotation : MonoBehaviour
{
    // Dauer für die erste Hälfte (0° bis 180°)
    public float DayTimeDuration = 45f;
    // Dauer für die zweite Hälfte (180° bis 360°)
    public float NightTimeDuration = 30f;

    private float _currentRotation = 0f;

    void Update()
    {
        // 1. Aktuelle Geschwindigkeit basierend auf dem Fortschritt ermitteln
        float degreesPerSecond = CalculateSpeed();

        // 2. Rotation berechnen (Geschwindigkeit * Zeit seit dem letzten Frame)
        float step = degreesPerSecond * Time.deltaTime;
        _currentRotation = (_currentRotation + step) % 360f;

        // 3. Rotation auf der Z-Achse anwenden (Standard für 2D)
        transform.localRotation = Quaternion.Euler(0, 0, _currentRotation);
    }

    /// <summary>
    /// Berechnet die benötigte Geschwindigkeit (Grad pro Sekunde),
    /// um eine Hälfte in der vorgegebenen Zeit zu durchlaufen.
    /// </summary>
    private float CalculateSpeed()
    {
        // Prüfung, in welcher Hälfte sich das Objekt befindet
        if (_currentRotation < -180f)
        {
            // Geschwindigkeit = Weg (-180 Grad) / Zeit (Dauer)
            return -180f / NightTimeDuration;
        }
        else
        {
            return -180f / DayTimeDuration;
        }
    }
}
