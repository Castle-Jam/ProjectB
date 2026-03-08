using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Konstanten und Einstellungen
    public const int HoursInDay = 24;
    public const int MinutesInHour = 60;

    [Header("Einstellungen")]
    public float dayDuration = 0.6f;
    public float nightDuration = 0.4f;
    public float sunriseHour = 6.0f; // In Stunden angegeben (z.B. 6 Uhr morgens)

    private float _currentTime = 0;

    void Update()
    {
        // Kontinuierliche Zeitberechnung
        _currentTime = (_currentTime + Time.deltaTime) % dayDuration;
    }

    public float GetHour()
    {
        return (_currentTime / dayDuration) * HoursInDay;
    }

    // Properties zur Kapselung der Berechnungslogik (analog zur Struktur in [3])
    public float CurrentHour => (_currentTime / dayDuration) * HoursInDay;
    public float CurrentMinute => (CurrentHour * MinutesInHour) % MinutesInHour;

    /// <summary>
    /// Gibt die Zeit im 24-Stunden-Format zurück (00:00).
    /// </summary>
    public string Clock24Hour()
    {
        // Nutzung von String-Formatierung für führende Nullen [2]
        return $"{Mathf.FloorToInt(CurrentHour):00}:{Mathf.FloorToInt(CurrentMinute):00}";
    }

    /// <summary>
    /// Gibt die Zeit im 12-Stunden-Format zurück (12:00 AM/PM).
    /// </summary>
    public string Clock12Hour()
    {
        int hour = Mathf.FloorToInt(CurrentHour);
        string suffix = hour < 12 ? "AM" : "PM";

        // Umwandlung in 12-Stunden-Zählung
        int displayHour = hour % 12;
        if (displayHour == 0) displayHour = 12;

        return $"{displayHour:00}:{Mathf.FloorToInt(CurrentMinute):00} {suffix}";
    }

    /// <summary>
    /// Berechnet den Zeitpunkt des Sonnenuntergangs.
    /// </summary>
    public float GetSunsetHour()
    {
        // Berechnung basierend auf der Tageslänge (1 - Nachtdauer)
        return (sunriseHour + (1 - nightDuration) * HoursInDay) % HoursInDay;
    }
}