using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRotation : MonoBehaviour
{
    [SerializeField] GameObject CenterCircle;
    bool diraction = false;
    // Update is called once per frame
    void FixedUpdate()
    {

        var directionWay = (diraction ? 150 : -150) * Time.deltaTime;

        CenterCircle.transform.Rotate(0, 0, directionWay);
    }

    public void OnChangeDiraction() {
        diraction = !diraction;
    }
}
