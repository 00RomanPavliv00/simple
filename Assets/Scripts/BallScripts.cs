using Assets.Scripts;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallScripts : MonoBehaviour
{
  public int score;

  private string joke;


  [SerializeField] Text scoreText;
  [SerializeField] Text jokeText;

  private SBHttpClient _httpClient;
  // Update is called once per frame
  void Update()
  {
    scoreText.text = score.ToString();
    jokeText.text = joke ?? string.Empty;
  }
  private void Awake()
  {
    _httpClient = new SBHttpClient();
    joke = string.Empty;
  }

  async void OnTriggerEnter2D(Collider2D other)
  {
    var multiTag = other.gameObject.GetComponent<CustomTag>();
    if (multiTag != null && multiTag.HasTag("ScoreBall"))
    {
      Destroy(other.gameObject);
      score++;
      // Debug.Log(score);
    }
    if (multiTag != null && multiTag.HasTag("Enemy"))
    {

      if (score > 0)
      {
        Destroy(other.gameObject);
        score = 0;
      }
      else
      {
        //StartCoroutine(Spawn());
        //var asd = await System.Threading.Tasks.Task.Run(() => _httpClient.GetAsync<DelayModel>());
        var asd = await _httpClient.Get<DelayModel>();
        //SceneManager.LoadScene(2);
        joke = asd.Delay;
      }

      // Debug.Log(score);
    }




  }

}
