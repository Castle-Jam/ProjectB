using UnityEngine;

public class TimeClock : MonoBehaviour
{
    TimeManager tm;
    public RectTransform skyDome;
    float nightHoursToDegrees, dayHoursToDegrees;

    void Start()
    {
        tm = FindFirstObjectByType<TimeManager>();

        // Berechnung der Rotationsgeschwindigkeiten
        nightHoursToDegrees = 180 / (TimeManager.HoursInDay * tm.nightDuration);
        dayHoursToDegrees = 180 / (TimeManager.HoursInDay * (1 - tm.nightDuration));

        // Startrotation setzen
        skyDome.localRotation = Quaternion.Euler(0, 0, 90 + tm.sunriseHour * nightHoursToDegrees);
    }

    void Update()
    {
        // Entscheidung über die aktuelle Geschwindigkeit basierend auf dem Status
        float currentDegreesPerOuterHour = IsNight() ? nightHoursToDegrees : dayHoursToDegrees;

        // Die eigentliche Rotation in einer Zeile
        float rotationStep = -Time.deltaTime * TimeManager.HoursInDay * currentDegreesPerOuterHour / tm.dayDuration;
        skyDome.Rotate(0, 0, rotationStep);
    }

    // Modularisierung der komplexen Bedingung in eine eigene Methode(analog zu [3], [4])
    private bool IsNight()
    {
        float currentHour = tm.GetHour();
        float sunrise = tm.sunriseHour;
        float sunset = tm.GetSunsetHour();

        // Vereinfachte Prüfung der Tageszeit
        if (sunrise < sunset)
        {
            return currentHour < sunrise || currentHour > sunset;
        }
        else
        {
            return currentHour < sunrise && currentHour > sunset;
        }
    }
}