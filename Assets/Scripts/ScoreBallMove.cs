using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBallMove : MonoBehaviour
{
    [SerializeField] GameObject ScoreBall;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ScoreBall.transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
