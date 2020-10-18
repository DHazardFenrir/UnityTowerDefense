using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using SimpleJSON;
using UnityEngine.UI;

public class WeatherText : MonoBehaviour
{
    [SerializeField] TMP_Text weatherDescription = default;
    [SerializeField] RawImage rawImage;
    APICall api;
    void Start()
    {
        api = FindObjectOfType<APICall>();
        api.GetWeather(OnGetWeatherData);
    }

    private void OnGetWeatherData(string json)
    {
        JSONNode node = JSON.Parse(json);
        JSONArray weather = node["weather"].AsArray;
        string description = weather[0]["description"];
        weatherDescription.text = description;

        //Imagen
        string iconUrl = "http://openweathermap.org/img/wn/" + weather[0]["icon"] + "@4x.png";
        api.GetWeatherIcon(iconUrl, SetIcon);
    }

    private void SetIcon(Texture2D texture)
    {
        Debug.Log("SuccSess");
        rawImage.texture = texture;
    }
}
