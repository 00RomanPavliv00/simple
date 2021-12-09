using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class SBHttpClient
{
  private const string url = "https://api.chucknorris.io/jokes/random";

  private readonly UnityWebRequest _unityWebRequest;

  private const string url2 = "https://postman-echo.com/delay/3";
  public SBHttpClient()
  {
    _unityWebRequest = new UnityWebRequest();
  }

  // Start is called before the first frame update
  public async Task<T> Get<T>(Action<T> callback) where T : class
  {
    using var www = new UnityWebRequest(url: url2);
    www.SetRequestHeader("Content-Type", "application/jsin");
    www.method = UnityWebRequest.kHttpVerbGET;
    var operation = www.SendWebRequest();
    while (operation.isDone)
    {
      await Task.Yield();
    }

    var response = www.downloadHandler.text;

    return JsonUtility.FromJson<T>(response);
  }

  public async Task<T> Get<T>() where T : class
  {
    using var www = UnityWebRequest.Get(url);
    www.SetRequestHeader("Content-Type", "application/jsin");

    var operation = www.SendWebRequest();
    while (!operation.isDone)
    {
      await Task.Yield();
    }

    var response = www.downloadHandler.text;

    return await Task.Run(() =>
      JsonConvert.DeserializeObject<T>(response));
  }

  public async Task<T> GetAsync<T>()
  {
    using var http = new HttpClient();
    using var request = new HttpRequestMessage(HttpMethod.Get, url2);

    var response = await http.SendAsync(request);
    var result = await response.Content.ReadAsStringAsync();

    await Task.Run(() =>
    {
      var end = DateTime.Now + TimeSpan.FromSeconds(10);
      while (DateTime.Now < end) { }
    });

    //return JsonConvert.DeserializeObject<T>(result);
    return await Task.Run(() =>
      JsonConvert.DeserializeObject<T>(result));
  }
}
