using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// </summary>
public class Float : MonoBehaviour
{
    private void Update()
    {
        var orig = this.transform.position;
        this.transform.position = orig + new Vector3(0, Mathf.Sin(Time.time * 2f + orig.x * 0.45f) * 0.05f, 0);
    }
}
