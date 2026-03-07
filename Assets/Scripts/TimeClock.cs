using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TimeClock : MonoBehaviour
{

    TimeManager tm;

    public RectTransform skyDome;

    float nightHoursToDegrees, dayHoursToDegrees;
    void Start()
    {
        tm = FindFirstObjectByType<TimeManager>();

        nightHoursToDegrees = 180 / (TimeManager.hoursInDay * tm.nightDuration);
        dayHoursToDegrees = 180 / (TimeManager.hoursInDay * (1 - tm.nightDuration));

        skyDome.localRotation = Quaternion.Euler(0, 0, 90 + tm.sunriseHour * nightHoursToDegrees);
    }

    void Update()
    {
        if (((tm.GetHour() < tm.sunriseHour || tm.GetHour() > tm.GetSunsetHour()) && tm.sunriseHour < tm.GetSunsetHour()) ||
            ((tm.GetHour() < tm.sunriseHour && tm.GetHour() > tm.GetSunsetHour()) && tm.sunriseHour > tm.GetSunsetHour()))
        {
            skyDome.Rotate(0, 0, -Time.deltaTime * TimeManager.hoursInDay * nightHoursToDegrees / tm.dayDuration);
        }
        else
        {
            skyDome.Rotate(0, 0, -Time.deltaTime * TimeManager.hoursInDay * dayHoursToDegrees / tm.dayDuration);
        }
    }
}
