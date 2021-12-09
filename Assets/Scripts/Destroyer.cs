using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        var multiTag = other.gameObject.GetComponent<CustomTag>();
        if (multiTag != null && multiTag.HasTag("Destroyable"))
        {
            // Debug.Log(multiTag ?? multiTag.HasTag("Destroyable"));

            Destroy(other.gameObject);
        }
    }
}
