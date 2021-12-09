using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawmPos;
    public Transform spawmPos2;
    [SerializeField] Vector2 range;
    [SerializeField] GameObject Enemy;
    [SerializeField] GameObject ScoreBall;

    IEnumerator Spawn() {
        yield return new WaitForSeconds(1);
        Vector2 pos = spawmPos.position + new Vector3(0, Random.Range(-range.y, range.y));
        Instantiate(Enemy, pos, Quaternion.identity);
        Vector2 scoreBallPossion = spawmPos2.position + new Vector3(1, Random.Range(-range.y, range.y));
        Instantiate(ScoreBall, scoreBallPossion, Quaternion.identity);
        Repeat();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn()); 
    }

    // Update is called once per frame
    void Repeat()
    {
        StartCoroutine(Spawn());
    }
}
