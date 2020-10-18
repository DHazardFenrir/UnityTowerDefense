using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using System;

public class APICall : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    public void GetWeather(Action<string> callback)
    {
        StartCoroutine(CallApiCoroutine(callback));

    }

    public void GetWeatherIcon(string url, Action<Texture2D> callback)
    {
        StartCoroutine(CallApiTextureCoroutine(url, callback));
    }

    private IEnumerator CallApiCoroutine(Action<string> callback)
    {
        string url = "api.openweathermap.org/data/2.5/weather?q=Saltillo&appid=1d08cbb27269b8c6b59836afd56e08b2&units=standard";
        UnityWebRequest request = UnityWebRequest.Get(url);
       
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError("ERROR" + request.error);
        }
        else //Sucess
        {
            string json = request.downloadHandler.text;
            
            callback?.Invoke(json);
        }
    }

    private IEnumerator CallApiTextureCoroutine(string url, Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.downloadHandler = new DownloadHandlerTexture();

        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log("ERROR: " + request.error);


        }
        else //SUCCESS
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(request);
            callback?.Invoke(texture);

        }
    }
}
